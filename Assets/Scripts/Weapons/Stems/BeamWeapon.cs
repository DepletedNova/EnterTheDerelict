using Assets.Scripts.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Stems
{
    public abstract class BeamWeapon : Weapon
    {
        public abstract (float Damage, float Width, float ChargeTime) BeamProperties { get; }

        public sealed override bool OverrideFirerate => true;
        public sealed override double Firerate => 0;

        protected GameObject Beam = null;
        protected float ChargeElapsed = 0f;
        public override List<GameObject> onFire(BaseShip playerShip, bool activator = true)
        {
            if (activator)
            {
                ChargeElapsed = Mathf.Clamp(ChargeElapsed + Time.deltaTime, -1f, BeamProperties.ChargeTime + 20f);
                if (ChargeElapsed < BeamProperties.ChargeTime) return null;

                if (Beam == null)
                {
                    Debug.Log("Created beam");
                    Beam = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Projectile"));
                    GameObject.Destroy(Beam.GetComponent<Projectile>());
                    var pComponent = Beam.AddComponent<BeamProjectile>();
                    pComponent.Damage = BeamProperties.Damage * playerShip.ProjectileDamageMod;
                    pComponent.Parent = this;
                    pComponent.shipType = playerShip.shipType;

                    Beam.transform.localScale = new Vector3(BeamProperties.Width, 5f/*Camera.main.orthographicSize * 2f + 5f*/);
                    Beam.transform.rotation = playerShip.transform.rotation;

                    pComponent.Active = true;
                }
                Beam.transform.rotation = playerShip.transform.rotation;
                Beam.transform.position = playerShip.transform.position + playerShip.transform.up;// * (Camera.main.orthographicSize + 2.5f);
                ModifyBeam(playerShip);

                return null;
            }
            else
            {
                //ChargeElapsed = 0f;
                if (Beam != null)
                {
                    //GameObject.Destroy(Beam);
                    //Beam = null;
                }
            }

            return null;
        }

        public virtual void ModifyBeam(BaseShip playerShip) { }
    }
}
