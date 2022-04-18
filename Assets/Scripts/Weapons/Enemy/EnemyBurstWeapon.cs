using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Enemy
{
    public class EnemyBurstWeapon : Weapon
    {
        public override double Firerate => 1.5f;

        public override bool StartInCooldown => true;
        public override List<GameObject> onFire(BaseShip playerShip, bool activator = true)
        {
            var projectiles = CreateBurstProjectiles(3, 0.2f, 1, 5, 5, 3, new Vector3(0.2f, 0.3f), new Vector2(GetShipScale() / 2, 0), 0);

            return projectiles;
        }
    }
}
