using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtuoso.Domain;

public class Garment
{
    public string Name { get; set; } = string.Empty;

    public Garment? DependsOn { get; set; }

    public Garment? DependentOn { get; set; }
}
