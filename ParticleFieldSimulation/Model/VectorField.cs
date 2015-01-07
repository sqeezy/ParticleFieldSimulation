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

        private const double H = 1e-5;

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
            return new Vector
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
        }

        private double GradientAnStelleVonParameter(Vector vec, IFunction func, ParameterToDiff parameter)
        {
            switch (parameter)
            {
                case ParameterToDiff.X:
                    return (func.GetValue(vec.X + H, vec.Y, vec.Z) - func.GetValue(vec.X - H, vec.Y, vec.Z))/2*H;
                case ParameterToDiff.Y:
                    return (func.GetValue(vec.X, vec.Y + H, vec.Z) - func.GetValue(vec.X, vec.Y - H, vec.Z))/2*H;
                case ParameterToDiff.Z:
                    return (func.GetValue(vec.X, vec.Y, vec.Z + H) - func.GetValue(vec.X, vec.Y, vec.Z - H))/2*H;
                default:
                    throw new ArgumentException();
            }
        }
    }
}