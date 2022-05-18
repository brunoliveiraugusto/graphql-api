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

        public TargetService(ITargetRepository targetRepository)
        {
            _targetRepository = targetRepository;
        }

        public async Task<TargetViewModel> ProcessCombinationAsync(IEnumerable<int> sequence, int target)
        {
            try
            {
                IList<int> result = GetCombination(sequence.OrderByDescending(s => s), target);

                TargetHistory targetHistory = (JsonConvert.SerializeObject(sequence), JsonConvert.SerializeObject(result), target);

                await _targetRepository.CreateAsync(targetHistory);

                return TargetViewModel.NewTargetViewModel(result, target);
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
    }
}
