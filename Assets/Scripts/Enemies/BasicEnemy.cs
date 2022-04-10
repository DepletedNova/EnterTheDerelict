using Assets.Scripts.AI;
using Assets.Scripts.AI.Ordered;
using Assets.Scripts.Ships;
using Assets.Scripts.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Enemies
{
    public class BasicEnemy : BaseAIShip
    {
        public override ShipType shipType => ShipType.ENEMY;

        public override List<ReactiveBehavior> ReactiveBehaviors => new List<ReactiveBehavior>()
        {
            
        };
        public override List<OrderedBehavior> OrderedBehaviors => new List<OrderedBehavior>()
        {
            new FollowTargetBehavior(4, ShipType.PLAYER),
            new AttackTargetBehavior(6, ShipType.PLAYER)
        };

        public override List<string> BehaviorOrder => new List<string>()
        {
            "FollowTarget",
            "AttackTarget"
        };

        public void Start()
        {
            UpdateShip(new DefaultShip());
            UpdateWeapon(new DefaultWeapon());
        }
    }
}
