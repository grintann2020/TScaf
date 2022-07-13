using UnityEngine;

namespace T {

    public struct SPstnTrck : ITrck {

        private Transform _trnsfrm;
        private SVctr3[] _stpArry;
        private float _mX, _mY, _mZ;

        public SPstnTrck(Transform trnsfrm, SVctr3 sOrgn, SVctr3 sTrgt, int nmbrOfIntrvl) {
            _trnsfrm = trnsfrm;
            _stpArry = new SVctr3[nmbrOfIntrvl + 1];
            _mX = (sTrgt.X - sOrgn.X) / nmbrOfIntrvl;
            _mY = (sTrgt.Y - sOrgn.Y) / nmbrOfIntrvl;
            _mZ = (sTrgt.Z - sOrgn.Z) / nmbrOfIntrvl;
            for (int v = 0; v < _stpArry.Length; v++) {
                _stpArry[v] = new SVctr3(_mX * v + sOrgn.X, _mY * v + sOrgn.Y, _mZ * v + sOrgn.Z);
            }
        }

        public void Trd(int stp) {
            _trnsfrm.position = new Vector3(_stpArry[stp].X, _stpArry[stp].Y, _stpArry[stp].Z);
            // Debug.Log("stp = " + stp + ", _trnsfrm.position = " + _trnsfrm.position);
        }
    }
}