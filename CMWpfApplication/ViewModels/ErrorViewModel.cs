
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CMWpfApplication
{
    public class ErrorViewModel : ViewModelBaseEx, IErrorViewModel
    {
        #region Constants and Fields
               
        private string details;

        private string errorMessage;

        private string solution;

        #endregion

        #region Constructors and Destructors
        public ErrorViewModel()
        {
            this.Title = "Error";
            this.ErrorMessage = "An Unknown Error has occured.";
            this.Details = "There is no further information available about this error.";
        }
        #endregion

        #region Properties

        public string Details
        {
            get
            {
                return string.IsNullOrEmpty(this.details) ? "There is no further information available about this error." : this.details;
            }

            set
            {
                this.details = value;
                this.NotifyOfPropertyChange(() => Details);                
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }

            set
            {
                this.errorMessage = value;
                this.NotifyOfPropertyChange(() => ErrorMessage);         
            }
        }

        public string Solution
        {
            get
            {
                return string.IsNullOrEmpty(this.solution) ? "If the problem presists, please try restarting HandBrake." : this.solution;
            }

            set
            {
                this.solution = value;
                this.NotifyOfPropertyChange(() => Solution);    
            }
        }

        #endregion

        public void Close()
        {
            try
            {
                this.TryClose();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }

        public void Copy()
        {
            Clipboard.SetDataObject(this.ErrorMessage + Environment.NewLine + this.Details, true);
        }
    }
}
