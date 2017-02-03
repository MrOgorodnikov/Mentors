﻿using Mentors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Interface
{
    public interface IRepository
    {
        IEnumerable<Mentor> GetAll();

    }
}
