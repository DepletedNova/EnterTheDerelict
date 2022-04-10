using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseShip;

public abstract class Behavior
{
    public abstract string Name { get; }

    public abstract bool FixedUpdateActive(BaseAIShip currentShip);

    protected float GetDistance(BaseShip currentShip, BaseShip targetShip) =>
        Vector3.Distance(currentShip.gameObject.transform.position, targetShip.transform.position);

    protected BaseShip GetShipFromTargetType(BaseAIShip currentShip, ShipType target)
    {
        var hub = GameObject.Find("Hub");
        float objDistance = 999;
        BaseShip closeShip = null;
        foreach (var ship in hub.GetComponentsInChildren<BaseShip>())
        {
            if (ship.shipType == target)
            {
                var dist = GetDistance(currentShip, ship);
                if (dist < objDistance)
                {
                    closeShip = ship;
                }
            }
        }
        return closeShip;
    }
}
