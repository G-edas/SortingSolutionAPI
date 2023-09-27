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
        public int[]? SortingUseCaseByAlgorithm(int[] arrayNums)
        {
            string fileName = $"sorted_array_{DateTime.Now:yyyyMMddHHmmss}.txt";

            if (arrayNums == null || arrayNums.Any(x => x < 0) || arrayNums.Length == 0)
            {
                throw new ArgumentException("Input array must contain natural numbers greater than 0 and cannot be empty.");
            }

            var result =  _sortingServices.QuickSortNumberAsync(arrayNums, 0, arrayNums.Length - 1).Result;

            _saveContentService.WriterToFile(fileName, result);

            //try
            //{
            //    using (StreamWriter writer = File.CreateText(fileName))
            //    {
            //        string spaceSeparatedString = string.Join(" ", result);

            //        writer.WriteLine(spaceSeparatedString);

            //    }
            //}


            //catch (IOException ex)
            //{
            //    throw new Exception($"Error writing to file: {ex.Message}");
            //}

            return result;
        }
    }
}