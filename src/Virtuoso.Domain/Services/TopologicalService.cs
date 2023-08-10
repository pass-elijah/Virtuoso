using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtuoso.Domain.Services;

public class TopologicalService : ITopologicalService
{
    public List<string> SortAndStratify(string[,] input)
    {
        var dict = new Dictionary<string, HashSet<string>>();
        List<string> dressingSteps = new();

        // O(1) https://learn.microsoft.com/en-us/dotnet/api/system.array.getlength?view=net-7.0#remarks
        var length = input.GetLength(0);

        HashSet<string> everyGarmentMap = new();

        for (int index = 0; index < length; index++)
        {
            var current = input[index, 0];
            var depend = input[index, 1];
            if (!dict.TryGetValue(current, out _))
            {
                dict.Add(current, new());
            }

            dict[current].Add(depend);
            everyGarmentMap.Add(depend);
            everyGarmentMap.Add(current);
        }

        var dressingOrder = TopoligicalSort(dict, everyGarmentMap);

        HashSet<string> currentLine = new();
        HashSet<string> resetIfSee = new();

        foreach (var garment in dressingOrder)
        {
            if (resetIfSee.Contains(garment))
            {
                dressingSteps.Add(string.Join(", ", currentLine.Order()));
                resetIfSee.Clear();
                currentLine.Clear();
            }

            if (dict.ContainsKey(garment))
            {
                resetIfSee.UnionWith(dict[garment]);
            }

            currentLine.Add(garment);
        }

        if (currentLine.Count > 0)
        {
            dressingSteps.Add(string.Join(", ", currentLine));
        }

        return dressingSteps;
    }

    private Stack<string> TopoligicalSort(Dictionary<string, HashSet<string>> dependencies, HashSet<string> everyGarment)
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

    private void TopologicalSortUntil(string garment, Dictionary<string, HashSet<string>> dependencies, HashSet<string> vistied, Stack<string> order)
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
