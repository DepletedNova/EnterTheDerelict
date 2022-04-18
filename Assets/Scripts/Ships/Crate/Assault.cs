using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ships.Crate
{
    public class Assault : Ship
    {
        public override string VisualTag => "assault";

        public override float Health => 85;
        public override float Scale => 1f;

        public override float Thrust => 1.65f;
        public override float Drag => 0.5f;
        public override float Rotation => 1.25f;
    }
}
