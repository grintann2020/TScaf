using UnityEngine;

namespace T {

    public struct STwn {

        public int Id { get { return _id; } } // get identity

        public bool IsTwnng { // get is tweening or not
            get {
                if (!float.IsNaN(_strtTm) && float.IsNaN(_psTm)) {
                    return true;
                }
                return false;
            }
        }

        public bool IsEnd {
            get {
                return _stp == _trckArry.Length - 1;
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
        private float _psTm; // pause time
        private float _psDrtn; // pause duration
        private float _updtTm; // updt time
        private float _intrvlTm; // interval time
        private float _mX, _mY, _mZ;
        private int _nmbrOfIntrvl;
        private int _stp;
        private int _id;
        private byte _ePrpr;
        private bool _isAtDlt;

        public STwn(int id, Transform trnsfrm, byte ePrpr, SVctr3 sOrgn, SVctr3 sTrgt, int nmbrOfIntrvl, float drnTm, float dlyTm, float mntdTm, bool isAtDlt = true) {
            _id = id;
            _trnsfrm = trnsfrm;
            _ePrpr = ePrpr;
            _sOrgn = sOrgn;
            _sTrgt = sTrgt;
            _nmbrOfIntrvl = nmbrOfIntrvl;
            _drnTm = drnTm;
            _dlyTm = dlyTm;
            _mntdTm = mntdTm;
            _isAtDlt = isAtDlt;

            _strtTm = float.NaN;
            _psTm = float.NaN;
            _psDrtn = 0.0f;
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
            if (!IsTwnng) {
                if (IsEnd) {
                    return;
                }
                if (tm - _mntdTm >= _dlyTm) {
                    Strt(tm);
                } else {
                    return;
                }
            }
            if ((CrrnTm(tm) - _updtTm) >= _intrvlTm) {
                if (IsEnd) {
                    _strtTm = float.NaN;
                    _updtTm = float.NaN;
                    if (_isAtDlt) {
                        Mtn.RmvTwn(_id);
                    }
                } else {
                    Stp();
                    _updtTm = tm;
                    _stp += 1;
                }
            }
        }

        public void Strt(float tm) { // start
            Stp();
            _strtTm = tm;
            _updtTm = 0.0f;
            _stp = 0;
        }

        public void Ps(float tm) { // pause
            if (!float.IsNaN(_strtTm)) {
                _psTm = tm;
            }
        }

        public void Rsm(float tm) { // resume
            if (!float.IsNaN(_psTm)) {
                _psDrtn += tm - _psTm;
                _psTm = float.NaN;
            }
        }

        private float CrrnTm(float tm) {
            return tm - _strtTm - _psDrtn;
        }

        private void Stp() {
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
        }
    }
}