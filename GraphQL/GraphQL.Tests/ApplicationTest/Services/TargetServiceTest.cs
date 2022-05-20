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
        private Mock<ITargetRepository> _targetRepositoryMock = new BuilderTargetRepositoryTest().Build();
        private IMapper _mapper = new BuilderMapperTest().Build();
        private IList<TargetHistory> _targetHistory = new BuilderTargetHistoryTest().Historic();
        private CombinationViewModel _combinationVM = new BuilderCombinationViewModelTest().Default().Build();

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
            var combination = await targetService.ProcessCombinationAsync(_combinationVM);
            #endregion

            #region Then
            combination.Sum(c => c).Should().Equals(_combinationVM.Sequence.Sum(c => c));
            combination.Sum(c => c).Should().Equals(_combinationVM.Target);
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
    }
}
