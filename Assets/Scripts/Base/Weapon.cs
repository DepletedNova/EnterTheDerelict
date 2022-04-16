using System;
using System.Collections;
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
        public virtual bool StartInCooldown => false;

        public abstract List<GameObject> onFire(BaseShip playerShip, bool activator = true);

        // Projectile
        public virtual void onHit(BaseShip playerShip, Projectile projectile, BaseShip hitShip)
        {
            hitShip.TakeDamage(projectile.Damage, playerShip);
        }

        protected GameObject CreateProjectile(BaseShip playerShip, uint pierce, float Damage, float Velocity, float Lifespan, Vector3 Collision, Vector2 Offset)
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
            pComponent.Pierce = pierce;

            pComponent.Momentum = Parent.Momentum;

            pComponent.Active = true;

            return projectile;
        }

        private IEnumerator CreateBurstEffect(float Delay, float Velocity, float Lifespan, Vector2 Offset, List<GameObject> Projectiles)
        {
            foreach (var projectile in Projectiles)
            {
                var component = projectile.GetComponent<Projectile>();
                component.Velocity = Velocity;
                component.Lifespan = Lifespan;
                component.Active = true;
                projectile.transform.rotation = Parent.transform.rotation;
                projectile.transform.position = Parent.transform.position + (Parent.transform.up * Offset.x) + (Parent.transform.right * Offset.y);
                yield return new WaitForSeconds(Delay);
            }
        }

        protected List<GameObject> CreateBurstProjectiles(int Amount, float Delay, uint Pierce, float Damage, float Velocity, float Lifespan, Vector3 Collision, Vector2 Offset)
        {
            List<GameObject> projectiles = new List<GameObject>();
            for (int x = 0; x < Amount; x++)
            {
                var projectile = CreateProjectile(Parent, Pierce, Damage, -1, -1, Collision, Vector3.zero);
                projectile.GetComponent<Projectile>().Active = false;
                projectile.transform.position = new Vector3(0, 100);
                projectiles.Add(projectile);
            }

            Parent.StartCoroutine(CreateBurstEffect(Delay, Velocity, Lifespan, Offset, projectiles));

            return projectiles;
        }

        protected List<GameObject> CreateSeveralProjectiles(int amount, BaseShip playerShip, uint pierce, float Damage, float Velocity, float Lifespan, Vector3 Collision, Vector2 Offset)
        {
            List<GameObject> projectiles = new List<GameObject>();
            for (int x = 0; x < amount; x++) projectiles.Add(CreateProjectile(playerShip, pierce, Damage, Velocity, Lifespan, Collision, Offset));
            return projectiles;
        }

        protected float GetShipScale() => Mathf.Max(Parent.transform.localScale.x, Parent.transform.localScale.y);

        public float fireDelay = 999;
        public bool FireWeapon(BaseShip playerShip, bool activator)
        {
            Parent = playerShip;
            if (!OverrideFirerate)
            {
                fireDelay = Mathf.Round((fireDelay + Time.fixedDeltaTime) * 100f) / 100f;
                if (fireDelay >= Firerate && activator)
                {
                    fireDelay = 0;
                    var projectiles = onFire(playerShip);
                    // TODO add behavioral effects to projectiles

                    return projectiles != null;
                }
            }
            else
            {
                if (activator)
                {
                    var projectiles = onFire(playerShip, activator);
                    // TODO add behavioral effects to projectiles

                    return projectiles != null;
                }
            }
            return false;
        }
    }
}
