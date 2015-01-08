using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace ParticleFieldSimulation.Model
{
    internal class Space : ISpace
    {
        /// <summary>
        ///     Creates a space of a certain size with a certain number of points per one unit.
        /// </summary>
        /// <param name="size">The size of the cubic space.</param>
        /// <param name="resolution">The number of particles per dimension per one unit.</param>
        public Space(double size, double resolution)
        {
            Size = size;
            Points = new List<Vector>();
            for (double x = 1; x <= size; x += resolution)
            {
                for (double y = 1; y <= size; y += resolution)
                {
                    for (double z = 1; z <= size; z += resolution)
                    {
                        var vec = new Vector
                                  {
                                      X = x,
                                      Y = y,
                                      Z = z
                                  };
                        Points.Add(vec);
                    }
                }
            }
        }

        public double Size { get; private set; }
        public ICollection<Vector> Points { get; set; }
    }
}