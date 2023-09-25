using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace UseCases
{
    public class TimeBetweenMultipleSortingUseCase : ITimeBetweenMultipleSortingUseCase
    {
        private readonly ISortingServices _sortingServices;
        public TimeBetweenMultipleSortingUseCase(ISortingServices sortingServices)
        {
            _sortingServices = sortingServices;
        }

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }

        public Task<Dictionary<string, long>> SortingBetweenMultipleAlgoritms()
        {
            var result = new Dictionary<string, long>();

            int[] arrayToSort = GenerateRandomArray(10000);

            var bubbleSortStopwatch = Stopwatch.StartNew();

            _sortingServices.BubbleSortNumberAsync(arrayToSort);

            bubbleSortStopwatch.Stop();

            long bubbleSortElapsedNanoseconds = bubbleSortStopwatch.ElapsedMilliseconds;
                //* 1000000000L / Stopwatch.Frequency;

            var quickSortStopwatch = Stopwatch.StartNew();

            _sortingServices.QuickSortNumberAsync(arrayToSort, 0, arrayToSort.Length - 1);

            quickSortStopwatch.Stop();

            long quickSortElapsedNanoseconds = quickSortStopwatch.ElapsedMilliseconds;
                //* 1000000000L / Stopwatch.Frequency;

            result["BubbleSortOperationTime"] = bubbleSortElapsedNanoseconds;
            result["QuickSortOperationTime"] = quickSortElapsedNanoseconds;
            result["DifferenceBetweenOperations"] = bubbleSortElapsedNanoseconds - quickSortElapsedNanoseconds;

            return Task.FromResult(result);

        }
    }
}
