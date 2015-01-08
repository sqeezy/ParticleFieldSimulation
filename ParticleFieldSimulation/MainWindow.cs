using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ParticleFieldSimulation.Model;

namespace ParticleFieldSimulation
{
    public partial class MainWindow : Form, IMainWindow
    {
        private const int Radius = 5;
        private const int Margins = 5;
        private double _modelToScreenRatioWidth;
        private double _modelToScreenRatioHeight;

        public MainWindow()
        {
            InitializeComponent();
            _spacePanel.Click += (sender, args) => HandleClicked();
        }

        public void Update(Dictionary<Vector, Vector> dictionary)
        {
            using (Graphics g = _spacePanel.CreateGraphics())
            {
                //g.Clear(Color.White);
                foreach (Vector posVector in dictionary.Keys)
                {
                    Brush black = Brushes.Black;
                    var x = (int) (posVector.X*_modelToScreenRatioWidth);
                    int y = Height - (int) (posVector.Y*_modelToScreenRatioHeight);
                    x += Margins;
                    y += Margins;
                    g.FillEllipse(black, x - Radius, y - Radius, Radius, Radius);
                }
            }
        }

        public void SetSpaceSize(double sizeOfSpace)
        {
            DoubleBuffered = true;
            _modelToScreenRatioWidth = (_spacePanel.Width - 2*Margins)/sizeOfSpace;
            _modelToScreenRatioHeight = (_spacePanel.Height - 2*Margins)/sizeOfSpace;
        }

        public event Action Clicked;

        private void HandleClicked()
        {
            if (Clicked != null)
            {
                Clicked();
            }
        }
    }
}