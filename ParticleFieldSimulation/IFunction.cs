using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleFieldSimulation
{
    interface IFunction
    {
        double GetValue(double x, double y, double z);
    }

    class Function : IFunction
    {
        private readonly Func<double,double,double,double> _func;

        public Function(Func<double, double, double, double> func)
        {
            _func = func;
        }

        public double GetValue(double x, double y, double z)
        {
            return _func.Invoke(x, y, z);
        }
    }
}
