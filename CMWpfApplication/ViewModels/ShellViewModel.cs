using Caliburn.Micro;
using System;
using System.Windows;

namespace CMWpfApplication
{
    public class ShellViewModel : ViewModelBaseEx, IShellViewModel
    {
        public ShellViewModel()
        {
            this.Title = "ShellViewModel";
            Name = "Hello CM's World!";
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

        public void SayHello()
        {
            System.Windows.MessageBox.Show(string.Format("Hello {0}!", Name));
        }

        public void TestError()
        {
            CallErrorView("CallErrorView");
        }

        public void TestBusy()
        {
            var view = this.GetView() as Window;
            BusyService.Show(view);

            System.Threading.Thread.Sleep(2000);

            BusyService.Close();
        }

        public void ToNext() {
            var vmodel = IoC.Get<INextViewModel>();
            this.WindowManager.ShowWindow(vmodel);
            
            var view = this.GetView() as Window;
            view.Hide();
        }
    }
}
