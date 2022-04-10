using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseShip;

namespace Assets.Scripts.AI.Ordered
{
    public class FollowTargetBehavior : OrderedBehavior
    {
        private float Distance;
        private ShipType Target;
        public FollowTargetBehavior(float Distance, ShipType TargetType)
        {
            this.Distance = Distance;
            Target = TargetType;
        }

        public override bool FixedUpdateActive(BaseAIShip currentShip)
        {
            var target = GetShipFromTargetType(currentShip, Target);
            if (target != null)
            {
                currentShip.RotateToVector(target.transform.position);
                currentShip.AddMovement(currentShip.transform.up);
                if (GetDistance(currentShip, target) <= Distance)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
