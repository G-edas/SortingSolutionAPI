namespace UseCases.Interfaces
{
    public interface ISortingUseCase
    {
        Task<int[]> SortingUseCaseByAlgorithm(int[] arrayNums);
    }
}
