﻿using BusinessLayer.Interfaces;
using System.Diagnostics;
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

            var arrayToSort = GenerateRandomArray(Constants.sizeArray);

            var bubbleSortStopwatch = Stopwatch.StartNew();

            _sortingServices.BubbleSortNumberAsync(arrayToSort);

            bubbleSortStopwatch.Stop();

            var bubbleSortElapsedNanoseconds = bubbleSortStopwatch.ElapsedMilliseconds;

            var quickSortStopwatch = Stopwatch.StartNew();

            _sortingServices.QuickSortNumberAsync(arrayToSort, 0, arrayToSort.Length - 1);

            quickSortStopwatch.Stop();

            var quickSortElapsedNanoseconds = quickSortStopwatch.ElapsedMilliseconds;

            result["BubbleSortOperationTime"] = bubbleSortElapsedNanoseconds;
            result["QuickSortOperationTime"] = quickSortElapsedNanoseconds;
            result["DifferenceBetweenOperations"] = bubbleSortElapsedNanoseconds - quickSortElapsedNanoseconds;

            return Task.FromResult(result);
        }
    }
}
