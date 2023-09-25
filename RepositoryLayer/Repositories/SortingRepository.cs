using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Repositories
{
    public class SortingRepository : ISortingRepository
    {
        public readonly DataContext _dataContext;
        public SortingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<int[]> SortNumberAsync(int[] intsArray)
        {
            var result = _dataContext.SortedNumbers.Add(intsArray);

            return null;

            //await _dataContext.SaveChangesAsync();

            //return result.Entity.Id;
        }

    }
}

