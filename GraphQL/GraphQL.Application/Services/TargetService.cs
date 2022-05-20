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

        public async Task<TargetViewModel> ProcessCombinationAsync(IEnumerable<int> sequence, int target)
        {
            try
            {
                IList<int> result = GetCombination(sequence.OrderByDescending(s => s), target);

                TargetHistory targetHistory = (JsonConvert.SerializeObject(sequence), 
                    JsonConvert.SerializeObject(result), target);

                await _targetRepository.CreateAsync(targetHistory);

                var combination = result.Sum(r => r) == target ? 
                    result : new List<int>();

                return TargetViewModel.NewTarget(combination);
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
