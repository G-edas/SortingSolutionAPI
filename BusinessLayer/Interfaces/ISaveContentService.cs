namespace BusinessLayer.Interfaces
{
    public interface ISaveContentService
    {
        void WriterToFile(string fileName, int[] content);
    }
}