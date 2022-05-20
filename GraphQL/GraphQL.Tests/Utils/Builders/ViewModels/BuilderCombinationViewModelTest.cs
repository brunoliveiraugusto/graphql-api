using GraphQL.Application.ViewModels;
using System.Collections.Generic;

namespace GraphQL.Tests.Utils.Builders.ViewModels
{
    public class BuilderCombinationViewModelTest : BuilderBaseTest<CombinationViewModel>
    {
        public BuilderCombinationViewModelTest()
        {
            Model = new CombinationViewModel();
        }

        public BuilderCombinationViewModelTest Default()
        {
            Model = new CombinationViewModel
            {
                Sequence = new List<int> { 1, 2, 3, 4, 5 },
                Target = 14
            };

            return this;
        }

        public BuilderCombinationViewModelTest Impossible()
        {
            Model = new CombinationViewModel
            {
                Sequence = new List<int> { 7, 13, 22, 40, 59 },
                Target = 9
            };

            return this;
        }
    }
}
