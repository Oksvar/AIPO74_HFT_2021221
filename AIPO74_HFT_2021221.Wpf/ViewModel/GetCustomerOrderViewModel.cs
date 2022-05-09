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
  public class GetCustomerOrderViewModel : ObservableRecipient
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

        private RestCollection<GetCustomerByStaff> getCustomerByStaff;
        public RestCollection<GetCustomerByStaff> GetCustomerByStaff
        {
            get { return getCustomerByStaff; }
            set { SetProperty(ref getCustomerByStaff, value); }
        }

        private LaboratoryOrders selectedLaboratoryOrder;
        private GetCustomerByStaff selectedGetCustomerByStaff;

        public LaboratoryOrders SelectedLaboratoryOrder
        {
            get { return selectedLaboratoryOrder; }
            set
            {
                if (value != null)
                {
                    selectedLaboratoryOrder = new LaboratoryOrders()
                    {
                        Date = value.Date,
                        CustomerID = value.CustomerID,
                        StaffID = value.StaffID,
                        ServiceId = value.ServiceId,
                        Services = value.Services,
                        LaboratoryStaff = value.LaboratoryStaff,
                        Customers = value.Customers
                    };
                    OnPropertyChanged();
                    (RunQuery as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public GetCustomerByStaff SelectedGetCustomerByStaff
        {
            get { return selectedGetCustomerByStaff; }
            set
            {
                if (value != null)
                {
                    selectedGetCustomerByStaff = new GetCustomerByStaff()
                    {
                        orderId = value.orderId,
                        CustomerFullName = value.CustomerFullName
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

        public void GetCustomerByStaffQuery(int orderId)
        {
            string url = "customer/getcustomerbyorder/" + orderId;
            GetCustomerByStaff = new RestCollection<GetCustomerByStaff>("http://localhost:5555/", url, "hub");
        }

        public GetCustomerOrderViewModel()
        {
            if (!IsInDesignMode)
            {
                LaboratoryOrders = new RestCollection<LaboratoryOrders>("http://localhost:5555/", "laboratoryorder", "hub");
                RunQuery = new RelayCommand(() =>
                {
                    GetCustomerByStaffQuery(SelectedLaboratoryOrder.Id);
                });
                SelectedLaboratoryOrder = new LaboratoryOrders();
                SelectedGetCustomerByStaff = new GetCustomerByStaff();
            }

        }
    }
}
