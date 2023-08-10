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
        
    }
}