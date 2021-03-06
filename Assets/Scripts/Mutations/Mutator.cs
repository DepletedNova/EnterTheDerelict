using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Mutations
{
    public abstract class Mutator : MonoBehaviour
    {
        public enum MutationType
        {
            SHIP,
            WEAPON,
            PROJECTILE,
            MISC
        };

        public abstract MutationType Type { get; }

        public abstract void Init(BaseShip ship);
    }
}
