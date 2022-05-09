using Microsoft.Toolkit.Mvvm.ComponentModel;
using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;

namespace AIPO74_HFT_2021221.Wpf.ViewModel
{
    public class CustomerViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Models.Customer> CustomerModel { get; set; }

        public ICommand CreateCustomerButton { get; set; }
        public ICommand DeleteCustomerButton { get; set; }
        public ICommand UpdateCustomerButton { get; set; }

        private Models.Customer currentlySelectedCustomer;
        public Models.Customer CurrentlySelectedCustomer
        {
            get { return currentlySelectedCustomer; }
            set
            {

                if (value != null)
                {
                    currentlySelectedCustomer = new Models.Customer()
                    {
                        CustomerID = value.CustomerID,
                        Name = value.Name,
                        Address = value.Address,
                        Phone = value.Phone,
                        Country = value.Country,
                        City = value.City,
                        SecrecyStamp = value.SecrecyStamp
                    };
                    OnPropertyChanged();
                    (DeleteCustomerButton as RelayCommand).NotifyCanExecuteChanged();
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

        public CustomerViewModel()
        {
            if (!IsInDesignerMode)
            {
                CustomerModel = new RestCollection<Models.Customer>("http://localhost:5555/", "customer", "hub");
                CreateCustomerButton = new RelayCommand(() =>
                {
                    CustomerModel.Add(new Models.Customer()
                    {
                        City = "",
                        Country = "",
                        Name = CurrentlySelectedCustomer.Name,
                        Address = CurrentlySelectedCustomer.Address,
                        Phone = CurrentlySelectedCustomer.Phone,
                        SecrecyStamp = ""
                    });
                });
                UpdateCustomerButton = new RelayCommand(() =>
                {
                    try
                    {
                        CustomerModel.Update(CurrentlySelectedCustomer);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;

                    }

                });
                DeleteCustomerButton = new RelayCommand(() =>
                {
                    CustomerModel.Delete(CurrentlySelectedCustomer.CustomerID);
                },
                () =>
                {
                    return CurrentlySelectedCustomer != null;
                });
                CurrentlySelectedCustomer = new Models.Customer();
            }
        }
    }
}
