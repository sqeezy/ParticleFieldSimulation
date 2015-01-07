using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParticleFieldSimulation.Model;

namespace ParticleFieldSimulation.Controller
{
    interface ISpaceController
    {
        void Start(int itterations);
        event Action<Dictionary<Vector,Vector>>  SpaceChanged;
    }
}
