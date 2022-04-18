using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ships.Enemy
{
    public class SwarmEnemyShip : Ship
    {
        public override string VisualTag => "base";

        public override float Health => 5;
        public override float Scale => 0.4f;

        public override float Thrust => 0.35f;
        public override float Drag => 0.25f;
        public override float Rotation => 1;
    }
}
