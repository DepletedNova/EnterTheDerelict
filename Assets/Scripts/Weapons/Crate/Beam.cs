using Assets.Scripts.Weapons.Stems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapons.Crate
{
    public class Beam : BeamWeapon
    {
        public override (float Damage, float Width, float ChargeTime) BeamProperties => (5f, 1f, 0.5f);
    }
}
