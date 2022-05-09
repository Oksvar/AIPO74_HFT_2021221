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
    public class StaffViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<LaboratoryStaff> StaffModel { get; set; }

        public ICommand CreateStaffButton { get; set; }
        public ICommand DeleteStaffButton { get; set; }
        public ICommand UpdateStaffButton { get; set; }

        private LaboratoryStaff currentlySelectedStaff;
        public LaboratoryStaff CurrentlySelectedStaff
        {
            get { return currentlySelectedStaff; }
            set
            {

                if (value != null)
                {
                    currentlySelectedStaff = new LaboratoryStaff()
                    {
                        StaffID = value.StaffID,
                        FullName = value.FullName,
                        Position = value.Position,
                        AccessLevel = value.AccessLevel,
                        YearExpirience = value.YearExpirience
                    };
                    OnPropertyChanged();
                    (DeleteStaffButton as RelayCommand).NotifyCanExecuteChanged();
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

        public StaffViewModel()
        {
            if (!IsInDesignerMode)
            {
                StaffModel = new RestCollection<LaboratoryStaff>("http://localhost:5555/", "laboratorystaff", "hub");
                CreateStaffButton = new RelayCommand(() =>
                {
                    StaffModel.Add(new LaboratoryStaff()
                    {
                        FullName = CurrentlySelectedStaff.FullName,
                        Position = CurrentlySelectedStaff.Position,
                        AccessLevel = CurrentlySelectedStaff.AccessLevel,
                        YearExpirience = CurrentlySelectedStaff.YearExpirience
                    });
                });
                UpdateStaffButton = new RelayCommand(() =>
                {
                    try
                    {
                        StaffModel.Update(CurrentlySelectedStaff);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;

                    }

                });
                DeleteStaffButton = new RelayCommand(() =>
                {
                    StaffModel.Delete(CurrentlySelectedStaff.StaffID);
                },
                () =>
                {
                    return CurrentlySelectedStaff != null;
                });

            }
        }
    }
}
