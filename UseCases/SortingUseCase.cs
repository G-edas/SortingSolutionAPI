using BusinessLayer.Interfaces;
using UseCases.Interfaces;

namespace UseCases
{
    public class SortingUseCase : ISortingUseCase
    {
        private readonly ISortingServices _sortingServices;
        private readonly ISaveContentService _saveContentService;

        public SortingUseCase(ISortingServices sortingServices, ISaveContentService saveContentService)
        {
            _sortingServices = sortingServices;
            _saveContentService = saveContentService;
        }
        public async Task<int[]> SortingUseCaseByAlgorithm(int[]? arrayNums)
        {
            string fileName = $"sorted_array_{DateTime.Now:yyyyMMddHHmmss}.txt";

            if (arrayNums == null || arrayNums.Any(x => x < 0) || arrayNums.Length == 0)
            {
                throw new ArgumentException("Input array must contain natural numbers greater than 0 and cannot be empty.");
            }

            var result =  await _sortingServices.QuickSortNumberAsync(arrayNums, 0, arrayNums.Length - 1);

            _saveContentService.WriterToFile(fileName, result);

            return result;
        }
    }
}