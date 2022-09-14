﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaLib.DAL
{
    public static class RepoFactory
    {
        public static IRepo GetRepo() => new DBRepo();
    }
}
