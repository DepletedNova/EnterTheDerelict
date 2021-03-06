using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ships
{
    public class DefaultShip : Ship
    {
        public override string VisualTag => "base";

        public override float Health => 100;
        public override float Scale => 1f;

        public override float Thrust => 1.5f;
        public override float Drag => 1;
        public override float Rotation => 1;
    }
}
