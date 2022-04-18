using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class VisualData
    {
        public static Dictionary<string, (string Texture, Vector2[] Points, (Color Ally, Color Enemy) Colors)> shipColliders = new Dictionary<string, (string, Vector2[], (Color, Color))>()
        {
            ["base"] = ("Textures/Ships/Base", new Vector2[]
                {new Vector2(-0.45f, -0.15f), new Vector2(-0.4f, -0.225f), new Vector2(0.4f, -0.225f), new Vector2(0.45f, -0.15f), 
                    new Vector2(0.2f, 0f), new Vector2(0.05f, 0.425f), new Vector2(-0.05f, 0.425f), new Vector2(-0.2f, 0f)},
            (Color.white, new Color(0.9921569f, 0.3803922f, 0.3803922f))),

            ["assault"] = ("Textures/Ships/Assault", new Vector2[]
                {new Vector2(-0.45f, -0.05f), new Vector2(-0.4f, -0.125f), new Vector2(-0.15f, -0.275f), new Vector2(0.15f, -0.275f),
                    new Vector2(0.4f, -0.125f), new Vector2(0.45f, -0.05f), new Vector2(0.125f, 0), new Vector2(0.025f, 0.375f),
                    new Vector2(-0.025f, 0.375f), new Vector2(-0.125f, 0),},
            (Color.white, new Color(0.9921569f, 0.3803922f, 0.3803922f))),

            ["engineer"] = ("Textures/Ships/Engineer", new Vector2[]
                {new Vector2(-0.45f, -0.15f), new Vector2(-0.4f, -0.225f), new Vector2(0.4f, -0.225f), new Vector2(0.45f, -0.15f),
                    new Vector2(0.2f, 0f), new Vector2(0.05f, 0.425f), new Vector2(-0.05f, 0.425f), new Vector2(-0.2f, 0f)},
            (Color.white, new Color(0.9921569f, 0.3803922f, 0.3803922f))),

            ["sentry"] = ("Textures/Ships/Sentry", new Vector2[]
                {new Vector2(-0.45f, -0.15f), new Vector2(-0.4f, -0.225f), new Vector2(0.4f, -0.225f), new Vector2(0.45f, -0.15f),
                    new Vector2(0.225f, 0.2f), new Vector2(0.1f, 0.3f), new Vector2(-0.1f, 0.3f), new Vector2(-0.225f, 0.2f)},
            (Color.white, new Color(0.9921569f, 0.3803922f, 0.3803922f))),

            ["spectre"] = ("Textures/Ships/Spectre", new Vector2[]
                {new Vector2(-0.45f, -0.15f), new Vector2(-0.4f, -0.225f), new Vector2(0.4f, -0.225f), new Vector2(0.45f, -0.15f),
                    new Vector2(0.225f, 0.2f), new Vector2(0.1f, 0.3f), new Vector2(-0.1f, 0.3f), new Vector2(-0.225f, 0.2f)},
            (Color.white, new Color(0.9921569f, 0.3803922f, 0.3803922f))),
        };
    }
}
