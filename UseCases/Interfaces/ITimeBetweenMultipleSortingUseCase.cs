namespace UseCases.Interfaces
{
    public interface ITimeBetweenMultipleSortingUseCase
    {
        Task<Dictionary<string, long>> SortingBetweenMultipleAlgoritms();
    }
}