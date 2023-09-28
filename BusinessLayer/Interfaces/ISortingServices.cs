namespace BusinessLayer.Interfaces
{
    public interface ISortingServices
    {
        Task<int[]> BubbleSortNumberAsync(int[] intsArray);
        Task<int[]> QuickSortNumberAsync(int[] intsArray, int leftIndex, int rightIndex);

    }
}
