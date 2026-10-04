using UnityEngine;

namespace game
{
    public class RotateCubeTask : SimulationTask
    {
        private bool hasRotated = false;

        public override bool IsComplete()
        {
            return hasRotated;
        }

        public void CubeRotated()
        {
            hasRotated = true;
        }
    }
}
