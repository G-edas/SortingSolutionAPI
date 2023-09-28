using BusinessLayer.BusinessServices.SortingServices;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SortingAPI.Controllers.Base;
using System.Collections;
using System.Diagnostics;
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
        public async Task<IActionResult> SortNumberArray(int[] intArray)
        {
            return HandleResult(await _sortingUseCase.SortingUseCaseByAlgorithm(intArray));
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