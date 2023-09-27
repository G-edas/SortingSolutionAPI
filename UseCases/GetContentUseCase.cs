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
        public Task<string> GetLatestContentUseCase()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);

            FileInfo[] textFiles = directoryInfo.GetFiles("*.txt");

            FileInfo latestFile = textFiles.OrderByDescending(file => file.LastWriteTime).FirstOrDefault();

            if (latestFile != null)
            {
                string latestFileName = latestFile.Name;

                if (!File.Exists(latestFileName))
                {
                    throw new FileNotFoundException("File not found.");
                }

                return Task.FromResult(_getContentService.GetContent(latestFileName));

            }

            throw new FileNotFoundException("Latest file was not found");
        }
    }
}
