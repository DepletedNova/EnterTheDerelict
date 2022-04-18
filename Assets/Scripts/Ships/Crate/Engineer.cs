using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ships.Crate
{
    public class Engineer : Ship
    {
        public override string VisualTag => "engineer";

        public override float Health => 90;
        public override float Scale => 1.15f;

        public override float Thrust => 1.25f;
        public override float Drag => 0.85f;
        public override float Rotation => 1;
    }
}
