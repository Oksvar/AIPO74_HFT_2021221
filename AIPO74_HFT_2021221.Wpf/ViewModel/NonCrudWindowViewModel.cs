using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Wpf.ViewModel
{
   public class NonCrudWindowViewModel : ObservableRecipient
    {
        public RelayCommand NC1Command { get; set; }
        public RelayCommand NC2Command { get; set; }
        public RelayCommand NC3Command { get; set; }
        public RelayCommand NC4Command { get; set; }
        public RelayCommand NC5Command { get; set; }

        public NonCrudWindowViewModel()
        {
            NC1Command = new RelayCommand(InitializeNC1Window);
            NC2Command = new RelayCommand(InitializeNC2Window);
            NC3Command = new RelayCommand(InitializeNC3Window);
            NC4Command = new RelayCommand(InitializeNC4Window);
            NC5Command = new RelayCommand(InitializeNC5Window);
        }

        private void InitializeNC1Window()
        {
            new GetCustomerOrder().Show();
        }
        private void InitializeNC2Window()
        {
            new GetAllInformationOrder().Show();
        }
        private void InitializeNC3Window()
        {
            new GetServiceOrder().Show();
        }
        private void InitializeNC4Window()
        {
            new GetDangerousMore7().Show();
        }
        private void InitializeNC5Window()
        {
            new AvgPrice().Show();
        }
    }
}
