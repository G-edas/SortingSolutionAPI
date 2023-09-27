using BusinessLayer.Interfaces;
using Moq;
using UseCases;

namespace UnitTests;

public class TestGetContentUseCase
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestGetContentUseCase_DoesntThrowError()
    {

        // Arrange
        string testingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        string testingFileName = "Test1.txt";
        string filePath = Path.Combine(testingDirectory, testingFileName);
        File.WriteAllText(filePath, "This is for unit tests.");

        //Mock
        var getContentServiceMock = new Mock<IGetContentService>();
        getContentServiceMock.Setup(service => service.GetContent(testingFileName)).Returns("This is for unit tests.");

        var useCase = new GetContentUseCase(getContentServiceMock.Object);

        // Act
        string result = useCase.GetLatestContentUseCase().Result;

        // Assert
        Assert.AreEqual("This is for unit tests.", result);

        //write me unit tests to get latest file content


    }

    [Test]
    public void TestGetContentUseCase_ThrowsErrorFileNotFound()
    {

        // Arrange
        string testingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        string testingFileName = "FileNotFound.txt"; // A file that doesn't exist
        string filePath = Path.Combine(testingDirectory, testingFileName);

        // Mock
        var getContentServiceMock = new Mock<IGetContentService>();
        getContentServiceMock.Setup(service => service.GetContent(It.IsAny<string>())).Throws<FileNotFoundException>();

        var useCase = new GetContentUseCase(getContentServiceMock.Object);

        // Act and Assert
        Assert.ThrowsAsync<FileNotFoundException>(async () => await useCase.GetLatestContentUseCase());

    }
}