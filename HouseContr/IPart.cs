using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseContr
{
    interface IPart
    {
        bool Status { get; set; }
        string ShowPart();
    }
}
