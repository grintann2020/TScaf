using UnityEngine;

namespace T {

    public struct SRttnTrck : ITrck {

        private Transform _trnsfrm;
        private SVctr3[] _stpArry;
        private float _mX, _mY, _mZ;

        public SRttnTrck(Transform trnsfrm, SVctr3 sTrgt, int nmbrOfIntrvl) {
            _trnsfrm = trnsfrm;
            _stpArry = new SVctr3[nmbrOfIntrvl + 1];
            _mX = (sTrgt.X - _trnsfrm.eulerAngles.x) / nmbrOfIntrvl;
            _mY = (sTrgt.Y - _trnsfrm.eulerAngles.y) / nmbrOfIntrvl;
            _mZ = (sTrgt.Z - _trnsfrm.eulerAngles.z) / nmbrOfIntrvl;
            for (int v = 0; v < _stpArry.Length; v++) {
                _stpArry[v] = new SVctr3(_mX * v + _trnsfrm.eulerAngles.x, _mY * v + _trnsfrm.eulerAngles.y, _mZ * v + _trnsfrm.eulerAngles.z);
            }
        }

        public void Trd(int stp) {
            _trnsfrm.rotation = Quaternion.Euler(_stpArry[stp].X, _stpArry[stp].Y, _stpArry[stp].Z);
        }
    }
}