using System.Collections.Generic;
using System.Windows.Forms;
using ParticleFieldSimulation.Model;

namespace ParticleFieldSimulation.Controller
{
    internal class MainWindowController
    {
        private readonly IMainWindow _mainWindow;
        private readonly ISpaceController _spaceController;
        private int _counter = 0;

        public MainWindowController(IMainWindow mainWindow, ISpaceController spaceController)
        {
            _mainWindow = mainWindow;
            _spaceController = spaceController;

            _mainWindow.SetSpaceSize(_spaceController.SizeOfSpace);

            _spaceController.SpaceChanged += HandleSpaceChanged;
            _mainWindow.Clicked += () => _spaceController.Start(100000000);
        }

        public Form Show()
        {
            _mainWindow.Show();
            return (Form) _mainWindow;
        }

        private void HandleSpaceChanged(Dictionary<Vector, Vector> dictionary)
        {
            _mainWindow.Update(dictionary);
        }
    }
}