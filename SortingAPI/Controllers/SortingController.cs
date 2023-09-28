using Microsoft.AspNetCore.Mvc;
using SortingAPI.Controllers.Base;
using UseCases.Interfaces;

namespace SortingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SortingController : BaseApiController
    {
        private readonly ISortingUseCase _sortingUseCase;
        private readonly IGetContentUseCase _getContentUseCase;
        private readonly ITimeBetweenMultipleSortingUseCase _timeBetweenMultipleSortingUseCases;

        public SortingController(ISortingUseCase sortingUseCase, IGetContentUseCase getContentUseCase,
            ITimeBetweenMultipleSortingUseCase timeBetweenMultipleSortingUseCase)
        {
            _sortingUseCase = sortingUseCase;
            _getContentUseCase = getContentUseCase;
            _timeBetweenMultipleSortingUseCases = timeBetweenMultipleSortingUseCase;
        }

        [HttpPost]
        //Cia kaip suprantu pagal salyga reikejo padaryti nuo 1 iki 10 kad priimtu tiktai?
        public async Task<IActionResult> SortNumberArray([FromBody][CustomValidator(1,10)] int[] intArrays)
        {
            return HandleResult(await _sortingUseCase.SortingUseCaseByAlgorithm(intArrays));
        }

        [HttpGet("latestFileContent")]
        public async Task<IActionResult> GetContentOfFile()
        {
            return HandleResult(await _getContentUseCase.GetLatestContentUseCase());
        }

        [HttpGet("timeBetweenTwoSortingAlgorithms")]
        public async Task<IActionResult> GetTimeBetweenSortingAlgorithms()
        {
            return HandleResult(await _timeBetweenMultipleSortingUseCases.SortingBetweenMultipleAlgoritms());
        }
    }
}