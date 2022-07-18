using UnityEngine;

namespace T {

    public struct SIns {

        public Quaternion Rtt;
        public Vector3 Pst;
        public string Ky;

        public SIns(string ky, Vector3 pst, Quaternion rtt) {
            Ky = ky;
            Pst = pst;
            Rtt = rtt;
        }
    }
}