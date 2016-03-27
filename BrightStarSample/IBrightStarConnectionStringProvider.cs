using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightStarSample
{
    public interface IBrightStarConnectionStringProvider
    {
        string GetConnectionString();
    }
}
