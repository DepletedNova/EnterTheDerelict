using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Mutations
{
    public abstract class Mutator
    {
        public static List<Type> Mutations = new List<Type>()
        {

        };

        public enum MutationType
        {
            SHIP,
            WEAPON,
            PROJECTILE,
            MISC
        };

        public abstract MutationType Type { get; }

        public abstract void Init();
    }
}
