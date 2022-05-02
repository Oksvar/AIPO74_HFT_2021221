using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AIPO74_HFT_2021221.Wpf
{
   public class MainWindowViewModel : ObservableRecipient
    {
       
        public RelayCommand ServiceCommand { get; set; }
        public RelayCommand CustomerCommand { get; set; }
        public RelayCommand StaffCommand { get; set; }
        public RelayCommand NonCrudCommand { get; set; }

        public MainWindowViewModel()
        {
            ServiceCommand = new RelayCommand(NewServiceWinodw);
            CustomerCommand = new RelayCommand(NewCustomerWindow);
            StaffCommand = new RelayCommand(NewStaffWindow);
            
        }
        private void NewServiceWinodw()
        {
            new Service().Show();
        }
        private void NewStaffWindow()
        {
            new Staff().Show();
        }
        private void NewCustomerWindow()
        {
            new Customer().Show();
        }
       // public RestCollection<Service> services { get; set; }

    }
}
