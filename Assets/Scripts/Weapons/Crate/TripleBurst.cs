using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Crate
{
    public class TripleBurst : Weapon
    {
        public override double Firerate => 0.75f;

        public override List<GameObject> onFire(BaseShip playerShip, bool activator = true)
        {
            var projectiles = CreateBurstProjectiles(2, 0.15f, 1, 3f, 5f, 4f, new Vector3(0.15f, 0.3f), new Vector2(GetShipScale(), 0), 0);
            CreateBurstProjectiles(2, 0.15f, 1, 3f, 4.5f, 4f, new Vector3(0.1f, 0.2f), new Vector2(GetShipScale(), 0), 15);
            CreateBurstProjectiles(2, 0.15f, 1, 3f, 4.5f, 4f, new Vector3(0.1f, 0.2f), new Vector2(GetShipScale(), 0), -15);

            return projectiles;
        }
    }
}
