using Assets.Scripts.Base;
using Assets.Scripts.Mutations;
using Assets.Scripts.Ships.Crate;
using Assets.Scripts.Weapons.Crate;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Crate : MonoBehaviour
    {
        public enum CrateType { MUTATION, WEAPON, SHIP }

        public static List<(float Weight, Mutator Mutation)> Mutations = new List<(float, Mutator)>()
        {

        };
        public static List<(float Weight, Weapon Weapon)> Weapons = new List<(float, Weapon)>()
        {
            (1, new Flak()),
            (1, new Pulse()),
            (1, new Railgun()),
            (1, new TripleBurst()),
        };
        public static List<(float Weight, Ship Ship)> Ships = new List<(float, Ship)>()
        {
            (1, new Assault()),
            (1, new Engineer()),
            (1, new Sentry()),
            (1, new Spectre()),
        };

        // Crate Physics
        public CrateType Type;
        public Vector3 Momentum = new Vector3();
        private float Health = 65;

        public void Start()
        {
            Dictionary<CrateType, (float Weight, Color crateColor)> Chances = new Dictionary<CrateType, (float, Color)>()
            {
                [CrateType.SHIP] = (!Game.instance.CratesAppeared.Ship ? 2f : 0.3f, new Color(0.2509804f, 0.6607246f, 0.9058824f)),
                [CrateType.WEAPON] = (!Game.instance.CratesAppeared.Weapon ? 2.5f : 0.5f, new Color(0.8867924f, 0.3890174f, 0.3890174f)),
                [CrateType.MUTATION] = (1f, new Color(0.9058824f, 0.5480451f, 0.2509804f)),
            };
            float Total = Chances.Sum(x => x.Value.Weight);
            float Rand = Random.Range(0f, Total);
            float wTotal = 0;
            (CrateType Type, Color crateColor) type = (CrateType.MUTATION, Color.white);
            for (int x = 0; x < Chances.Count; x++)
            {
                var value = Chances.ToArray()[x].Value.Weight;
                if (Rand > wTotal && Rand < wTotal + value)
                {
                    type = (Chances.ToArray()[x].Key, Chances.ToArray()[x].Value.crateColor);
                    break;
                }
                wTotal += value;
            }
            if (type.Type == CrateType.SHIP) Game.instance.CratesAppeared.Ship = true;
            if (type.Type == CrateType.WEAPON) Game.instance.CratesAppeared.Weapon = true;

            gameObject.GetComponent<SpriteRenderer>().color = type.crateColor;
            Type = type.Type;
        }

        public void FixedUpdate()
        {
            if (Momentum != Vector3.zero)
            {
                Momentum = Vector3.Lerp(Momentum, Vector3.zero, Time.deltaTime / 1.5f);
            }
            GetComponent<Rigidbody2D>().velocity = Momentum;

            if (Camera.main != null)
            {
                // Vertical
                if (Mathf.Abs(transform.position.y) > Camera.main.orthographicSize + 0.2f)
                    transform.position = new Vector3(transform.position.x, transform.position.y < 0 ? Camera.main.orthographicSize : -Camera.main.orthographicSize);
                // Horizontal
                var aspectOrtho = Camera.main.orthographicSize * Screen.width / Screen.height;
                if (Mathf.Abs(transform.position.x) > aspectOrtho + 0.2f)
                    transform.position = new Vector3(transform.position.x < 0 ? aspectOrtho : -aspectOrtho, transform.position.y);
            }
        }
        public void DamageCrate(float Damage, Projectile Source)
        {
            Health -= Damage;
            if (Health <= 0)
            {
                if (Source.shipType == BaseShip.ShipType.PLAYER)
                {

                }

                var explosionPrefab = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Particles/CrateExplosion"));
                explosionPrefab.transform.position = gameObject.transform.position;
                explosionPrefab.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
                explosionPrefab.GetComponent<ParticleSystem>().Play();
                Destroy(gameObject);
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Physics"))
            {
                Vector3 vectorToTarget = collision.transform.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector3 up = q * Vector3.up;
                Momentum -= collision.gameObject.GetComponent<BaseShip>() != null ? up * 5 : up * 2;
            }
        }
    }
}
