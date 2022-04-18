using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ships.Crate
{
    public class Sentry : Ship
    {
        public override string VisualTag => "sentry";

        public override float Health => 135;
        public override float Scale => 1.3f;

        public override float Thrust => 0.8f;
        public override float Drag => 0.3f;
        public override float Rotation => 1.5f;
    }
}
