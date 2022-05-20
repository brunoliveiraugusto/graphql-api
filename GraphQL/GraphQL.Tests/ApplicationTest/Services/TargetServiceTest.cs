using AutoMapper;
using FluentAssertions;
using GraphQL.Application.Services;
using GraphQL.Application.ViewModels;
using GraphQL.Domain.Entities;
using GraphQL.Infra.Interfaces;
using GraphQL.Tests.Utils.Builders.Domain;
using GraphQL.Tests.Utils.Builders.Mapper;
using GraphQL.Tests.Utils.Builders.Repository;
using GraphQL.Tests.Utils.Builders.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GraphQL.Tests.ApplicationTest.Services
{
    public class TargetServiceTest
    {
        private readonly Mock<ITargetRepository> _targetRepositoryMock = new BuilderTargetRepositoryTest().Build();
        private readonly IMapper _mapper = new BuilderMapperTest().Build();
        private readonly IList<TargetHistory> _targetHistory = new BuilderTargetHistoryTest().Historic();
        private readonly IList<TargetHistory> _noHistoric = new BuilderTargetHistoryTest().NoHistoric();
        private readonly CombinationViewModel _combination = new BuilderCombinationViewModelTest().Default().Build();
        private readonly CombinationViewModel _combinationImpossible = new BuilderCombinationViewModelTest().Impossible().Build();

        private TargetService Build()
        {
            return new TargetService(_targetRepositoryMock.Object, _mapper);
        }

        [Fact(DisplayName = "Teste de processamento de combinação dado uma sequência e um alvo")]
        public async void DadoUmaSequenciaEUmAlvoQueroObterUmaCombinacao()
        {
            #region Given
            TargetService targetService = Build();

            _targetRepositoryMock
                .Setup(s => s.CreateAsync(It.IsAny<TargetHistory>()));
            #endregion

            #region When
            var combination = await targetService.ProcessCombinationAsync(_combination.Sequence, _combination.Target);
            #endregion

            #region Then
            combination.Combination.Sum(c => c).Should().Equals(_combination.Sequence.Sum(c => c));
            combination.Combination.Sum(c => c).Should().Equals(_combination.Target);
            #endregion
        }

        [Fact(DisplayName = "Teste de processamento de combinação dado uma sequência e um alvo onde não se é possível fazer uma combinação para atingir o alvo")]
        public async void DadoUmaSequenciaEUmAlvoQueroProcessarUmaCombinacaoImpossivelDeSerRealizada()
        {
            #region Given
            TargetService targetService = Build();

            _targetRepositoryMock
                .Setup(s => s.CreateAsync(It.IsAny<TargetHistory>()));
            #endregion

            #region When
            var combination = await targetService.ProcessCombinationAsync(_combinationImpossible.Sequence, _combinationImpossible.Target);
            #endregion

            #region Then
            combination.Combination.Count().Should().Equals(0);
            combination.Combination.Should().BeEmpty();
            #endregion
        }

        [Fact(DisplayName = "Teste de obtenção de histórico de processamento de combinações")]
        public void ObtencaoDeHistoricoDeProcessamentoDeCombinacoes()
        {
            #region Given
            TargetService targetService = Build();

            _targetRepositoryMock
                .Setup(s => s.GetHistoryByDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(_targetHistory);

            DateTime start = _targetHistory.OrderBy(d => d.Date).FirstOrDefault().Date.AddDays(-3);
            DateTime end = _targetHistory.OrderBy(d => d.Date).LastOrDefault().Date.AddDays(3);
            #endregion

            #region When
            var combination = targetService.GetHistoryByDateRange(start, end);
            #endregion

            #region Then
            combination.Should().NotBeEmpty();
            combination.Should().HaveCount(_targetHistory.Count());
            #endregion
        }

        [Fact(DisplayName = "Teste de obtenção de histórico de processamento de combinações onde não há existência de dados para o range informado")]
        public void ObtencaoDeHistoricoDeProcessamentoDeCombinacoesComAusenciaDeDadosNoRangeInformado()
        {
            #region Given
            TargetService targetService = Build();

            _targetRepositoryMock
                .Setup(s => s.GetHistoryByDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(_noHistoric);

            DateTime start = DateTime.Now.AddYears(5);
            DateTime end = start.AddYears(2);
            #endregion

            #region When
            var combination = targetService.GetHistoryByDateRange(start, end);
            #endregion

            #region Then
            combination.Should().BeEmpty();
            combination.Count().Should().Equals(0);
            #endregion
        }
    }
}
