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
    public class GetAllInformationOrderViewModel : ObservableRecipient
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

        private RestCollection<AlIinformationAboutOrder> getAlIinformationAboutOrder;
        public RestCollection<AlIinformationAboutOrder> GetAlIinformationAboutOrder
        {
            get { return getAlIinformationAboutOrder; }
            set { SetProperty(ref getAlIinformationAboutOrder, value); }
        }

        private LaboratoryOrders selectedLaboratoryOrder;
        private AlIinformationAboutOrder selectedAlIinformationAboutOrder;

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

        public AlIinformationAboutOrder SelectedAlIinformationAboutOrder
        {
            get { return selectedAlIinformationAboutOrder; }
            set
            {
                if (value != null)
                {
                    selectedAlIinformationAboutOrder = new AlIinformationAboutOrder()
                    {
                        orderId = value.orderId,
                        CustomerName = value.CustomerName,
                        ServiceName=value.ServiceName,
                        Price=value.Price,
                        StaffName=value.StaffName,
                        positionname=value.positionname
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

        public void GetAlIinformationAboutOrderQuery(int orderId)
        {
            string url = "LaboratoryOrder/allinfoorder/" + orderId;
            GetAlIinformationAboutOrder = new RestCollection<AlIinformationAboutOrder>("http://localhost:5555/", url, "hub");
        }

        public GetAllInformationOrderViewModel()
        {
            if (!IsInDesignMode)
            {
                LaboratoryOrders = new RestCollection<LaboratoryOrders>("http://localhost:5555/", "laboratoryorder", "hub");
                RunQuery = new RelayCommand(() =>
                {
                    GetAlIinformationAboutOrderQuery(SelectedLaboratoryOrder.Id);
                });
                SelectedLaboratoryOrder = new LaboratoryOrders();
                SelectedAlIinformationAboutOrder = new AlIinformationAboutOrder();
            }

        }
    }
}
