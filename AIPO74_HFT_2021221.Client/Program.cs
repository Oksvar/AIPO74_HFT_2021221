using System;
using System.Collections.Generic;
using AIPO74_HFT_2021221.Models;
using ConsoleTools;
namespace AIPO74_HFT_2021221.Client
{
    public static class Program
    {
        public static void Main()
        {

            RestService rest = new RestService("http://localhost:5555");
            #region ServiceMenu
            ///////////////////////ServiceMenu/////////////////////////////////////////////////////////
            var service = new ConsoleMenu()
                .Add("Create Service", () => CreateService(rest))
                .Add("Get all Services", () => GetServices(rest))
                .Add("Get service via ID", () => GetService(rest))
                .Add("Delete service", () => DeleteService(rest))
                .Add("Update service name", () => ChangeServiceName(rest))
                .Add("Update Service Price", () => ChangePriceService(rest))
                .Add("Go back to the previes menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = " --> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
                });
            #endregion
            #region CustomerMenu
            var customer = new ConsoleMenu()
              .Add("Get customer by ID", () => GetCustomer(rest))
              .Add("Get all Customers", () => GetCustomers(rest))
              .Add("Delete Customer", () => DeleteCustomer(rest))
              .Add("Create customer", () => CreateCustomer(rest))
              .Add("Change customer adress", () => UpdateCustomerAdrees(rest))
              .Add("Change customer phone", () => UpdateCustomerPhone(rest))
              .Add("Change customer secret", () => UpdateCustomerSecret(rest))
            .Add("Go back to the previes menu", ConsoleMenu.Close)
              .Configure(config =>
              {
                  config.Selector = " --> ";
                  config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
              });
            #endregion         
            #region StaffMenu
            var staff = new ConsoleMenu()
              .Add("Get Laboratory Staff by ID", () => GetStaff(rest))
              .Add("Get All Laboratory Staff", () => GetStaffs(rest))
              .Add("Delete Laboratory Staff", () => DeleteStaff(rest))
              .Add("Create Laboratory Staff", () => CreateStaff(rest))
              .Add("Change Staff position", () => UpdateStaffPosition(rest))
              .Add("Change Staff Access Level", () => UpdateAccessLevelStaff(rest))
               .Add("Go back to the previes menu", ConsoleMenu.Close)
              .Configure(config =>
              {
                  config.Selector = " --> ";
                  config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
              });
            #endregion
            #region OrderMenu
            var orders = new ConsoleMenu()
             .Add("Get order by ID", () => GetOrder(rest))
             .Add("Get All orders", () => GetOrders(rest))
             .Add("Create Order", () => CreateOrder(rest))
             .Add("Delete Order", () => DeleteOrder(rest))
              .Add("Go back to the previes menu", ConsoleMenu.Close)
             .Configure(config =>
             {
                 config.Selector = " --> ";
                 config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
             });
            #endregion
            #region MainMenu
            var crud = new ConsoleMenu()
               .Add("Services", () => service.Show())
               .Add("Customer", () => customer.Show())
               .Add("Laboratory Staff", () => staff.Show())
               .Add("Laboratory Orders", () => orders.Show())
               .Add("Go back to previous menu", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.Title = "Cruds menu";
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });

