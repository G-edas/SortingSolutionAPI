using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ISortingServices
    {
        Task<int[]> BubbleSortNumberAsync(int[] intsArray);
        Task<int[]> QuickSortNumberAsync(int[] intsArray, int leftIndex, int rightIndex);

    }
}
