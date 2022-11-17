namespace tablesttest;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        try
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);   
        }
        //Empleado testempleado = new Empleado("margarino","123","dba",null);
        //  context.Empleados.Add(testempleado);

    }
}