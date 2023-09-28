﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Interfaces
{
    public interface ISortingUseCase
    {
        Task<int[]> SortingUseCaseByAlgorithm(int[] arrayNums);
    }
}
