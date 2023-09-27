using BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.BusinessServices
{
    public class GetContentService : IGetContentService
    {
        public string GetContent(string latestFileName)
        {
            return File.ReadAllText(latestFileName);
        }

    }
}
