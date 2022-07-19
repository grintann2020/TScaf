using UnityEngine;

namespace T {

    public struct SPstTrc : ITrc {

        private Transform _tf;
        private SVct3[] _stpArr;
        private float _mX, _mY, _mZ;

        public SPstTrc(Transform tf, SVct3 sOrg, SVct3 sTrg, int nOI) {
            _tf = tf;
            _stpArr = new SVct3[nOI + 1];
            _mX = (sTrg.X - sOrg.X) / nOI;
            _mY = (sTrg.Y - sOrg.Y) / nOI;
            _mZ = (sTrg.Z - sOrg.Z) / nOI;
            for (int v = 0; v < _stpArr.Length; v++) {
                _stpArr[v] = new SVct3(_mX * v + sOrg.X, _mY * v + sOrg.Y, _mZ * v + sOrg.Z);
            }
        }

        public void Trd(int stp) {
            _tf.position = new Vector3(_stpArr[stp].X, _stpArr[stp].Y, _stpArr[stp].Z);
            // Debug.Log("stp = " + stp + ", _tf.position = " + _tf.position);
        }
    }
}