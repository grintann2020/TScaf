using System;
using UnityEngine;

namespace T {

    public struct STfTwn : ITwn {

        public int Id { get { return _id; } } // get identity
        public bool IsMnt { get { return !float.IsNaN(_mntTm); } } // get is mounted or not
        public bool IsStr { get { return !float.IsNaN(_strTm) && !float.IsNaN(_mntTm); } } // get is mounted or not
        public bool IsEnd { get { return _stp == _nOIv; } } // get is end or not
        public bool IsTwn { get { return !float.IsNaN(_strTm) && float.IsNaN(_psTm); } } // get is tweening or not
        private ITrc[] _iTrcArr; // the array of track interface
        private DAct _dEnd;
        private float _drtn; // duration
        private float _dly; // dely
        private float _mntTm; // mounted time
        private float _strTm; // start time
        private float _psTm; // pause time
        private float _psDrtn; // pause duration
        private int _id; // identity
        private int _nOIv; // number of interval
        private int _stp; // step
        private int _tmpStp; // temp step
        private bool _isDps; // is deposable

        public STfTwn(int id, ITrc[] iTrcArr, int nOIv, float drtn, float dly, float tm, bool isExct = true, bool isDps = true, DAct dEnd = null) {
            _id = id;
            _iTrcArr = iTrcArr;
            _dEnd = dEnd;
            _nOIv = nOIv;
            _drtn = drtn;
            _dly = dly;
            _isDps = isDps;

            _mntTm = float.NaN;
            _strTm = float.NaN;
            _psTm = float.NaN;
            _psDrtn = 0.0f;
            _stp = 0;
            _tmpStp = 0;
            if (isExct) {
                _mntTm = tm;
            }
        }

        public void PrpUpd(float tm) { // prop update
            if (!IsMnt || IsEnd) {
                return;
            } else {
                if (ElpTm(tm) >= _dly && !IsStr) {
                    Str(tm);
                }
            }
            if (!IsTwn) {
                return;
            }
            _tmpStp = CmlStp(tm);
            if (_tmpStp > _stp) {
                _stp = _tmpStp;
                Trd(_stp);
                if (IsEnd) {
                    _mntTm = float.NaN;
                    _strTm = float.NaN;
                    _psTm = float.NaN;
                    _psDrtn = 0.0f;
                    if (_isDps) {
                        _iTrcArr = null;
                        Anm.RmvTwn(_id);
                        _dEnd?.Invoke();
                    }
                }
            }
        }

        public void Str(float tm, bool isDly = true) { // start
            _stp = 0;
            if (!IsMnt) {
                _mntTm = tm;
                if (isDly) {
                    Trd(0);
                    return;
                }
            }
            _strTm = tm;
            Trd(_stp);
        }

        public void Ps(float tm) { // pause
            if (!IsMnt) {
                return;
            }
            if (!float.IsNaN(_strTm)) {
                _psTm = tm;
            }
        }

        public void Rsm(float tm) { // resume
            if (!float.IsNaN(_psTm)) {
                _psDrtn += tm - _psTm;
                _psTm = float.NaN;
            }
        }

        private float ElpTm(float tm) { // elapsed time 
            return tm - _mntTm;
        }

        private float CrrTm(float tm) { // current time
            return tm - _strTm - _psDrtn;
        }

        private int CmlStp(float tm) { // current cumulative 
            return (int)Math.Floor(CrrTm(tm) / _drtn * _nOIv);
        }

        private void Trd(int stp) { // tread
            for (int t = 0; t < _iTrcArr.Length; t++) {
                _iTrcArr[t].Trd(stp);
            }
        }
    }
}