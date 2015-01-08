using System;
using System.Windows.Forms;
using ParticleFieldSimulation.Controller;
using ParticleFieldSimulation.Model;

namespace ParticleFieldSimulation
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var func1 = new Function((x, y, z) => Math.Sin(x+z),"1");
            var func2 = new Function((x, y, z) => Math.Cos(x-y),"2");
            var func3 = new Function((x, y, z) => Math.Sin(y*z),"3");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var controller = new MainWindowController(
                new MainWindow(),
                new SpaceController(new Space(10, 5), new VectorField(func1, func2, func3)));
            Application.Run(controller.Show());
        }
    }
}