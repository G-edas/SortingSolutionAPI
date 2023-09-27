using BusinessLayer.Interfaces;

namespace BusinessLayer.BusinessServices
{
    public class SaveContentService : ISaveContentService
    {
        public void WriterToFile(string fileName, int[] content)
        {
            using (StreamWriter writer = File.CreateText(fileName))
            {
                string spaceSeparatedString = string.Join(" ", content);

                writer.WriteLine(spaceSeparatedString);

            }
        }
    }
}
