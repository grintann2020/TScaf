using System;
using UnityEngine;

namespace T {

    [CreateAssetMenu(fileName = "ScrnRslt", menuName = "ScriptableObject/ScrnRslt", order = 0)]
    public class ScrnRsltSO : ScriptableObject {

        public float Mx = 0.0f;
        public float Mn = 0.0f;
        public byte NmbrOfLvl = 0;
        public byte Lvl = 0;

        public bool IsPort { // is portrait or landscape
            get { return Screen.height > Screen.width; }
        }

        public float AspcRt { // aspect ratio
            get { return (float)Screen.height / (float)Screen.width; } // e.g. 9:16 = 0.5625
        }

        public int Wdth { // width
            get { return (int)Math.Round((Screen.width * Mx - Screen.width * Mn) / NmbrOfLvl * Lvl + Screen.width * Mn); }
        }

        public int Hght { // height
            get { return (int)Math.Round((float)Wdth * AspcRt); }
        }
    }
}