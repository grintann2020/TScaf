using UnityEngine;

namespace T {

    public struct SRttTrc : ITrc {

        private Transform _tf;
        private Quaternion[] _stpArr;

        public SRttTrc(Transform tf, Quaternion sOrg, Quaternion sTrg, int nOI) {
            _tf = tf;
            _stpArr = new Quaternion[nOI + 1];
            for (int v = 0; v < _stpArr.Length; v++) {
                _stpArr[v] = Quaternion.Slerp(sOrg, sTrg, v * (1 / (float)nOI));
            }
        }

        public void Trd(int stp) {
            _tf.rotation = _stpArr[stp];
        }
    }
}