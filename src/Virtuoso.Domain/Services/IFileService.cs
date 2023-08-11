using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtuoso.Domain.Services;

public interface IFileService
{
    public List<string[]> GetInput(string path);
}
