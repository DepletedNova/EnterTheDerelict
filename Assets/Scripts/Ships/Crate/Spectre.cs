using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ships.Crate
{
    public class Spectre : Ship
    {
        public override string VisualTag => "spectre";

        public override float Health => 100;
        public override float Scale => 1f;

        public override float Thrust => 2.2f;
        public override float Drag => 1.2f;
        public override float Rotation => 1;
    }
}
