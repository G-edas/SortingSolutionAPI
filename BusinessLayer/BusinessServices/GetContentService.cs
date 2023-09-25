using BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.BusinessServices
{
    public class GetContentService : IGetContentService
    {
        private readonly IConfiguration _configuration;

        public GetContentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        public string GetContent()
        {
            string baseFilePath = _configuration["AppSettings:BaseFilePath"];

            DirectoryInfo directoryInfo = new DirectoryInfo(baseFilePath);

            FileInfo[] textFiles = directoryInfo.GetFiles();

            FileInfo latestFile = textFiles.OrderByDescending(file => file.LastWriteTime).FirstOrDefault();

            if (latestFile != null)
            {
                string latestFileName = latestFile.Name;
            
                try
                {
                    if (!File.Exists(latestFileName))
                    {
                        throw new FileNotFoundException("File not found.");
                    }

                    string fileContent = File.ReadAllText(latestFileName);

                    return fileContent;

                }
                catch (IOException ex)
                {
                    throw new Exception($"Error writing to file: {ex.Message}");
                }
            }

            return null;
        }

    }
}
