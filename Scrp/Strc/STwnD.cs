using UnityEngine;

namespace T {

    public struct STwnD {

        public bool IsTwnng { // get is tweening or not
            get {
                if (!float.IsNaN(_strtTm) && float.IsNaN(_psTm)) {
                    return true;
                }
                return false;
            }
        }

        private SVctr3[] _trckArry;
        private Transform _trnsfrm;
        private SVctr3 _sOrgn;
        private SVctr3 _sTrgt;
        private Vector3 _tmpVctr3;
        private float _drnTm;
        private float _dlyTm;
        private float _mntdTm;
        private float _strtTm;
        private float _updtTm; // updt time
        private float _intrvlTm; // interval time
        private float _mX, _mY, _mZ;
        private int _nmbrOfIntrvl;
        private int _stp;
        private int _indx;
        private byte _ePrpr;

        public STwnD(int indx, Transform trnsfrm, byte ePrpr, SVctr3 sOrgn, SVctr3 sTrgt, int nmbrOfIntrvl, float drnTm, float dlyTm, float mntdTm) {
            _indx = indx;
            _trnsfrm = trnsfrm;
            _ePrpr = ePrpr;
            _sOrgn = sOrgn;
            _sTrgt = sTrgt;
            _nmbrOfIntrvl = nmbrOfIntrvl;
            _drnTm = drnTm;
            _dlyTm = dlyTm;
            _mntdTm = mntdTm;

            _strtTm = float.NaN;
            _updtTm = float.NaN;
            _intrvlTm = drnTm / _nmbrOfIntrvl;
            _stp = 0;
            _trckArry = new SVctr3[nmbrOfIntrvl];
            _mX = (sTrgt.X - sOrgn.X) / nmbrOfIntrvl;
            _mY = (sTrgt.Y - sOrgn.Y) / nmbrOfIntrvl;
            _mZ = (sTrgt.Z - sOrgn.Z) / nmbrOfIntrvl;
            for (int v = 0; v < _trckArry.Length; v++) {
                _trckArry[v] = new SVctr3(_mX * v + sOrgn.X, _mY * v + sOrgn.Y, _mZ * v + sOrgn.Z);
            }
            _tmpVctr3 = new Vector3();
        }

        public void PrpUpdt(float tm) {
            if (!float.IsNaN(_strtTm)) {
                if (tm - _mntdTm >= _dlyTm) {
                    _strtTm = tm;
                    _updtTm = 0.0f;
                } else {
                    return;
                }
            }
            if ((tm - _updtTm) >= _intrvlTm) {
                if (stp == _trckArry.Length - 1) {
                    _strtTm = float.NaN;
                    _updtTm = float.NaN;
                    Mtn.RmvTwn(_indx);
                } else {
                    _tmpVctr3.x = _trckArry[_stp].X;
                    _tmpVctr3.y = _trckArry[_stp].Y;
                    _tmpVctr3.z = _trckArry[_stp].Z;
                    if (_ePrpr == 0) {
                        _trnsfrm.position = _tmpVctr3;
                    } else if (_ePrpr == 1) {
                        _trnsfrm.rotation = Quaternion.Euler(_tmpVctr3.x, _tmpVctr3.y, _tmpVctr3.z);
                    } else if (_ePrpr == 2) {
                        _trnsfrm.localScale = _tmpVctr3;
                    }
                    _updtTm = tm;
                    _stp += 1;
                }
            }
        }
    }
}