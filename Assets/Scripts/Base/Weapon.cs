using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Base
{
    public abstract class Weapon
    {
        public BaseShip Parent;
        public abstract double Firerate { get; }

        public virtual bool OverrideFirerate => false;

        public abstract List<GameObject> onFire(BaseShip playerShip, bool activator = true);

        // Projectile
        public virtual void onHit(BaseShip playerShip, Projectile projectile, BaseShip hitShip)
        {
            hitShip.TakeDamage(projectile.Damage);
        }

        protected GameObject CreateProjectile(BaseShip playerShip, float Damage, float Velocity, float Lifespan, Vector3 Collision, Vector2 Offset)
        {
            var projectile = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Projectile"));

            var pTransform = playerShip.gameObject.transform;
            projectile.transform.rotation = pTransform.rotation;
            projectile.transform.position = pTransform.position + (pTransform.up * Offset.x) + (pTransform.right * Offset.y);
            projectile.transform.localScale = Collision;

            var pComponent = projectile.GetComponent<Projectile>();
            pComponent.Damage = Damage * playerShip.ProjectileDamageMod;
            pComponent.Velocity = Velocity;
            pComponent.Lifespan = Lifespan;
            pComponent.Parent = this;

            pComponent.Active = true;

            return projectile;
        }

        protected List<GameObject> CreateSeveralProjectiles(int amount, BaseShip playerShip, float Damage, float Velocity, float Lifespan, Vector3 Collision, Vector2 Offset)
        {
            List<GameObject> projectiles = new List<GameObject>();
            for (int x = 0; x < amount; x++) projectiles.Add(CreateProjectile(playerShip, Damage, Velocity, Lifespan, Collision, Offset));
            return projectiles;
        }

        protected float fireDelay = 999;
        public void FireWeapon(BaseShip playerShip, bool activator)
        {
            Parent = playerShip;
            if (!OverrideFirerate)
            {
                fireDelay = Mathf.Round((fireDelay + Time.fixedDeltaTime) * 100) / 100;
                if (fireDelay >= Firerate && activator)
                {
                    fireDelay = 0;
                    var projectiles = onFire(playerShip);
                    // TODO add behavioral effects to projectiles
                }
            }
            else
            {
                if (activator)
                {
                    var projectiles = onFire(playerShip, activator);
                    // TODO add behavioral effects to projectiles
                }
            }
        }
    }
}
