using System.Collections.Generic;

namespace ParticleFieldSimulation.Model
{
    internal interface ISpace
    {
        double Size { get; }
        ICollection<Vector> Points { get; set; } 
    }
}