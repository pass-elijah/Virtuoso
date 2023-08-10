using System.Text.RegularExpressions;

var lineRegularExpression = new Regex("^(.*), (.*)");

var input = new List<List<string>>();

using var fileStream = File.OpenRead("input.txt");
using var streamReader = new StreamReader(fileStream);
string line;
while ((line = streamReader.ReadLine()) != null)
{
    var match = lineRegularExpression.Match(line);
    if (match.Success)
    {
        // the whole group is 0, and the matches are from 1
        input.Add(new List<string> { match.Groups[1].ToString(), match.Groups[2].ToString() });
    }
}

string[][] arryed = input.Select(i => i.ToArray()).ToArray();
