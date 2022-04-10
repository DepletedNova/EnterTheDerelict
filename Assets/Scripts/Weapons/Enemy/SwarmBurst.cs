using Assets.Scripts.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Enemy
{
    public class SwarmBurst : Weapon
    {
        public override double Firerate => 3;

        public override List<GameObject> onFire(BaseShip playerShip, bool activator = true)
        {
            var localScale = playerShip.gameObject.transform.localScale;
            List<GameObject> projectiles = CreateSeveralProjectiles(5, playerShip, 1, 5, 0.6f, new Vector3(.1f, .1f), Vector2.zero);

            foreach (var proj in projectiles)
            {
                proj.transform.Rotate(Vector3.forward, Random.Range(-10, 10));
                proj.GetComponent<Projectile>().Velocity = Random.Range(3.0f, 5.0f);
            }

            return projectiles;
        }
    }
}
