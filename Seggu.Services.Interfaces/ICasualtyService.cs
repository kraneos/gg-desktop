﻿using Seggu.Dtos;
using System;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface ICasualtyService
    {
        IEnumerable<CasualtyDto> GetByPolicyId(int id);

        void Save(CasualtyDto submitCasualtyFormDto);
    }
}
