using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Crate
{
    public class Pulse : Weapon
    {
        public override double Firerate => 1f;

        public override List<GameObject> onFire(BaseShip playerShip, bool activator = true)
        {
            List<GameObject> projectiles = new List<GameObject>()
            {
                CreateProjectile(playerShip, 99, 15, -1, 0.05f, new Vector3(2.5f, 2.5f, 1), Vector2.zero)
            };

            return projectiles;
        }
    }
}
