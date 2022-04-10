using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship
{
    public static uint TotalWeight;
    public static readonly bool GlobalWrapping = true;

    public abstract uint Weight { get; } // Rarity weight

    public abstract float Health { get; }
    public abstract float Scale { get; }

    public abstract float Thrust { get; }
    public abstract float Drag { get; }
    public abstract float Rotation { get; }

    public virtual float HullDamage => 5;
}
