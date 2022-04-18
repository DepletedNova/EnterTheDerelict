using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static BaseShip;

namespace Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        public Weapon Parent;

        public float Damage;
        public float Velocity;
        public float Lifespan;
        public uint Pierce;

        public Vector3 Momentum = new Vector3();

        public bool Active = false;

        private bool Dying = false;
        private float Life = 0;
        private float PierceLife = 0;
        public void FixedUpdate()
        {
            if (Active && !Dying)
            {
                if (Lifespan != -1) Life += Time.fixedDeltaTime;

                if (Velocity != -1)
                {
                    GetComponent<Rigidbody2D>().velocity = transform.up * Velocity;
                }

                if (Life >= Lifespan && Lifespan != -1)
                {
                    Dying = true;
                }
            }
            else if (Active && Dying)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime);
                var sR = gameObject.GetComponent<SpriteRenderer>();
                sR.color = new Color(1, 1, 1, Mathf.Lerp(sR.color.a, 0, Time.deltaTime * 6));
                if (sR.color.a < 0.05f)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void CreateHitParticles()
        {
            var hitPrefab = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Particles/Hit"));
            hitPrefab.transform.position = gameObject.transform.position;
            hitPrefab.GetComponent<ParticleSystem>().Play();
        }

        public ShipType shipType;

        public void OnTriggerEnter2D(Collider2D collision)
        {
            try
            {
                if (!Dying && collision.CompareTag("Physics") && (collision.gameObject != Parent.Parent.gameObject))
                {
                    PierceLife++;
                    CreateHitParticles();

                    if (collision.gameObject.GetComponent<Crate>() != null)
                    {
                        collision.gameObject.GetComponent<Crate>().DamageCrate(Damage * Parent.Parent.ProjectileDamageMod, this);
                    }
                    else if (collision.gameObject.GetComponent<BaseShip>() != null)
                    {
                        if (shipType != collision.gameObject.GetComponent<BaseShip>().shipType)
                        {
                            Parent.onHit(Parent.Parent, this, collision.gameObject.GetComponent<BaseShip>());
                        }
                    }
                }
            } catch (Exception) { }

            if (PierceLife >= Pierce)
            {
                Destroy(gameObject);
            }
        }
    }
}
