using System;
using System.Collections.Generic;
using ParticleFieldSimulation.Model;

namespace ParticleFieldSimulation
{
    internal interface IMainWindow
    {
        void Show();
        void Update(Dictionary<Vector, Vector> dictionary);
        void SetSpaceSize(double sizeOfSpace);
        event Action Clicked;
    }
}