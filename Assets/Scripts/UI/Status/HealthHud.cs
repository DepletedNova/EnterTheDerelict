using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.Status
{
    public class HealthHud : MonoBehaviour
    {
        public void Update()
        {
            if (Game.instance.player != null)
            {
                var player = Game.instance.player;

                GetComponent<RectTransform>().sizeDelta = new Vector2(player.shipData.Health * 5, 20);
                gameObject.transform.Find("Bar").GetComponent<RectTransform>().sizeDelta = new Vector2((player.Health - player.shipData.Health) * 5, 20);
            }
        }
    }
}
