using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParticleFieldSimulation.Controller;
using ParticleFieldSimulation.Model;

namespace ParticleFieldSimulation
{
    public partial class MainWindow : Form,IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Update(Dictionary<Vector, Vector> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
