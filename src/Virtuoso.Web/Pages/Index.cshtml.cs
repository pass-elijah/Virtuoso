using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var dict = new Dictionary<string, List<string>>();

        // O(1) https://learn.microsoft.com/en-us/dotnet/api/system.array.getlength?view=net-7.0#remarks
        var length = _example.GetLength(0);

        for (int index = 0; index < length; index++)
        {
            var current = _example[index, 0];
            var depend = _example[index, 1];
            if (dict.TryGetValue(current, out _))
            {
                dict[current].Add(depend);
            }
            else
            {
                dict.Add(current, new() { depend });
            }
        }
    }
}