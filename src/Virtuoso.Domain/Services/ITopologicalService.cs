﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtuoso.Domain.Services;

public interface ITopologicalService
{
    public Stack<string> Sort(string[,] input);

    public List<string> SortAndStratify(string[,] input);
}
