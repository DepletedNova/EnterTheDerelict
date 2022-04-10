using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AI
{
    public abstract class OrderedBehavior : Behavior
    {
        public override string Name => GetType().Name.Trim().Replace("Behavior","");
    }
}
