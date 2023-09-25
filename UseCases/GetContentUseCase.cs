using BusinessLayer.Interfaces;
using UseCases.Interfaces;

namespace UseCases
{
    public class GetContentUseCase : IGetContentUseCase
    {
        private readonly IGetContentService _getContentService;
        //private readonly string fileName = $"data_sorted.txt";

        public GetContentUseCase(IGetContentService getContentService)
        {
            _getContentService = getContentService;
        }
        public Task<string> GetLatestContentUseCase()
        {
            try
            {
                var latestFile = _getContentService.GetContent();

                if (latestFile == null)
                {
                    throw new FileNotFoundException("No files found.");
                }

                return Task.FromResult(latestFile);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
    }
}
