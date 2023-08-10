using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtuoso.Domain.Services;

namespace Virtuoso.Test.Unit.Domain.Services.TopologicalServiceTests;

public class SortAndStratify
{
    private ITopologicalService _toposervice;

    public SortAndStratify()
    {
        _toposervice = new TopologicalService();
    }

    [Fact]
    public void ProblemStatement()
    {
        string[,] input = new string[,]
        {
            {"t-shirt", "dress shirt"},
            {"dress shirt", "pants"},
            {"dress shirt", "suit jacket"},
            {"tie", "suit jacket"},
            {"pants", "suit jacket"},
            {"belt", "suit jacket"},
            {"suit jacket", "overcoat"},
            {"dress shirt", "tie"},
            {"suit jacket", "sun glasses"},
            {"sun glasses", "overcoat"},
            {"left sock", "pants"},
            {"pants", "belt"},
            {"suit jacket", "left shoe"},
            {"suit jacket", "right shoe"},
            {"left shoe", "overcoat"},
            {"right sock", "pants"},
            {"right shoe", "overcoat"},
            {"t-shirt", "suit jacket"}
        };

        var expected = new List<string>
        {
            "left sock, right sock, t-shirt",
            "dress shirt",
            "pants, tie",
            "belt",
            "suit jacket",
            "left shoe, right shoe, sun glasses",
            "overcoat"
        };

        var actual = _toposervice.SortAndStratify(input);

        Assert.Equal(expected, actual);
    }
}
