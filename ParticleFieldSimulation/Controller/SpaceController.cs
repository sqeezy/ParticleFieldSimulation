using System;
using System.Collections.Generic;
using System.Linq;
using ParticleFieldSimulation.Model;

namespace ParticleFieldSimulation.Controller
{
    internal class SpaceController : ISpaceController
    {
        private readonly VectorField _field;
        private readonly ISpace _space;
        private Dictionary<Vector, Vector> _positionToRotationMap;

        public SpaceController(ISpace space, VectorField field)
        {
            _space = space;
            _field = field;
            SizeOfSpace = _space.Size;

            _positionToRotationMap = _space.Points.ToDictionary(vector => vector, GetRotation);
        }

        public void Start(int itterations)
        {
            for (int iter = 0; iter < itterations; iter++)
            {
                List<Vector> newPositions =
                    _positionToRotationMap.Keys.AsParallel().Select(
                        positionVector => positionVector + 100*_positionToRotationMap[positionVector]).ToList();
                _positionToRotationMap = newPositions.ToDictionary(vector => vector, GetRotation);
                _space.Points = newPositions;
                if (SpaceChanged != null&&itterations%1000==0)
                {
                    SpaceChanged(_positionToRotationMap);
                }
            }
        }

        public event Action<Dictionary<Vector, Vector>> SpaceChanged;
        public double SizeOfSpace { get; private set; }

        private Vector GetRotation(Vector vector)
        {
            var result = _field.GetRotation(vector);
            return result;
        }
    }
}