using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenBlazorComponents
{
    static class SvgHelpers
    {
        internal static string Coord(double d) => d.ToString(CultureInfo.InvariantCulture);
    }
}
