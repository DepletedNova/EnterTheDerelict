using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class DefaultWeapon : Weapon
    {
        public override double Firerate => 0.25f;

        public override List<GameObject> onFire(BaseShip playerShip, bool activator = true)
        {
            List<GameObject> projectiles = new List<GameObject>()
            {
                CreateProjectile(playerShip, 1, 5, 10, 1, new Vector3(.25f, .25f, 1), new Vector2(GetShipScale()/2, 0.25f)),
                CreateProjectile(playerShip, 1, 5, 10, 1, new Vector3(.25f, .25f, 1), new Vector2(GetShipScale()/2, -0.25f)),
            };

            return projectiles;
        }
    }
}
