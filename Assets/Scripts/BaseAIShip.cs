using Assets.Scripts.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class BaseAIShip : BaseShip
    {
        public abstract List<ReactiveBehavior> ReactiveBehaviors { get; }
        public abstract List<OrderedBehavior> OrderedBehaviors { get; }

        public abstract List<string> BehaviorOrder { get; }

        protected ReactiveBehavior QueuedBehavior = null;
        protected Behavior currentBehavior;
        protected int behaviorCount = 0;

        protected uint triggerCheck = 0;
        protected float triggerDelay = 0;
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            var particleComp = GetComponent<ParticleSystem>();
            if (Moving && !particleComp.isEmitting) particleComp.Play(true);
            else if (!Moving && particleComp.isEmitting) particleComp.Stop(true, ParticleSystemStopBehavior.StopEmitting);


            if (triggerDelay <= 0)
            {
                triggerCheck++;
                if (triggerCheck % 10 == 0)
                {
                    foreach (var behavior in ReactiveBehaviors)
                    {
                        bool triggered = behavior.EventTrigger(this);
                        if (triggered)
                        {
                            triggerDelay = 10;
                            if (behavior.InterruptBehavior) currentBehavior = behavior;
                            else QueuedBehavior = behavior;
                        }
                    }
                }
            }
            else triggerDelay -= Time.fixedDeltaTime;

            if (currentBehavior != null)
            {
                bool completed = currentBehavior.FixedUpdateActive(this);
                if (completed)
                {
                    if (QueuedBehavior != null)
                    {
                        currentBehavior = QueuedBehavior;
                        QueuedBehavior = null;
                    }
                    else
                    {
                        behaviorCount++;
                        behaviorCount = (behaviorCount >= BehaviorOrder.Count ? 0 : behaviorCount);
                        currentBehavior = GetBehavior(BehaviorOrder[behaviorCount]);
                    }
                }
            }
            else
            {
                currentBehavior = GetBehavior(BehaviorOrder[behaviorCount]);
            }
        }

        private Behavior GetBehavior(string name) => OrderedBehaviors.First(x => x.Name == name);
    }
}
