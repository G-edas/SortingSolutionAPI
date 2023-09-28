using BusinessLayer.BusinessServices.SortingServices;
using BusinessLayer.Interfaces;
using Moq;
using UseCases;

namespace UnitTests;

public class TestSortingUseCase
{
    [SetUp]
    public async Task Setup()
    {
    }

    [Test]
    public async Task TestSortingUseCaseByAlgorithm_DoesntThrowErrorReturnsSortedArray()
    {
        // Arrange
        var givenArray = new int[] { 2, 1, 10, 9, 8, 5, 4, 3, 6, 7};
        int[] expectedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //Mock
        var sortingServiceMock = new Mock<ISortingServices>();
        var writerToFileServiceMock = new Mock<ISaveContentService>();

        sortingServiceMock.Setup(service => service.QuickSortNumberAsync(givenArray, 0, givenArray.Length - 1))
                            .ReturnsAsync((int[] inputArray, int left, int right) =>
                            {
                                return inputArray.OrderBy(x => x).ToArray();
                            });

        var useCase = new SortingUseCase(sortingServiceMock.Object, writerToFileServiceMock.Object);


        // Act
        var result = useCase.SortingUseCaseByAlgorithm(givenArray).Result;

        // Assert
        CollectionAssert.AreEqual(expectedArray, result);

    }

    [Test]
    public async Task TestSortingUseCaseByAlgorithm_ThrowArgumentExceptionBecauseOfEmpty()
    {
        // Arrange
        var emptyArray = new int[0];

        // Mock
        var sortingServiceMock = new Mock<ISortingServices>();
        var writerToFileServiceMock = new Mock<ISaveContentService>();

        var useCase = new SortingUseCase(sortingServiceMock.Object, writerToFileServiceMock.Object);

        // Act and Assert
        Assert.ThrowsAsync<ArgumentException>(() => useCase.SortingUseCaseByAlgorithm(emptyArray));
    }

    [Test]
    public async Task TestSortingUseCaseByAlgorithm_ThrowArgumentExceptionBecauseOfWrongInput()
    {
        // Arrange
        var wrongArray = new int[] { -1, 2, 3 };

        var sortingServiceMock = new Mock<ISortingServices>();
        var writerToFileServiceMock = new Mock<ISaveContentService>();


        var useCase = new SortingUseCase(sortingServiceMock.Object, writerToFileServiceMock.Object);

        // Act and Assert
        Assert.ThrowsAsync<ArgumentException>(() => useCase.SortingUseCaseByAlgorithm(wrongArray));

    }

    [Test]
    public async Task TestSortingUseCaseByAlgorithm_ThrowArgumentExceptionBecauseOfNull()
    {
        // Arrange
        int[] emptyArray = null;

        //Mock
        var sortingServiceMock = new Mock<ISortingServices>();
        var writerToFileServiceMock = new Mock<ISaveContentService>();


        var useCase = new SortingUseCase(sortingServiceMock.Object, writerToFileServiceMock.Object);

        // Act and Assert

        Assert.ThrowsAsync<ArgumentException>(() => useCase.SortingUseCaseByAlgorithm(emptyArray));

    }


    [Test]
    public async Task TestSortingUseCaseByAlgorithm_DoesntThrowWritesArrayToFile()
    {
        // Arrange
        var givenArray = new int[] { 2, 1, 10, 9, 8, 5, 4, 3, 6, 7 };
        int[] expectedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string fileName = $"sorted_array_{DateTime.Now:yyyyMMddHHmmss}.txt";


        //Mock
        var sortingServiceMock = new Mock<ISortingServices>();
        var writerToFileServiceMock = new Mock<ISaveContentService>();

        sortingServiceMock.Setup(service => service.QuickSortNumberAsync(givenArray, 0, givenArray.Length - 1))
                            .ReturnsAsync((int[] inputArray, int left, int right) =>
                            {
                                return inputArray.OrderBy(x => x).ToArray();
                            });

        var useCase = new SortingUseCase(sortingServiceMock.Object, writerToFileServiceMock.Object);

        // Act
        var result = await useCase.SortingUseCaseByAlgorithm(givenArray);

        writerToFileServiceMock.Verify(
            writer => writer.WriterToFile(
                fileName,
                result),
            Times.Once);

    }


}