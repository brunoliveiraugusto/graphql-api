using AutoMapper;
using GraphQL.Application.Interfaces;
using GraphQL.Application.ViewModels;
using GraphQL.Domain.Entities;
using GraphQL.Infra.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Application.Services
{
    public class TargetService : ITargetService
    {
        private readonly ITargetRepository _targetRepository;
        private readonly IMapper _mapper;

        public TargetService(ITargetRepository targetRepository, IMapper mapper)
        {
            _targetRepository = targetRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<int>> ProcessCombinationAsync(CombinationViewModel combination)
        {
            try
            {
                IList<int> result = GetCombination(combination.Sequence.OrderByDescending(s => s), combination.Target);

                TargetHistory targetHistory = (JsonConvert.SerializeObject(combination.Sequence), 
                    JsonConvert.SerializeObject(result), combination.Target);

                await _targetRepository.CreateAsync(targetHistory);

                return result.Sum(r => r) == combination.Target ? 
                    result : new List<int>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static IList<int> GetCombination(IEnumerable<int> sequence, int target)
        {
            IList<int> result = new List<int>();

            foreach (var s in sequence)
            {
                while ((result.Sum(r => r) + s) <= target)
                {
                    result.Add(s); 
                }
            }

            return result;
        }

        public IEnumerable<TargetHistoryViewModel> GetHistoryByDateRange(DateTime start, DateTime end)
        {
            var history = _targetRepository.GetHistoryByDateRange(start, end);
            return Mapper<IEnumerable<TargetHistoryViewModel>, IEnumerable<TargetHistory>>(history);
        }

        private M Mapper<M, E>(E entity)
        {
            return _mapper.Map<M>(entity);
        }
    }
}
