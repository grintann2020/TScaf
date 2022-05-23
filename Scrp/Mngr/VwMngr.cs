using UnityEngine;

namespace T {

    public class VwMngr : Sngltn<VwMngr>, IMngr { // view manager

        public bool IsIntl { get { return _isIntl; } }
        private VwPrm _vwPrm = null;
        private IVw[] _iVwArry = null;
        private byte _eVw = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            Stdn();
            _vwPrm = null;
            _iVwArry = null;
            _isIntl = false;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _vwPrm = (VwPrm)iPrm;
            _iVwArry = _vwPrm.IVwArry;
            _isIntl = true;
        }

        public void Stup(Camera[] cmrArry, byte eVw) { // setup 
            if (_iVwArry[_eVw] != null) {
                if (_eVw == eVw) {
                    return;
                }
                _iVwArry[_eVw].Stdwn();
                _vwPrm.Omt(_eVw);
            }
            _eVw = eVw;
            _vwPrm.Prm(_eVw);
            _iVwArry[_eVw].Stup(cmrArry);
        }

        public void Stdn() { // setdown current view
            if (_iVwArry[_eVw] != null ) {
                _iVwArry[_eVw].Stdwn();
                _vwPrm.Omt(_eVw);
            }
        }
        
        public void PrpUpd() { // prop update
            _iVwArry[_eVw]?.PrpUpdt();
        }

        public bool IsStup() { // return current UI is attached or not
            return _iVwArry[_eVw] == null ? false : true;
        }

        public bool IsStup(byte eVw) { // return specific UI is attached or not
            return _iVwArry[eVw] == null ? false : true;
        }

        public IVw Vw() { // return current view
            return _iVwArry[_eVw];
        }

        public IVw Vw(byte eVw) { // return specific view by enum
            return _iVwArry[eVw];
        }

        public void Prjc(byte ePrj) { // set projection
            _iVwArry[_eVw]?.Prjc(ePrj);
        }

        public void Prjc(byte eCmr, byte ePrjc) { // set projection
            _iVwArry[_eVw]?.Prjc(eCmr, ePrjc);
        }

        public void Prjc(SCmrPrjc prjc) { // set projection directly
            _iVwArry[_eVw]?.Prjc(prjc);
        }

        public void Prjc(byte eCmr, SCmrPrjc prjc) { // set projection directly
            _iVwArry[_eVw]?.Prjc(eCmr, prjc);
        }

        public void Ornt(byte eOrnt) { // set orientation
            _iVwArry[_eVw]?.Ornt(eOrnt);
        }

        public void Ornt(byte eCmr, byte eOrnt) { // set orientation
            _iVwArry[_eVw]?.Ornt(eCmr, eOrnt);
        }

        public void Ornt(SOrnt3 ornt) { // set orientation directly
            _iVwArry[_eVw]?.Ornt(ornt);
        }

        public void Ornt(byte eCmr, SOrnt3 ornt) { // set orientation directly
            _iVwArry[_eVw]?.Ornt(eCmr, ornt);
        }

        // public void Mov(byte eVw, byte eMov) {
        //     _iVwArr[eVw].Mov(eMov);
        // }
    }
}