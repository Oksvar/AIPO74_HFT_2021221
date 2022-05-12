using AIPO74_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AIPO74_HFT_2021221.Wpf.ViewModel
{
   public class getDangerous7ViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private RestCollection<DangerousList> getDangerousList;
        public RestCollection<DangerousList> GetDangerousList
        {
            get { return getDangerousList; }
            set { SetProperty(ref getDangerousList, value); }
        }

        private DangerousList selDangerousList;

        public DangerousList SelDangerousList
        {
            get { return selDangerousList; }
            set
            {
                if (value != null)
                {
                    selDangerousList = new DangerousList()
                    {
                        Dangerous = value.Dangerous,
                        ServiceName = value.ServiceName,
                        orderID = value.orderID
                    };
                    OnPropertyChanged();
                    (RunQuery as RelayCommand).NotifyCanExecuteChanged();
                }
                else
                {
                    OnPropertyChanged();
                    (RunQuery as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand RunQuery { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public void GetDangerousServices()
        {
            string url = "services/getDangerous/";
            GetDangerousList = new RestCollection<DangerousList>("http://localhost:5555/", url, "hub");
        }

        public getDangerous7ViewModel()
        {
            if (!IsInDesignMode)
            {
                RunQuery = new RelayCommand(() =>
                {
                    GetDangerousServices();
                });
                SelDangerousList = new DangerousList();
            }

        }
    }
}
