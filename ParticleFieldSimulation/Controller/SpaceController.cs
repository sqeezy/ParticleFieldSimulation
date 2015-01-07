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

            _positionToRotationMap = _space.Points.ToDictionary(GetRotation);
        }

        public void Start(int itterations)
        {
            for (int iter = 0; iter < itterations; iter++)
            {
                List<Vector> newPositions =
                    _positionToRotationMap.Keys.Select(
                        positionVector => positionVector + _positionToRotationMap[positionVector]).ToList();
                _positionToRotationMap = newPositions.ToDictionary(GetRotation);
                _space.Points = newPositions;
                if (SpaceChanged != null)
                {
                    SpaceChanged(_positionToRotationMap);
                }
            }
        }

        public event Action<Dictionary<Vector, Vector>> SpaceChanged;
        public double SizeOfSpace { get; private set; }

        private Vector GetRotation(Vector vector)
        {
            return _field.GetRotation(vector);
        }
    }
}