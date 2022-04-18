using Assets.Scripts.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Crate
{
    public class Flak : Weapon
    {
        public override double Firerate => 0.5f;

        public override List<GameObject> onFire(BaseShip playerShip, bool activator = true)
        {
            List<GameObject> projectiles = CreateSeveralProjectiles(8, playerShip, 1, 4, 8f, 1.5f, new Vector3(0.1f, 0.25f), new Vector2(GetShipScale(), 0));
            foreach (var proj in projectiles)
            {
                var projComp = proj.GetComponent<Projectile>();
                projComp.Velocity = Random.Range(8f, 10f);
                projComp.Lifespan = Random.Range(0.1f, 0.5f);
                proj.transform.Rotate(new Vector3(0, 0, 1), Random.Range(-10f, 10f));
            }

            return projectiles;
        }
    }
}
