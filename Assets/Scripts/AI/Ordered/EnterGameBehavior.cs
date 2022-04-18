using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AI.Ordered
{
    public class EnterGameBehavior : OrderedBehavior
    {
        public override bool FixedUpdateActive(BaseAIShip currentShip)
        {
            var pos = currentShip.transform;
            var aspectOrtho = Camera.main.orthographicSize * Screen.width / Screen.height;
            if (Camera.main != null &&
                Mathf.Abs(pos.position.y) < Camera.main.orthographicSize &&
                Mathf.Abs(pos.position.x) < aspectOrtho)
            {
                currentShip.Wrapping = true;
                currentShip.Moving = false;
                return true;
            }
            currentShip.RotateToVector(Vector3.zero);
            currentShip.AddMovement(currentShip.transform.up);
            currentShip.Moving = true;
            return false;
        }
    }
}
