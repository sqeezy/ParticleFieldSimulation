using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _mainWindow.Show();

            _spaceController.SpaceChanged += HandleSpaceChanged;
            _spaceController.Start(10);
        }

        private void HandleSpaceChanged(Dictionary<Vector, Vector> dictionary)
        {
            _mainWindow.Update(dictionary);
        }
    }
}
