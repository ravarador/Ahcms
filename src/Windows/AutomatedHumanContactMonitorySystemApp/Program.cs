using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomatedHumanContactMonitorySystemApp.Forms;
using AutomatedHumanContactMonitorySystemApp.Forms.AttendeeForms;
using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Repositories;
using SimpleInjector;


namespace AutomatedHumanContactMonitorySystemApp
{
   
    static class Program
    {
        private static Container container;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            container = new Container();
            container.Register<IAttendeeRepository, AttendeeRepository>(Lifestyle.Singleton);
            container.Register<IPlaceRepository, PlaceRepository>(Lifestyle.Singleton);
            container.Register<IAttendanceRepository, AttendanceRepository>(Lifestyle.Singleton);
            container.Register<IAppUserRepository, AppUserRepository>(Lifestyle.Singleton);
            //test commit
            ////container.Register<AddAttendeeForm>(Lifestyle.Singleton);
            container.Register<MainFormNew>(Lifestyle.Singleton);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.GetInstance<MainFormNew>());
        }
    }
}
