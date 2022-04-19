using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Mutations
{
    public abstract class ProjectileMutator : Mutator
    {
        public override MutationType Type => MutationType.PROJECTILE;
        public virtual bool isBehaviour => false;

        public abstract void onProjectileCreated(BaseShip ship, Projectile projectile);
    }
}
