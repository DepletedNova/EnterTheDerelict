using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ships.Enemy
{
    public class SwarmShip : Ship
    {
        public override uint Weight => 0;

        public override float Health => 10;
        public override float Scale => 0.5f;

        public override float Thrust => 0.5f;
        public override float Drag => 0.2f;
        public override float Rotation => 1.5f;

        public override float HullDamage => 1;
    }
}
