﻿namespace T {

    public class SpcMngr : Sngltn<SpcMngr>, IMngr { // stage manager

        public bool IsIntl { get { return _isIntl; } } // get is initialized or not
        private ISpc[] _iSpcArry = null; // an array of stage
        private SpcPrm _spcPrm = null;  // prime of stage
        private byte _eSpc = 0; // enum of stage
        private bool _isIntl = false; // is initialized or not

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Dcnst();
            _spcPrm = null;
            _iSpcArry = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _spcPrm = (SpcPrm)iPrm;
            _iSpcArry = _spcPrm.ISpcArry;
        }

        public void Cnst(byte eSpc) { // implement specific stage by enum
            if (_iSpcArry[_eSpc] != null) {
                if (_eSpc == eSpc) {
                    return;
                }
                _iSpcArry[_eSpc].Dcnst();
                _spcPrm.Omt(_eSpc);
            }
            _eSpc = eSpc;
            _spcPrm.Prm(_eSpc);
            _iSpcArry[_eSpc].Cnst(0);
        }

        public void Dcnst() { // abort current stage
            if (_iSpcArry[_eSpc] != null) {
                _iSpcArry[_eSpc].Dcnst();
                _spcPrm.Omt(_eSpc);
            }
        }

        public ISpc ISpc() { // return current stage
            return _iSpcArry[_eSpc];
        }

        public bool IsCnst(byte eSpc) { // return specific stage is implemented or not
            return _iSpcArry[eSpc] == null ? false : true;
        }

        public IUnt[][][] IUntArry() {
            return _iSpcArry[_eSpc].IUntArry;
        }

        public IUnt[] IUntPrArry() {
            return _iSpcArry[_eSpc].IUntPrArry;
        }
    }
}