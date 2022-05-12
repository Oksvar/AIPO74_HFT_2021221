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
   public class GetServiceOrderViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private RestCollection<LaboratoryOrders> laboratoryOrders;
        public RestCollection<LaboratoryOrders> LaboratoryOrders
        {
            get { return laboratoryOrders; }
            set { SetProperty(ref laboratoryOrders, value); }
        }

        private RestCollection<ServiceWithHighestPrice> getCustomerByStaff;
        public RestCollection<ServiceWithHighestPrice> GetCustomerByStaff
        {
            get { return getCustomerByStaff; }
            set { SetProperty(ref getCustomerByStaff, value); }
        }

        private LaboratoryOrders selectedLaboratoryOrder;
        private ServiceWithHighestPrice selectedGetCustomerByStaff;

        public LaboratoryOrders SelectedLaboratoryOrder
        {
            get { return selectedLaboratoryOrder; }
            set
            {
                if (value != null)
                {
                    selectedLaboratoryOrder = new LaboratoryOrders()
                    {
                        Id = value.Id,
                        Date = value.Date,
                        CustomerID = value.CustomerID,
                        StaffID = value.StaffID,
                        ServiceId = value.ServiceId,
                    };
                    OnPropertyChanged();
                    (RunQuery as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ServiceWithHighestPrice SelectedServiceByOrder
        {
            get { return selectedGetCustomerByStaff; }
            set
            {
                if (value != null)
                {
                    selectedGetCustomerByStaff = new ServiceWithHighestPrice()
                    {
                        serviceID = value.serviceID,
                        serviceName = value.serviceName,
                        price = value.price
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

        public void GetServiceByOrderQuery(int orderId)
        {
            string url = "services/getservices/" + orderId;
            GetCustomerByStaff = new RestCollection<ServiceWithHighestPrice>("http://localhost:5555/", url, "hub");
        }

        public GetServiceOrderViewModel()
        {
            if (!IsInDesignMode)
            {
                LaboratoryOrders = new RestCollection<LaboratoryOrders>("http://localhost:5555/", "laboratoryorder", "hub");
                RunQuery = new RelayCommand(() =>
                {
                    GetServiceByOrderQuery(SelectedLaboratoryOrder.Id);
                });
                SelectedLaboratoryOrder = new LaboratoryOrders();
                SelectedServiceByOrder = new ServiceWithHighestPrice();
            }

        }
    }
}
