using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseShip;

namespace Assets.Scripts.AI.Ordered
{
    public class AttackTargetBehavior : OrderedBehavior
    {
        private float Distance;
        private ShipType Target;
        public AttackTargetBehavior(float Distance, ShipType TargetType)
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
                currentShip.weaponData.FireWeapon(currentShip, true);
                if (GetDistance(currentShip.gameObject, target.gameObject) >= Distance)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
