using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Stems
{
    public class BeamProjectile : Projectile
    {
        public float TickRate = 0.5f;

        private float HitTimer = 0f;
        public new void FixedUpdate()
        {
            /*HitTimer += Time.fixedDeltaTime;
            if (HitTimer >= TickRate)
            {
                HitTimer = 0f;
                foreach (Transform ship in GameObject.Find("Hub").transform)
                {
                    if (ship.gameObject.GetComponent<BaseShip>() != null && ship.gameObject.GetComponent<BaseShip>().shipType != Parent.Parent.shipType
                        && GetComponent<Collider2D>().IsTouching(ship.gameObject.GetComponent<Collider2D>()))
                    {
                        ship.gameObject.GetComponent<BaseShip>().TakeDamage(Damage, Parent.Parent.shipType);
                    }
                }
            }*/
        }

        public new void OnTriggerEnter2D(Collider2D collision) { }
    }
}
