using System;
using UnityEngine;

namespace T {

    public struct STwn : ITwn {

        public int Id { get { return _id; } } // get identity
        public bool IsMntd { get { return !float.IsNaN(_mntdTm); } } // get is mounted or not
        public bool IsStrt { get { return !float.IsNaN(_strtTm) && !float.IsNaN(_mntdTm); } } // get is mounted or not
        public bool IsEnd { get { return _stp == _nmbrOfIntrvl; } } // get is end or not
        public bool IsTwnng { get { return !float.IsNaN(_strtTm) && float.IsNaN(_psTm); } } // get is tweening or not
        private ITrck[] _iTrckArry; // the array of track interface
        private DActn _dEnd;
        private float _drtn; // duration
        private float _dly; // dely
        private float _mntdTm; // mounted time
        private float _strtTm; // start time
        private float _psTm; // pause time
        private float _psDrtn; // pause duration
        private int _id; // identity
        private int _nmbrOfIntrvl; // number of interval
        private int _stp; // step
        private int _tmpStp; // temp step
        private bool _isDpsb; // is deposable

        public STwn(int id, ITrck[] iTrckArry, int nmbrOfIntrvl, float drtn, float dly, float tm, bool isExct = true, bool isDpsb = true, DActn dEnd = null) {
            _id = id;
            _iTrckArry = iTrckArry;
            _dEnd = dEnd;
            _nmbrOfIntrvl = nmbrOfIntrvl;
            _drtn = drtn;
            _dly = dly;
            _isDpsb = isDpsb;

            _mntdTm = float.NaN;
            _strtTm = float.NaN;
            _psTm = float.NaN;
            _psDrtn = 0.0f;
            _stp = 0;
            _tmpStp = 0;
            if (isExct) {
                _mntdTm = tm;
            }
        }

        public void PrpUpdt(float tm) { // prop update
            if (!IsMntd || IsEnd) {
                return;
            } else {
                if (Elps(tm) >= _dly && !IsStrt) {
                    Strt(tm);
                }
            }
            if (!IsTwnng) {
                return;
            }
            _tmpStp = CmltStp(tm);
            if (_tmpStp > _stp) {
                _stp = _tmpStp;
                Trd(_stp);
                if (IsEnd) {
                    _mntdTm = float.NaN;
                    _strtTm = float.NaN;
                    _psTm = float.NaN;
                    _psDrtn = 0.0f;
                    if (_isDpsb) {
                        _iTrckArry = null;
                        Mtn.RmvTwn(_id);
                        _dEnd?.Invoke();
                    }
                }
            }
        }

        public void Strt(float tm, bool isDly = true) { // start
            _stp = 0;
            if (!IsMntd) {
                _mntdTm = tm;
                if (isDly) {
                    Trd(0);
                    return;
                }
            }
            _strtTm = tm;
            Trd(_stp);
        }

        public void Ps(float tm) { // pause
            if (!IsMntd) {
                return;
            }
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

        private float Elps(float tm) { // elapsed time 
            return tm - _mntdTm;
        }

        private float CrrnTm(float tm) { // current time
            return tm - _strtTm - _psDrtn;
        }

        private int CmltStp(float tm) { // current cumulative 
            return (int)Math.Floor(CrrnTm(tm) / _drtn * _nmbrOfIntrvl);
        }

        private void Trd(int stp) { // tread
            for (int t = 0; t < _iTrckArry.Length; t++) {
                _iTrckArry[t].Trd(stp);
            }
        }
    }
}