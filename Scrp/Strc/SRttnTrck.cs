using UnityEngine;

namespace T {

    public struct SRttnTrck : ITrck {

        private Transform _trnsfrm;
        private Quaternion[] _stpArry;

        public SRttnTrck(Transform trnsfrm, Quaternion sOrgn, Quaternion sTrgt, int nmbrOfIntrvl) {
            _trnsfrm = trnsfrm;
            _stpArry = new Quaternion[nmbrOfIntrvl + 1];
            for (int v = 0; v < _stpArry.Length; v++) {
                _stpArry[v] = Quaternion.Slerp(sOrgn, sTrgt, v * (1 / (float)nmbrOfIntrvl));
            }
        }

        public void Trd(int stp) {
            _trnsfrm.rotation = _stpArry[stp];
        }
    }
}