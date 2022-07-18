using System;
using UnityEngine;

namespace T {

    [CreateAssetMenu(fileName = "ScrnRslt", menuName = "ScriptableObject/ScrnRslt", order = 0)]
    public class ScrRsltSO : ScriptableObject {

        public float Mx = 0.0f;
        public float Mn = 0.0f;
        public byte NOL = 0;
        public byte Lvl = 0;

        public bool IsPrt { // is portrait or landscape
            get { return Screen.height > Screen.width; }
        }

        public float AspRt { // aspect ratio
            get { return (float)Screen.height / (float)Screen.width; } // e.g. 9:16 = 0.5625
        }

        public int Wdt { // width
            get { return (int)Math.Round((Screen.width * Mx - Screen.width * Mn) / NOL * Lvl + Screen.width * Mn); }
        }

        public int Hgh { // height
            get { return (int)Math.Round((float)Wdt * AspRt); }
        }
    }
}