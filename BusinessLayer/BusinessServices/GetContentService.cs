using BusinessLayer.Interfaces;

namespace BusinessLayer.BusinessServices
{
    public class GetContentService : IGetContentService
    {
        public Task<string> GetContent()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            FileInfo? latestFile = directoryInfo.GetFiles("*.txt").OrderByDescending(file => file.LastWriteTime).FirstOrDefault();

            if(latestFile != null) {

                return Task.FromResult(File.ReadAllText(latestFile.Name));
            }

            throw new FileNotFoundException("Latest file was not found");
        }
    }
}
