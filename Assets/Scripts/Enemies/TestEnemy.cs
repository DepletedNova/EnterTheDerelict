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
    public class TestEnemy : BaseAIShip
    {
        public override ShipType shipType => ShipType.ENEMY;
		
		public override (Ship ship, Weapon weapon) Defaults => (new BasicEnemyShip(), new DefaultWeapon());

        public override List<ReactiveBehavior> ReactiveBehaviors => new List<ReactiveBehavior>()
        {

        };
        public override List<OrderedBehavior> OrderedBehaviors => new List<OrderedBehavior>()
        {
            new EnterGameBehavior(),
        };

        public override List<string> BehaviorOrder => new List<string>()
        {
            "EnterGame",
        };
    }
}
