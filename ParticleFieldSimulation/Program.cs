using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParticleFieldSimulation.Controller;
using ParticleFieldSimulation.Model;

namespace ParticleFieldSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var func = new Function((d, d1, arg3) => d + d1 + arg3);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindowController controller = new MainWindowController(new MainWindow(), new SpaceController(new Space(10,2), new VectorField(func,func,func )));
            Application.Run(controller.Show());
        }
    }
}
