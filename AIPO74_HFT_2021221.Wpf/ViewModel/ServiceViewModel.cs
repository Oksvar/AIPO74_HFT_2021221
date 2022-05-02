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
   public class ServiceViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
       
        public RestCollection<Services> ServiceModel { get; set; }

        public ICommand CreateServiceButton { get; set; }
        public ICommand DeleteServiceButton { get; set; }
        public ICommand UpdateServiceButton { get; set; }

        private Services currentlySeelctedService;
        public Services CurrentlySeelctedService
        {
            get { return currentlySeelctedService; }
            set
            {
                
                if (value != null)
                {
                    currentlySeelctedService = new Services()
                    {
                        Name = value.Name,
                        Price = value.Price,
                        DevelopmentTime = value.DevelopmentTime,
                        Dangerous = value.Dangerous
                    };
                    OnPropertyChanged();
                    (DeleteServiceButton as RelayCommand).NotifyCanExecuteChanged();
                }

            }

        }
        public static bool IsInDesignerMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ServiceViewModel()
        {
                
        }

    }
}
