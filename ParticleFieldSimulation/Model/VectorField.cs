using System;

namespace ParticleFieldSimulation.Model
{
    internal class VectorField
    {
        public enum ParameterToDiff
        {
            X,
            Y,
            Z
        }

        private const double H = 1e-3;

        public VectorField(IFunction f1, IFunction f2, IFunction f3)
        {
            F1 = f1;
            F2 = f2;
            F3 = f3;
        }

        public IFunction F1 { get; set; }
        public IFunction F2 { get; set; }
        public IFunction F3 { get; set; }

        public Vector GetRotation(Vector vector)
        {
            var vec = new Vector
                      {
                          X =
                              GradientAnStelleVonParameter(vector, F3, ParameterToDiff.Y) -
                              GradientAnStelleVonParameter(vector, F2, ParameterToDiff.Z),
                          Y =
                              GradientAnStelleVonParameter(vector, F1, ParameterToDiff.Z) -
                              GradientAnStelleVonParameter(vector, F3, ParameterToDiff.X),
                          Z =
                              GradientAnStelleVonParameter(vector, F2, ParameterToDiff.X) -
                              GradientAnStelleVonParameter(vector, F1, ParameterToDiff.Y)
                      };
            return vec;
        }

        private double GradientAnStelleVonParameter(Vector vec, IFunction func, ParameterToDiff parameter)
        {
            double result;
            switch (parameter)
            {
                case ParameterToDiff.X:
                    result= (func.GetValue(vec.X + H, vec.Y, vec.Z) - func.GetValue(vec.X - H, vec.Y, vec.Z))/2*H;
                    break;
                case ParameterToDiff.Y:
                    result= (func.GetValue(vec.X, vec.Y + H, vec.Z) - func.GetValue(vec.X, vec.Y - H, vec.Z))/2*H;
                    break;
                case ParameterToDiff.Z:
                    result= (func.GetValue(vec.X, vec.Y, vec.Z + H) - func.GetValue(vec.X, vec.Y, vec.Z - H))/2*H;
                    break;
                default:
                    throw new ArgumentException();
            }
            return result;
        }
    }
}