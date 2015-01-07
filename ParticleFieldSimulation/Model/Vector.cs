using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleFieldSimulation.Model
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector
                   {
                       X = a.X + b.X,
                       Y = a.Y + b.Y,
                       Z = a.Z + b.Z
                   };
        }
    }
}
