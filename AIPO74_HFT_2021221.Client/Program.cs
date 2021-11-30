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



            RestService rest = new RestService("http://localhost:5000");

            /////////////////////////ServiceMenu/////////////////////////////////////////////////////////
            //var service = new ConsoleMenu()
            //    .Add("Create Service", () => CreateService(rest))
            //    .Add("Get Service", () => GetService(rest))
            //    .Add("Go back to the previes menu", ConsoleMenu.Close)
            //    .Configure(config =>
            //    {
            //        config.Selector = " --> ";
            //        config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
            //    });
            //////////////////////////////////CrudMenu//////////////////////////////////////////
            //var crud = new ConsoleMenu()
            //   .Add("Services", () => service.Show())

            //   .Add("Go back to previous menu", ConsoleMenu.Close)
            //   .Configure(config =>
            //   {
            //       config.Selector = "--> ";
            //       config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
            //   });

            ////ConsoleMenu////////////////////////////////////////////////////
            //var menu = new ConsoleMenu()
            //     .Add("CRUD METHODS", () => crud.Show())
            //     // .Add("NON-CRUD METHODS", () => noncrud.Show())
            //     .Add("Exit from the application", ConsoleMenu.Close)
            //     //.Add("NON-CRUD METHODS", ()=> crud.Show())
            //     .Configure(config =>
            //     {
            //         config.Selector = "--> ";
            //         config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
            //         config.EnableFilter = true;
            //         config.Title = "Main menu";
            //         config.EnableWriteTitle = true;
            //         config.EnableBreadcrumb = true;
            //     });
            //menu.Show();
            /////////////////////////////////////////////////////////////////////
        }
        //private static void CreateService(RestService rest)
        //{
        //    Console.WriteLine(".....Creating new service.....");
        //    Console.WriteLine("\n Give the name of service");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("\n Give the price of service");
        //    int price = int.Parse(Console.ReadLine());
        //    Console.WriteLine("\n Give the development time (in days)");
        //    int devtime = int.Parse(Console.ReadLine());
        //    Console.WriteLine("\n Give the Dangerous of the service(from 1 to 10)");
        //    int dangerouse = int.Parse(Console.ReadLine());
        //    rest.Post(new Services
        //    {
        //        Name = name,
        //        Price = price,
        //        DevelopmentTime = devtime,
        //        Dangerous = dangerouse
        //    }, "service");
        //    Console.WriteLine("Service is created");
        //    Console.ReadKey();
        //}

        //private static void GetService(RestService rest)
        //{
        //    try
        //    {
        //        Console.WriteLine(".....List all services.....");
        //        var serv = rest.Get<Services>("Services");
        //        serv.ForEach(x => Console.WriteLine(x.ToString()));
        //        Console.WriteLine("\n Press enter to search");
        //        Console.ReadLine();
        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e.Message);
        //    }

        //}
    }
}
