using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Virtuoso.Domain.Services;

namespace Virtuoso.Infrastructure.Services;

public class FileService : IFileService
{
    public List<string[]> GetInput(string path)
    {
        var lineRegularExpression = new Regex("^(.*), (.*)");

        var input = new List<string[]>();

        using var fileStream = File.OpenRead("input.txt");
        using var streamReader = new StreamReader(fileStream);
        string line;

        while ((line = streamReader.ReadLine()) != null)
        {
            var match = lineRegularExpression.Match(line);
            if (match.Success)
            {
                // The whole group is 0, and the matches are from 1
                input.Add(new string[2] { match.Groups[1].ToString(), match.Groups[2].ToString() });
            }
        }

        return input;
    }
}
