using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AI.Ordered
{
    public class AttackCrateBehavior : OrderedBehavior
    {
        private float Distance;
        public AttackCrateBehavior(float Distance)
        {
            this.Distance = Distance;
        }

        private bool Active = false;
        public override bool FixedUpdateActive(BaseAIShip currentShip)
        {
            currentShip.Moving = false;
            if (GetMiscPhysicsObject<Crate>(currentShip, false) != null)
            {
                if (!Active) Active = Random.Range(1, 6) % 5 == 0;
                
                if (Active)
                {
                    var Target = GetMiscPhysicsObject<Crate>(currentShip);
                    currentShip.RotateToVector(Target.transform.position);
                    if (GetDistance(currentShip.gameObject, Target.gameObject) <= Distance)
                    {
                        currentShip.weaponData.FireWeapon(currentShip, true);
                    }
                    else
                    {
                        Vector3 dir = (Target.transform.position - currentShip.transform.position).normalized;
                        float dotProd = Vector3.Dot(dir, currentShip.transform.up);
                        if (dotProd > 0.9f)
                        {
                            currentShip.Moving = true;
                            currentShip.AddMovement(currentShip.transform.up);
                        }
                    }
                    return false;
                }
            }
            Active = false;
            return true;
        }
    }
}
