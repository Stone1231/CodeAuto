using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMWpfApplication
{
    public class TestDataGridViewModel : ViewModelBaseEx, ITestDataGridViewModel
    {
        //public IList<TestModel> List { get; set; }
        //IList<TestModel> _List;
        //public IList<TestModel> List {
        //    get {
        //        return _List;
        //    }
        //    set {
        //        _List = value;
        //        this.NotifyOfPropertyChange(() => List);
        //    }
        //}

        IList<TestModel> List;
        ObservableCollection<TestModel> _ObCollection;
        public ObservableCollection<TestModel> ObCollection
        {
            get
            {
                return _ObCollection;

            }
            set
            {
                _ObCollection = value;
                this.NotifyOfPropertyChange(() => ObCollection);
            }
        }

        public IList<SelectListItem> ComboBoxList { get; set; }
        
        public TestDataGridViewModel()
        {
            List = new List<TestModel>() {
                new TestModel { Name = "name1", Text = "text1", SelectValue="select1" },
                new TestModel { Name = "name2", Text = "text2", SelectValue="select1" }
                };
            ObCollection = new ObservableCollection<TestModel>(List);


            ComboBoxList = new List<SelectListItem>() {
                new SelectListItem { Value = "value1", Text = "select1" },
                new SelectListItem { Value = "value2", Text = "select2" }
                };
        }

        public void ReadData(TestModel model) {
            model.Text = DateTime.Now.Second.ToString();
        }

        public void DeleteData(TestModel model)
        {
            List.Remove(model);
            ObCollection = new ObservableCollection<TestModel>(List);
        }

        public void AddData()
        {
            List.Add(new TestModel { Name = "NewName", SelectValue = "select1", Text = "NewText" });
            ObCollection = new ObservableCollection<TestModel>(List);
        }


            //        cal:Message.Attach="[Event Click] = [Action DeleteFileCloud($dataContext)]"

            //        cal:Message.Attach="[Event Drop] = [Action AddFileCloud($eventArgs)]"
            //        public async void AddFileCloud(DragEventArgs e)
            //        {
            //            if (e.Data.GetDataPresent(DataFormats.FileDrop))

            //                cm: Message.Attach = "[Event KeyUp] = [Action txtWriteMessage_KeyDown($executionContext)]"
            //        public void txtWriteMessage_KeyDown(ActionExecutionContext context)
            //        {
            //            var keyArgs = context.EventArgs as KeyEventArgs;
            //            if (keyArgs != null && keyArgs.Key == Key.Enter)

            //                cm: Message.Attach = "[Event MouseLeftButtonDown] = [Action chatViewWindow_Click_FlowDoc($source,$eventArgs)]"
            //        cm: Message.Attach = "[Event SizeChanged] = [Action WindowSizeChanged($source)]"
            //        public void ChangeComboBox(object sender, string type)
            //        {
            //            System.Windows.Controls.ComboBox comboBox = sender as System.Windows.Controls.ComboBox;

        }
}
