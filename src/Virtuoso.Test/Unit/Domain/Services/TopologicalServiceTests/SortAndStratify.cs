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
        List<List<string>> input = new()
        {
            new() {"t-shirt", "dress shirt"},
            new() { "dress shirt", "pants" },
            new() { "dress shirt", "suit jacket" },
            new() { "tie", "suit jacket" },
            new() { "pants", "suit jacket" },
            new() { "belt", "suit jacket" },
            new() { "suit jacket", "overcoat" },
            new() { "dress shirt", "tie" },
            new() { "suit jacket", "sun glasses" },
            new() { "sun glasses", "overcoat" },
            new() { "left sock", "pants" },
            new() { "pants", "belt" },
            new() { "suit jacket", "left shoe" },
            new() { "suit jacket", "right shoe" },
            new() { "left shoe", "overcoat" },
            new() { "right sock", "pants" },
            new() { "right shoe", "overcoat" },
            new() { "t-shirt", "suit jacket" }
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

        var actual = _toposervice.SortAndStratify(input.Select(a => a.ToArray()).ToArray());

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Ppe()
    {
        List<List<string>> input = new()
        {
            new() {"undershirt", "fire-proof shirt"},
            new() { "fire-proof shirt", "CO monitor"},
            new() { "underpants", "fire-proof pants" }
        };

        var expected = new List<string>
        {
            "underpants",
            "fire-proof pants, undershirt",
            "fire-proof shirt",
            "CO monitor",
        };

        var actual = _toposervice.SortAndStratify(input.Select(a => a.ToArray()).ToArray());

        Assert.Equal(expected, actual);
    }
}
