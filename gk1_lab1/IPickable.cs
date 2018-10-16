using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gk1_lab1
{
    interface IPickable
    {
        bool isVertex();
        Color Color { get; }
    }
}
