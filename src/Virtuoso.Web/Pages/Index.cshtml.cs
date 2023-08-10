using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Virtuoso.Domain;
using Virtuoso.Domain.Services;

namespace Virtuoso.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ITopologicalService _toposervice;

    public List<string> DressingSteps { get; set; } = new();

    public string GraphInput { get; set; }

    public IndexModel(ILogger<IndexModel> logger, ITopologicalService toposervice)
    {
        _logger = logger;
        _toposervice = toposervice;
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {

    }
}