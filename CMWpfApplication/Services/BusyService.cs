using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace CMWpfApplication
{
    internal class BusyService
    {
        public static BusyView Busy { get; set; }
        private static bool isbusy = false;
        public static bool IsBusy { get { return isbusy; } set { isbusy = value; } }
        private static Thread thread { get; set; }
        private static Window view { get; set; }
        
        private static double Top { get; set; }
        private static double Left { get; set; }
        private static double Height { get; set; }
        private static double Width { get; set; }

        public static void Show(Window view)
        {
            BusyService.view = view;
            IsBusy = true;
            Top = view.Top;
            Left = view.Left;
            Height = view.Height;
            Width = view.Width;
            if (view.DataContext.ToString().Contains("Chat"))
            {
                Top = view.Top + 82;
                Height = view.Height - 82;
            }
            if (view.DataContext.ToString().Contains("Main"))
            {
                Top = view.Top + 100;
                Height = view.Height - 100;
            }


            BusyService.thread = new Thread(
               new System.Threading.ThreadStart(
                   delegate()
                   {
                       BusyService.Busy = new BusyView();
                       BusyService.Busy.Height = BusyService.Height;
                       BusyService.Busy.Width = BusyService.Width;
                       BusyService.Busy.Top = BusyService.Top;
                       BusyService.Busy.Left = BusyService.Left;
                       BusyService.Busy.Topmost = true;
                       BusyService.Busy.Topmost = false;
                       //BusyService.Busy.Opacity = 1;

                       if (BusyService.Busy != null)
                           BusyService.Busy.ShowDialog();
                       //System.Windows.Threading.Dispatcher.Run();
                   }
               ));
            BusyService.thread.SetApartmentState(ApartmentState.STA);
            BusyService.thread.Start();            
        }

        public static void Show()
        {
            if (BusyService.Busy != null)
            {
                BusyService.Busy.Show();
            }
        }

        public static void Close()
        {
            if (BusyService.Busy == null) return;
            if (!BusyService.Busy.Dispatcher.CheckAccess())
            {
                if (BusyService.IsBusy == false) return;
                BusyService.IsBusy = false;

                thread = new Thread(
                    new System.Threading.ThreadStart(
                        delegate()
                        {
                            BusyService.Busy.Dispatcher.Invoke(
                                DispatcherPriority.Normal,
                                new Action(delegate()
                                {
                                    try
                                    {
                                        //Thread.Sleep(500);
                                        BusyService.Close();
                                    }
                                    catch (Exception)
                                    {                                        
                                    }
                                }
                            ));
                        }
                ));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                BusyService.Busy.Hide();
            }

        }
    }
}