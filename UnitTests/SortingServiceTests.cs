//using Xunit;
using NUnit.Framework;
using BusinessLayer.BusinessServices.SortingServices;

namespace UnitTests
{
    [TestFixture]
    public class SortingServiceTests
    {

        [TestCase(new[] { 5, 2, 9, 1, 5, 6 }, new[] { 1, 2, 5, 5, 6, 9 })]
        [TestCase(new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 }, new[] { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 })]
        public async void SortArrayWithBubbleSort_ReturnsSortedArray(int[] unsortedAray, int[] expectedArray)
        {
            // Arrange
            var bubbleSortService = new SortingServices();
  
            // Act
            var sortedArray = bubbleSortService.BubbleSortNumberAsync(unsortedAray);
            int[] resultArray = await sortedArray;

            // Assert
            
            Assert.AreEqual(expectedArray, resultArray);

        }

 
    }
}