            var noncrud = new ConsoleMenu()
                .Add("1.Get Customer by order ID", () => GetCustomerByID(rest))
                .Add("2.Get All information about order", () => GetAllInfoOrder(rest))
                .Add("3.Get service information by order", () => GetServiceByOrderID(rest))
                .Add("Go back to previous menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "-->";
                    config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
                });
            
            var menu = new ConsoleMenu()
                 .Add("CRUD METHODS", () => crud.Show())
                 .Add("NON-CRUD METHODS", () => noncrud.Show())
                 .Add("Exit from the application", ConsoleMenu.Close)
                 .Configure(config =>
                 {
                     config.Selector = "--> ";
                     config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
                     config.EnableFilter = true;
                     config.Title = "Main menu";
                     config.EnableWriteTitle = true;
                 });
            menu.Show();
            #endregion

            /////////////////////////////////////////////////////////////////
        }

        #region NonCrud
        private static void GetCustomerByID(RestService rest)
        {
            Console.WriteLine("Here is order list:");
            GetOrders(rest);
            Console.WriteLine("Pick Order ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Result:");
            var cust = rest.Get<GetCustomerByStaff>("Customer", "getcustomerbyorder", id);
            cust.ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
        private static void GetAllInfoOrder(RestService rest)
        {
            Console.WriteLine("Here is order list:");
            GetOrders(rest);
            Console.WriteLine("Pick Order ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Result:");
            var cust = rest.Get<AlIinformationAboutOrder>("LaboratoryOrder", "allinfoorder", id);
            cust.ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
        private static void GetServiceByOrderID(RestService rest)
        {
            Console.WriteLine("Here is order list:");
            GetOrders(rest);
            Console.WriteLine("Pick one Order ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Result:");
            var cust = rest.Get<ServiceWithHighestPrice>("Services", "getservices", id);
            cust.ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
        

        #endregion
        #region ServiceCrud
        private static void CreateService(RestService rest)
        {
            Console.WriteLine("Creat new service");
            Console.WriteLine("\n Give the name of service");
            string name = Console.ReadLine();
            Console.WriteLine("\n Give the price of service");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("\n Give the development time (in days)");
            int devtime = int.Parse(Console.ReadLine());
            Console.WriteLine("\n Give the Dangerous of the service(from 1 to 10)");
            int dangerouse = int.Parse(Console.ReadLine());
            rest.Post(new Services
            {
                Name = name,
                Price = price,
                DevelopmentTime = devtime,
                Dangerous = dangerouse
            }, "Services");
            Console.WriteLine("Service is created");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadKey();
        }

        private static void GetServices(RestService rest)
        {
            try
            {
                Console.WriteLine(".....List all services.....");
                var serv = rest.Get<Services>("Services");
                serv.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("\n Press enter to continue");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        private static void GetService(RestService rest)
        {
            Console.WriteLine("Plese enter an id");
            int id = int.Parse(Console.ReadLine());
            var serv = rest.Get<Services>(id, "Services");
            Console.WriteLine(serv.ToString());
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }

        private static void DeleteService(RestService rest)
        {
            Console.WriteLine("--Write in console the service ID which you want to delete");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "Services");
            Console.WriteLine("This service was deleted from database");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }
        private static void ChangeServiceName(RestService rest)
        {
            try
            {
                Console.WriteLine("--Write Service Id which you want to change");
                int id = int.Parse(Console.ReadLine());
                Services services = rest.Get<Services>(id, "Services");
                Console.WriteLine("\n Write new Service name");
                string newName = Console.ReadLine();
                services.Name = newName;
                rest.Put(services, "Services");
                Console.WriteLine("The service has been renamed");
                Console.WriteLine("\n Press enter to coninue");
                Console.ReadLine();
            }
            catch(System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }

        private static void ChangePriceService(RestService rest)
        {
            Console.WriteLine("--Write Service Id which you want to change");
            int id = int.Parse(Console.ReadLine());
            Services services = rest.Get<Services>(id, "Services");
            Console.WriteLine("\n Give the new price for teh service");
            services.Price = int.Parse(Console.ReadLine());
            rest.Put(services, "Services", "updateprice");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }
        #endregion
        #region CustomerCrud
        private static void GetCustomer(RestService rest)
        {
            Console.WriteLine("Plese enter an id");
            int id = int.Parse(Console.ReadLine());
            var customer = rest.Get<Customer>(id, "Customer");
            Console.WriteLine(customer.ToString());
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }

        private static void GetCustomers(RestService rest)
        {
            try
            {
                Console.WriteLine("--List All Customers");
                var customers = rest.Get<Customer>("Customer");
                customers.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("\n Press enter to continue");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        private static void DeleteCustomer(RestService rest)
        {
            Console.WriteLine("--Write in console the customer ID which you want to delete");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "Customer");
            Console.WriteLine("This customer was deleted from database");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }

        private static void CreateCustomer(RestService rest)
        {
            Console.WriteLine("Creat new Customer");
            Console.WriteLine("\n Give Full customer name");
            string name = Console.ReadLine();
            Console.WriteLine("\n Give the customer address");
            string adress = Console.ReadLine();
            Console.WriteLine("\n Give customer phone number");
            string phone = Console.ReadLine();
            Console.WriteLine("\n Give customer city");
            string City = Console.ReadLine();
            Console.WriteLine("\n Give customer country");
            string country = Console.ReadLine();
            Console.WriteLine("\n Give customer Secrecy Stamp (From highest to lowest)");
            string secrstamp = Console.ReadLine();
            rest.Post(new Customer
            {
                Name = name,
                Address = adress,
                Phone = phone,
                City = City,
                Country = country,
                SecrecyStamp = secrstamp
            }, "Customer");
            Console.WriteLine("Customer is created");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadKey();
        }

        private static void UpdateCustomerAdrees(RestService rest)
        {
            Console.WriteLine("--Write Customer Id which you want to change");
            int id = int.Parse(Console.ReadLine());
            Customer customer = rest.Get<Customer>(id, "Customer");
            Console.WriteLine("\n Give the new adress for the customer");
            customer.Address = Console.ReadLine();
            rest.Put(customer, "Customer");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }
        private static void UpdateCustomerPhone(RestService rest)
        {
            Console.WriteLine("--Write Customer Id which you want to change");
            int id = int.Parse(Console.ReadLine());
            Customer customer = rest.Get<Customer>(id, "Customer");
            Console.WriteLine("\n Give the new Phone for the customer");
            customer.Phone = Console.ReadLine();
            rest.Put(customer, "Customer", "changephone");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }
        private static void UpdateCustomerSecret(RestService rest)
        {
            Console.WriteLine("--Write Customer Id which you want to change");
            int id = int.Parse(Console.ReadLine());
            Customer customer = rest.Get<Customer>(id, "Customer");
            Console.WriteLine("\n Write new secret stamp for the customer (From Top secret to low)");
            customer.SecrecyStamp = Console.ReadLine();
            rest.Put(customer, "Customer", "changesecret");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }
        #endregion
        #region StaffCrud
        private static void GetStaff(RestService rest)
        {
            Console.WriteLine("Plese enter staff ID");
            int id = int.Parse(Console.ReadLine());
            var staff = rest.Get<LaboratoryStaff>(id, "LaboratoryStaff");
            Console.WriteLine(staff.ToString());
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }
        private static void GetStaffs(RestService rest)
        {
            try
            {
                Console.WriteLine("--List All Laboratory Staff");
                var staff = rest.Get<LaboratoryStaff>("LaboratoryStaff");
                staff.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("\n Press enter to continue");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        private static void DeleteStaff(RestService rest)
        {
            Console.WriteLine("--Write in console the staff ID which you want to delete");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "LaboratoryStaff");
            Console.WriteLine("This staff was deleted from database");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }
        private static void CreateStaff(RestService rest)
        {
            Console.WriteLine("Creat new service");
            Console.WriteLine("\n Give the Full Name of Staff");
            string name = Console.ReadLine();
            Console.WriteLine("\n Give the position of staff");
            string Position = Console.ReadLine();
            Console.WriteLine("\n Give the Access level (A,B,C,D)");
            string level = Console.ReadLine();
            Console.WriteLine("\n Give the Year expirience for Staff");
            int expyear = int.Parse(Console.ReadLine());
            rest.Post(new LaboratoryStaff
            {
               FullName = name,
               Position = Position,
               AccessLevel = level,
               YearExpirience = expyear
            }, "LaboratoryStaff");
            Console.WriteLine("Service is created");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadKey();
        }
        private static void UpdateStaffPosition(RestService rest)
        {
            try
            {
                Console.WriteLine("--Write Staff Id which you want to change");
                int id = int.Parse(Console.ReadLine());
                LaboratoryStaff staff = rest.Get<LaboratoryStaff>(id, "LaboratoryStaff");
                Console.WriteLine("\n Write new staff position name");
                string newPos = Console.ReadLine();
                staff.Position = newPos;
                rest.Put(staff, "LaboratoryStaff");
                Console.WriteLine("The staff position has been renamed");
                Console.WriteLine("\n Press enter to coninue");
                Console.ReadLine();
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }
        private static void UpdateAccessLevelStaff(RestService rest)
        {
            try
            {
                Console.WriteLine("--Write Staff Id which you want to change");
                int id = int.Parse(Console.ReadLine());
                LaboratoryStaff staff = rest.Get<LaboratoryStaff>(id, "LaboratoryStaff");
                Console.WriteLine("\n Write new staff Access Level (A,B,C,D)");
                string newPos = Console.ReadLine();
                staff.AccessLevel = newPos;
                rest.Put(staff, "LaboratoryStaff", "updateaccesslevel");
                Console.WriteLine("The staff Access Level has been renamed");
                Console.WriteLine("\n Press enter to coninue");
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
        #region OrdersCrud
        private static void GetOrder(RestService rest)
        {
            Console.WriteLine("Plese enter an id");
            int id = int.Parse(Console.ReadLine());
            var order = rest.Get<LaboratoryOrders>(id, "LaboratoryOrder");
            Console.WriteLine(order.ToString());
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }
        private static void GetOrders(RestService rest)
        {
            try
            {
                Console.WriteLine("List All Orders");
                var ord = rest.Get<LaboratoryOrders>("LaboratoryOrder");
                ord.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("\n Press enter to continue");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        private static void CreateOrder(RestService rest)
        {
            Console.WriteLine("Creat new Order");
            Console.WriteLine("\n Give the Order Date");
            DateTime dat = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("\n Write Customer ID");
            int customerID = int.Parse(Console.ReadLine());
            Console.WriteLine("\n Write serviceID");
            int serviceID = int.Parse(Console.ReadLine());
            Console.WriteLine("\n Write Staff ID");
            int staffID = int.Parse(Console.ReadLine());
            rest.Post(new LaboratoryOrders
            {
                Date = dat,
                CustomerID = customerID,
                ServiceId = serviceID,
                StaffID = staffID
                
            }, "LaboratoryOrder");
            Console.WriteLine("Order is created");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadKey();
        }

        private static void DeleteOrder(RestService rest)
        {
            Console.WriteLine("Write in console the Order ID which you want to delete");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "LaboratoryOrder");
            Console.WriteLine("This order was deleted from database");
            Console.WriteLine("\n Press enter to continue");
            Console.ReadLine();
        }
        #endregion
    }
}
