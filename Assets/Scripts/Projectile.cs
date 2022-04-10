using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        public Weapon Parent;

        public float Damage;
        public float Velocity;
        public float Lifespan;

        public bool Active = false;

        private float Life = 0;
        public void FixedUpdate()
        {
            if (Active)
            {
                if (Lifespan != -1) Life += Time.fixedDeltaTime;

                if (Velocity != -1)
                {
                    GetComponent<Rigidbody2D>().velocity = Parent.Parent.Momentum + transform.up * Velocity;
                }

                if (Life >= Lifespan) Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<BaseShip>() != null)
            {
                var hitShip = collision.gameObject.GetComponent<BaseShip>();
                if (hitShip != Parent.Parent)
                {
                    hitShip.TakeDamage(Damage * Parent.Parent.ProjectileDamageMod);
                    Destroy(gameObject);
                }
            }
        }
    }
}
