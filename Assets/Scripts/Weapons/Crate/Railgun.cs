using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Crate
{
    public class Railgun : Weapon
    {
        public override double Firerate => 2.5f;

        public override List<GameObject> onFire(BaseShip playerShip, bool activator = true)
        {
            List<GameObject> projectiles = new List<GameObject>()
            {
                CreateProjectile(playerShip, 3, 35f, 30f, 4f, new Vector3(.2f, .8f, 1), new Vector2(GetShipScale(), 0))
            };

            return projectiles;
        }
    }
}
