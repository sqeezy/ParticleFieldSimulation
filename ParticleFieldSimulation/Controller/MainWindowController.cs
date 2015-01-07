using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParticleFieldSimulation.Model;

namespace ParticleFieldSimulation.Controller
{
    class MainWindowController
    {
        private readonly IMainWindow _mainWindow;
        private readonly ISpaceController _spaceController;

        public MainWindowController(IMainWindow mainWindow,ISpaceController spaceController)
        {
            _mainWindow = mainWindow;
            _spaceController = spaceController;

            _mainWindow.SetSpaceSize(_spaceController.SizeOfSpace);

            _spaceController.SpaceChanged += HandleSpaceChanged;
        }

        public Form Show()
        {
            _mainWindow.Show();
            _spaceController.Start(10);
            return (Form) _mainWindow;
        }

        private void HandleSpaceChanged(Dictionary<Vector, Vector> dictionary)
        {
            _mainWindow.Update(dictionary);
        }
    }
}
