using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace CMWpfApplication
{
    public class ViewModelBaseEx : Screen
    {
        #region Constants and Fields
 
        private string title;
        private bool viewLoaded;      

        #endregion

        #region Constructors and Destructors

        public ViewModelBaseEx()
        {
            this.Activated -= ViewModelBaseExActivated;
            this.Activated += ViewModelBaseExActivated;
        }

        void ViewModelBaseExActivated(object sender, ActivationEventArgs e)
        {
            var view = this.GetView() as System.Windows.Window;
            //view.ContentRendered -= ContentRendered;
            //view.ContentRendered += ContentRendered;

            view.IsVisibleChanged -= ViewModelBaseExIsVisibleChanged;
            view.IsVisibleChanged += ViewModelBaseExIsVisibleChanged;

        }

        protected override void OnInitialize()
        {
            this.WindowView = (this.GetView() as System.Windows.Window);
            base.OnInitialize();
        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            viewLoaded = true;
            BusyService.Close();
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }

        void ContentRendered(object sender, EventArgs e)
        {
            if (viewLoaded) BusyService.Close();
        }

        void ViewModelBaseExIsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (viewLoaded) BusyService.Close();
        }

        #endregion

        #region Properties
        
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
                this.NotifyOfPropertyChange(()=>Title);
            }
        }

        public System.Windows.Window WindowView { get; set; }
     
        public IWindowManager WindowManager { get; set; }
                
        #endregion

        #region Public Methods

        public void CallErrorView(string errormsg)
        {
            var vm = IoC.Get<IErrorViewModel>();
            var win = (vm as ErrorViewModel).GetView() as System.Windows.Window;
            vm.Title = this.DisplayName;
            vm.ErrorMessage = Title + " Error!";
            vm.Details = errormsg;

            var view = this.GetView() as System.Windows.Window;
            dynamic settings = new System.Dynamic.ExpandoObject();
            settings.Left = view.Left;
            settings.Top = view.Top;

            if (win != null)
                win.Show();

            this.WindowManager.ShowDialog(vm, null, settings);
        }

        #endregion
    }
}
