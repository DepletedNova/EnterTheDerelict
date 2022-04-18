using Assets.Scripts.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        public static Game instance;

        public (bool Ship, bool Weapon) CratesAppeared = (false, false);

        public bool inGameActive = true;
        public uint Wave = 0;

        public void Awake() => instance = this;

        public PlayerShip player;

        // Waves
        public List<(Type type, float Count, float Difficulty)> EnemyGroups = new List<(Type, float, float)>()
        {
            /*(typeof(BasicEnemy), 1, 0.35f),
            (typeof(SwarmEnemy), 10, 1),
            (typeof(SniperEnemy), 1, 0.5f),*/
            (typeof(TestEnemy), 1, 1)
        };

        bool spawningWave = false;
        public void FixedUpdate()
        {
            if (inGameActive)
            {
                // Spawn Waves
                if (transform.childCount <= 1 && player != null && !spawningWave)
                {
                    spawningWave = true;
                    Wave++;
                    List<(Type type, float Count, float Difficulty)> ps = new List<(Type, float, float)>();
                    float points = Mathf.Ceil(Wave / 5f);
                    float pointsused = 0f;
                    for (int x = 0; x < 10; x++)
                    {
                        var group = EnemyGroups[UnityEngine.Random.Range(0, EnemyGroups.Count)];
                        if (pointsused + group.Difficulty <= points)
                        {
                            ps.Add(group);
                            pointsused += group.Difficulty;
                        }
                    }

                    foreach (var enemyGroup in ps)
                    {
                        SpawnGroup(enemyGroup.type, enemyGroup.Count + Mathf.Floor(Wave / 8f));
                    }

                    spawningWave = false;
                }
            }
        }

        public void SpawnGroup(Type enemyType, float Count)
        {
            for (int i = 0; i < Count; i++)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Ship"));
                enemy.transform.parent = transform;
                enemy.transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
                enemy.transform.position -= enemy.transform.up * 
                    (Camera.main.orthographicSize * (Screen.width / Screen.height)) * 2.5f;
                enemy.AddComponent(enemyType);
            }
        }
    }
}
