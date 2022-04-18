using Assets.Scripts.AI;
using Assets.Scripts.AI.Ordered;
using Assets.Scripts.Base;
using Assets.Scripts.Ships;
using Assets.Scripts.Ships.Enemy;
using Assets.Scripts.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Enemies
{
    public class TestEnemy : BaseEnemyShip
    {
		public override (Ship ship, Weapon weapon) Defaults => (new BasicEnemyShip(), new DefaultWeapon());

        public override List<OrderedBehavior> OrderedBehaviors => new List<OrderedBehavior>()
        {
            new EnterGameBehavior(),
            new FollowTargetBehavior(3, ShipType.PLAYER),
            new AttackCrateBehavior(3),
        };

        public override List<string> BehaviorOrder => new List<string>()
        {
            "EnterGame",
            //"AttackCrate"
        };
    }
}
