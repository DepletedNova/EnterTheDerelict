using Assets.Scripts.AI;
using Assets.Scripts.Ships.Enemy;
using Assets.Scripts.Weapons.Enemy;
using Assets.Scripts.AI.Ordered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Enemies
{
    public class SwarmEnemy : BaseAIShip
    {
        public override ShipType shipType => ShipType.ENEMY;

        public override List<ReactiveBehavior> ReactiveBehaviors => new List<ReactiveBehavior>() { };
        public override List<OrderedBehavior> OrderedBehaviors => new List<OrderedBehavior>()
        {
            new FollowTargetBehavior(3, ShipType.PLAYER),
            new AttackTargetBehavior(5, ShipType.PLAYER)
        };

        public override List<string> BehaviorOrder => new List<string>()
        {
            "FollowTarget",
            "AttackTarget"
        };

        public void Start()
        {
            UpdateShip(new SwarmShip());
            UpdateWeapon(new SwarmBurst());
        }
    }
}
