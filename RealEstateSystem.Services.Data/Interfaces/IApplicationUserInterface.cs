﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Services.Data.Interfaces
{
    public interface IApplicationUserInterface
    {

        Task<string> GetFullUserNameAsync(Guid userId);

    }
}
