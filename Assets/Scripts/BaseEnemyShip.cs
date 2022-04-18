using Assets.Scripts.AI;
using Assets.Scripts.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class BaseEnemyShip : BaseAIShip
    {
        public virtual bool GuaranteedCrate => true;
        public override List<ReactiveBehavior> ReactiveBehaviors => new List<ReactiveBehavior>();

        public sealed override ShipType shipType => ShipType.ENEMY;

        public override void DestroyShip()
        {
            (Vector3 Pos, Quaternion Rot,Vector3 Mom) = (gameObject.transform.position, gameObject.transform.rotation, gameObject.GetComponent<BaseShip>().Momentum);
            base.DestroyShip();

            // Spawn crate if last in wave
            if (GuaranteedCrate) SpawnCrate(Pos, Rot, Mom);
            else
            {
                
            }
        }

        private void SpawnCrate(Vector3 Pos, Quaternion Rot, Vector3 Mom)
        {
            GameObject Crate = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Misc/Crate"));
            Crate.transform.position = Pos; Crate.transform.rotation = Rot;
            Crate.transform.parent = GameObject.Find("Misc").transform;
            var Comp = Crate.AddComponent<Crate>();
            Comp.Momentum = Mom * 2 + new Vector3(Random.Range(0f, 4f), Random.Range(0f, 4f));
        }
    }
}
