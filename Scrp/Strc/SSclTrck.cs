using UnityEngine;

namespace T {

    public struct SSclTrck : ITrck {

        private Transform _trnsfrm;
        private SVctr3[] _stpArry;
        private float _mX, _mY, _mZ;

        public SSclTrck(Transform trnsfrm, SVctr3 sTrgt, int nmbrOfIntrvl) {
            _trnsfrm = trnsfrm;
            _stpArry = new SVctr3[nmbrOfIntrvl + 1];
            _mX = (sTrgt.X - _trnsfrm.localScale.x) / nmbrOfIntrvl;
            _mY = (sTrgt.Y - _trnsfrm.localScale.y) / nmbrOfIntrvl;
            _mZ = (sTrgt.Z - _trnsfrm.localScale.z) / nmbrOfIntrvl;
            for (int v = 0; v < _stpArry.Length; v++) {
                _stpArry[v] = new SVctr3(_mX * v + _trnsfrm.localScale.x, _mY * v + _trnsfrm.localScale.y, _mZ * v + _trnsfrm.localScale.z);
            }
        }

        public void Trd(int stp) {
            _trnsfrm.localScale = new Vector3(_stpArry[stp].X, _stpArry[stp].Y, _stpArry[stp].Z);
        }
    }
}