using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ships.Enemy
{
    public class SwarmEnemyShip : Ship
    {
        public override uint Weight => 0;

        public override float Health => 5;
        public override float Scale => 0.4f;

        public override float Thrust => 2f;
        public override float Drag => 0.2f;
        public override float Rotation => 2;
    }
}
