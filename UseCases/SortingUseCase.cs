using BusinessLayer.Interfaces;
using System.ComponentModel.DataAnnotations;
using UseCases.Interfaces;

namespace UseCases
{
    public class SortingUseCase : ISortingUseCase
    {
        private readonly ISortingServices _sortingServices;
        public SortingUseCase(ISortingServices sortingServices)
        {
            _sortingServices = sortingServices;
        }
        public int[] SortingBubbleUseCase(int[] arrayNums)
        {
            string fileName = $"sorted_array_{DateTime.Now:yyyyMMddHHmmss}.txt";

            if (arrayNums.Any(x => x < 0) || arrayNums.Length == 0 || arrayNums == null)
            {
                throw new ArgumentException("Input array must contain natural numbers greater than 0.");
            }

            var result =  _sortingServices.BubbleSortNumberAsync(arrayNums).Result;

            try
            {
                using (StreamWriter writer = System.IO.File.CreateText(fileName))
                {
                    string spaceSeparatedString = string.Join(" ", result);

                    writer.WriteLine(spaceSeparatedString);

                }
            }

            catch (IOException ex)
            {
                throw new Exception($"Error writing to file: {ex.Message}");
            }

            return result;
        }
    }
}