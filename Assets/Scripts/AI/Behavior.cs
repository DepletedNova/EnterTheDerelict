using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseShip;

public abstract class Behavior
{
    public abstract string Name { get; }

    public abstract bool FixedUpdateActive(BaseAIShip currentShip);

    protected float GetDistance(GameObject currentShip, GameObject targetShip) =>
        Vector3.Distance(currentShip.transform.position, targetShip.transform.position);

    protected BaseShip GetShipFromTargetType(BaseAIShip currentShip, ShipType target)
    {
        var hub = GameObject.Find("Hub");
        float objDistance = 999;
        BaseShip closeShip = null;
        foreach (var ship in hub.GetComponentsInChildren<BaseShip>())
        {
            if (ship.shipType == target)
            {
                var dist = GetDistance(currentShip.gameObject, ship.gameObject);
                if (dist < objDistance)
                {
                    closeShip = ship;
                    objDistance = dist;
                }
            }
        }
        return closeShip;
    }

    protected T GetMiscPhysicsObject<T>(BaseAIShip currentShip, bool useDist = true) where T : MonoBehaviour
    {
        var hub = GameObject.Find("Misc");
        float objDistance = 999;
        if (!useDist) return hub.GetComponentInChildren<T>();
        else
        {
            T closeComp = null;
            foreach (var comp in hub.GetComponentsInChildren<T>())
            {
                float dist = GetDistance(currentShip.gameObject, comp.gameObject);
                if (dist < objDistance)
                {
                    closeComp = comp;
                    objDistance = dist;
                }
            }
            return closeComp;
        }
    }
}
