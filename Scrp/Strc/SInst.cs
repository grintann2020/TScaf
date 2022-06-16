using UnityEngine;

namespace T {

    public struct SInst {

        public Quaternion Rttn;
        public Vector3 Pstn;
        public string Ky;

        public SInst(string ky, Vector3 pstn, Quaternion rttn) {
            Ky = ky;
            Pstn = pstn;
            Rttn = rttn;
        }
    }
}