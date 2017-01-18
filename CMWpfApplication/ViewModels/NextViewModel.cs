using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CMWpfApplication
{
    public class NextViewModel : ViewModelBaseEx, INextViewModel
    {
        public NextViewModel(){
            Name = "new win";
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
    }
}
