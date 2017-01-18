using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMWpfApplication
{
    public interface IErrorViewModel
    {
        string Title { set; }
        string Details { set; }
        string ErrorMessage { set; }
        string Solution { set; }
    }

}
