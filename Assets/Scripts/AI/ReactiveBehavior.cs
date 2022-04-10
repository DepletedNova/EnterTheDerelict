using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AI
{
    public abstract class ReactiveBehavior : Behavior
    {
        public sealed override string Name => GetType().Name + "Reactive";

        public virtual bool InterruptBehavior => false;

        public abstract bool EventTrigger(BaseAIShip currentShip);
    }
}
