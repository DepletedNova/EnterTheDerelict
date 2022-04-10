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

        public void Awake() => instance = this;

        public PlayerShip player;
    }
}
