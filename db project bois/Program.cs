using Db_project_1;
using WindowsFormsApp1;

namespace db_project_bois
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new manage_appointments_trainer(1, "")) ;
                }
    }
}