using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Enemy
{
    public class EnemySnipeWeapon : Weapon
    {
        public override double Firerate => 5;

        public override bool StartInCooldown => true;

        public override List<GameObject> onFire(BaseShip playerShip, bool activator = true)
        {
            List<GameObject> projectiles = new List<GameObject>()
            {
                CreateProjectile(playerShip, 2, 20, 7, 3, new Vector3(.25f, .5f, 1), new Vector2(GetShipScale() / 2, 0)),
            };

            return projectiles;
        }
    }
}
