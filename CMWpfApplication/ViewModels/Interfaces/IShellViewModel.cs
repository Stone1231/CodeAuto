using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMWpfApplication
{
    interface IShellViewModel
    {
        string Name { get; set; }

        void SayHello();

        void ToNext();
    }
}
