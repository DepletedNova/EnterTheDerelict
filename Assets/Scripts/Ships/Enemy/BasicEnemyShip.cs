using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ships.Enemy
{
    public class BasicEnemyShip : Ship
    {
        public override uint Weight => 0;

        public override float Health => 35;
        public override float Scale => 1;

        public override float Thrust => 2;
        public override float Drag => 0.2f;
        public override float Rotation => 2;
    }
}
