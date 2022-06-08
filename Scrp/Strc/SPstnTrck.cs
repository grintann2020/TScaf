using UnityEngine;

namespace T {

    public struct SPstnTrck : ITrck {

        private Transform _trnsfrm;
        private SVctr3[] _stpArry;
        private float _mX, _mY, _mZ;

        public SPstnTrck(Transform trnsfrm, SVctr3 sTrgt, int nmbrOfIntrvl) {
            _trnsfrm = trnsfrm;
            _stpArry = new SVctr3[nmbrOfIntrvl + 1];
            _mX = (sTrgt.X - _trnsfrm.position.x) / nmbrOfIntrvl;
            _mY = (sTrgt.Y - _trnsfrm.position.y) / nmbrOfIntrvl;
            _mZ = (sTrgt.Z - _trnsfrm.position.z) / nmbrOfIntrvl;
            for (int v = 0; v < _stpArry.Length; v++) {
                _stpArry[v] = new SVctr3(_mX * v + _trnsfrm.position.x, _mY * v + _trnsfrm.position.y, _mZ * v + _trnsfrm.position.z);
            }
        }

        public void Trd(int stp) {
            _trnsfrm.position = new Vector3(_stpArry[stp].X, _stpArry[stp].Y, _stpArry[stp].Z);
        }
    }
}