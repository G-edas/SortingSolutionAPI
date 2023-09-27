using BusinessLayer.BusinessServices.SortingServices;
using BusinessLayer.Interfaces;
using Moq;

namespace UnitTests;

public class TestSortingService
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void QuickSortNumberAsync_ReturnsSortedArray()
    {
        // Arrange
        var givenArray = new int[] { 2, 1, 10, 9, 8, 5, 4, 3, 6, 7 };
        int[] expectedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var sortingServices = new SortingServices();
        var mockBusinessServices = new Mock<ISortingServices>();

        // Mock the QuickSortNumberAsync method
        mockBusinessServices.Setup(q => q.QuickSortNumberAsync(givenArray, 0, givenArray.Length - 1))
                           .Callback(() => sortingServices.QuickSortNumberAsync(givenArray, 0, givenArray.Length - 1));

        // Act
        mockBusinessServices.Object.QuickSortNumberAsync(givenArray, 0, givenArray.Length - 1);

        // Assert
        CollectionAssert.AreEqual(expectedArray, givenArray);

    }

    [Test]
    public void BubbleSortNumberAsync_ReturnsSortedArray()
    {
        // Arrange
        var givenArray = new int[] { 2, 1, 10, 9, 8, 5, 4, 3, 6, 7 };
        int[] expectedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var sortingServices = new SortingServices();
        var mockBusinessServices = new Mock<ISortingServices>();

        // Mock the BubbleSortNumberAsync method
        mockBusinessServices.Setup(q => q.BubbleSortNumberAsync(givenArray))
                           .Callback(() => sortingServices.BubbleSortNumberAsync(givenArray));

        // Act
        mockBusinessServices.Object.BubbleSortNumberAsync(givenArray);

        // Assert
        CollectionAssert.AreEqual(expectedArray, givenArray);

    }
}