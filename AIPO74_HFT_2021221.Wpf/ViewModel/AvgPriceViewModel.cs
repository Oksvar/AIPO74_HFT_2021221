using AIPO74_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AIPO74_HFT_2021221.Wpf.ViewModel
{
    public class AvgPriceViewModel : ObservableRecipient
    {
        private static HttpClient client = new HttpClient();

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private ObservableCollection<Services> getAvgPrice = new ObservableCollection<Services>();
        public ObservableCollection<Services> GetAvgPrice
        {
            get { return getAvgPrice; }
            set { SetProperty(ref getAvgPrice, value); }
        }

        private Services selAvgPrice;

        public Services SelAvgPrice
        {
            get { return selAvgPrice; }
            set
            {
                if (value != null)
                {
                    selAvgPrice = new Services()
                    {
                        ServiceId = value.ServiceId,
                        Name = value.Name,
                        Price = value.Price,
                        DevelopmentTime = value.DevelopmentTime,
                        Dangerous = value.Dangerous
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

        public async Task GetAvgPriceQuery()
        {
            string url = "services/AVGprice/";
            //GetAvgPrice = new ObservableCollection<Services>("http://localhost:5555/", url, "hub");

            HttpResponseMessage response = await client.GetAsync(@"http://localhost:5555/" + url);
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsAsync<Services>();
                GetAvgPrice.Clear();
                GetAvgPrice.Add(item);
            }
            else
            {
                var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
                throw new ArgumentException(error.Msg);
            }
        }

        public AvgPriceViewModel()
        {
            if (!IsInDesignMode)
            {
                RunQuery = new RelayCommand(() =>
                {
                    //GetAvgPriceQuery();
                    Application.Current.Dispatcher.Invoke(() => GetAvgPriceQuery());
                });
                SelAvgPrice = new Services();
            }

        }
    }
}
