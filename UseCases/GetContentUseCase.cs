using BusinessLayer.Interfaces;
using UseCases.Interfaces;

namespace UseCases
{
    public class GetContentUseCase : IGetContentUseCase
    {
        private readonly IGetContentService _getContentService;

        public GetContentUseCase(IGetContentService getContentService)
        {
            _getContentService = getContentService;
        }
        public async Task<string> GetLatestContentUseCase()
        {

            var result = await _getContentService.GetContent();

            if (result == null)
            {
                throw new FileNotFoundException("Latest file was not found");
            }

            return result;

        }
    }
}
