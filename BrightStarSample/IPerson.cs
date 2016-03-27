using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightstarDB.EntityFramework;

namespace BrightStarSample
{
    [Entity]
    public interface IPerson
    {
        [Identifier]
        string ID   { get; }
        string Name { get; set; }
        int    Age  { get; set; }
    }
}
