using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Virtuoso.Domain;

namespace Virtuoso.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly string[,] _example = new string[,]
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

    public List<string> DressingSteps { get; set; } = new();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var dict = new Dictionary<string, List<string>>();

        // O(1) https://learn.microsoft.com/en-us/dotnet/api/system.array.getlength?view=net-7.0#remarks
        var length = _example.GetLength(0);

        HashSet<string> everyGarmentMap = new();

        for (int index = 0; index < length; index++)
        {
            var current = _example[index, 0];
            var depend = _example[index, 1];
            if (!dict.TryGetValue(current, out _))
            {
                dict.Add(current, new());
            }

            dict[current].Add(depend);
            everyGarmentMap.Add(depend);
            everyGarmentMap.Add(current);
        }

        var dressingOrder = TopoligicalSort(dict, everyGarmentMap);

    }

    private Stack<string> TopoligicalSort(Dictionary<string, List<string>> dependencies, HashSet<string> everyGarment)
    {
        Stack<string> order = new();
        HashSet<string> visited = new();

        foreach (var garment in everyGarment)
        {
            if (!visited.Contains(garment))
            {
                TopologicalSortUntil(garment, dependencies, visited, order);
            }
        }

        return order;
    }

    private void TopologicalSortUntil(string garment, Dictionary<string, List<string>> dependencies, HashSet<string> vistied, Stack<string> order)
    {
        if (vistied.Contains(garment))
        {
            return;
        }

        vistied.Add(garment);

        if (dependencies.ContainsKey(garment))
        {
            foreach (var dependency in dependencies[garment])
            {
                TopologicalSortUntil(dependency, dependencies, vistied, order);
            }
        }

        order.Push(garment);
    }
}