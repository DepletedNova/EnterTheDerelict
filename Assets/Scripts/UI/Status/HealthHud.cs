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
            if (Game.instance?.player != null)
            {
                var player = Game.instance.player;

                var rect = GetComponent<RectTransform>().rect;
                rect = new Rect(rect.x, rect.y, (player.shipData.Health) * 3, rect.height);

                var bar_rect = gameObject.transform.Find("Bar").GetComponent<RectTransform>().rect;
                bar_rect = new Rect(rect.x, rect.y, (player.shipData.Health - player.Health) * 3, rect.height);
            }
        }
    }
}
