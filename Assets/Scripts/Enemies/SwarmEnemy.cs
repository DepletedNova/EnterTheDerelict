using Assets.Scripts.AI;
using Assets.Scripts.AI.Ordered;
using Assets.Scripts.Base;
using Assets.Scripts.Ships;
using Assets.Scripts.Ships.Enemy;
using Assets.Scripts.Weapons;
using Assets.Scripts.Weapons.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Enemies
{
    public class SwarmEnemy : BaseEnemyShip
    {
		public sealed override (Ship ship, Weapon weapon) Defaults => (new SwarmEnemyShip(), new EnemySwarmWeapon());

        public override List<OrderedBehavior> OrderedBehaviors => new List<OrderedBehavior>()
        {
            new EnterGameBehavior(),
            new FollowTargetBehavior(3, ShipType.PLAYER),
            new AttackTargetBehavior(5, ShipType.PLAYER)
        };

        public override List<string> BehaviorOrder => new List<string>()
        {
            "EnterGame",
            "FollowTarget",
            "AttackTarget"
        };
    }
}
