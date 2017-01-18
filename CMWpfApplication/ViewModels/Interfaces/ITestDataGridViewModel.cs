using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CMWpfApplication
{
    interface ITestDataGridViewModel
    {
        //IList<TestModel> List { get; set; }
        ObservableCollection<TestModel> ObCollection { get; set; }

        IList<SelectListItem> ComboBoxList { get; set; }
    }
}
