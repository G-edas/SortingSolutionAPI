using AutoMapper;
using BusinessLayer.Interfaces;

namespace BusinessLayer.BusinessServices.SortingServices
{

    public class SortingServices : ISortingServices
    {

        public Task<int[]> BubbleSortNumberAsync(int[] intsArray)
        {
            int lenght = intsArray.Length;

            for (int i = 0; i < lenght; i++)
            {
                for(int j = 0; j < lenght - 1; j++)
                {
                    if (intsArray[j] > intsArray[j + 1])
                    {
                        var tempValue = intsArray[j];
                        intsArray[j] = intsArray[j + 1];
                        intsArray[j + 1] = tempValue;
                    }
                }
            }

            return Task.FromResult(intsArray);
        }

        public Task<int[]> QuickSortNumberAsync(int[] intsArray, int leftIndex, int rightIndex)
        {
            
            
            int i = leftIndex;
            int j = rightIndex;
            int pivot = intsArray[leftIndex];

            while (i <= j)
            {
                while (intsArray[i] < pivot)
                {
                    i++;
                }
                
                while(intsArray[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = intsArray[i];
                    intsArray[i] = intsArray[j];
                    intsArray[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSortNumberAsync(intsArray, leftIndex, j);
            if (i < rightIndex)
                QuickSortNumberAsync(intsArray, i, rightIndex);

            return Task.FromResult(intsArray);
        }

    }

}

