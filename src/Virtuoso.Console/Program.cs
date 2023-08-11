using Virtuoso.Domain.Services;
using Virtuoso.Infrastructure.Services;

var topoGraphService = new TopologicalService();
var fileService = new FileService();

var input = fileService.GetInput("input.txt");

var dressingOrder = topoGraphService.SortAndStratify(input.ToArray());

foreach (var writeline in dressingOrder)
{
   Console.WriteLine(writeline);
}
