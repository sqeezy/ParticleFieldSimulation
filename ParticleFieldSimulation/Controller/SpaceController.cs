using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using ParticleFieldSimulation.Model;

namespace ParticleFieldSimulation.Controller
{
    class SpaceController : ISpaceController
    {
        private readonly ISpace _space;
        private readonly VectorField _field;
        private Dictionary<Vector, Vector> _positionToRotationMap; 

        public SpaceController(ISpace space,VectorField field)
        {
            _space = space;
            _field = field;

            _positionToRotationMap = _space.Points.ToDictionary(GetRotation);
        }

        private Vector GetRotation(Vector vector)
        {
           return _field.GetRotation(vector);
        }

        public void Start(int itterations)
        {
            for (int iter = 0; iter < itterations; iter++)
            {
                var newPositions = new List<Vector>();
                foreach (Vector positionVector in _positionToRotationMap.Keys)
                {
                    Vector newPosition = positionVector + _positionToRotationMap[positionVector];
                    newPositions.Add(newPosition);
                }
                _positionToRotationMap = newPositions.ToDictionary(GetRotation);
                if (SpaceChanged != null)
                {
                    SpaceChanged(_positionToRotationMap);
                }
            }
        }

        public event Action<Dictionary<Vector, Vector>> SpaceChanged;
    }
}