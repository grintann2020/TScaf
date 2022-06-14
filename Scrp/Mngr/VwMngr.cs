using UnityEngine;

namespace T {

    public class VwMngr : Sngltn<VwMngr>, IMngr { // view manager

        public bool IsIntl { get { return _isIntl; } }
        private VwPrm _vwPrm = null;
        private IVw[] _iVwArry = null;
        private byte _eCrrnVw = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Stdn();
            _vwPrm = null;
            _iVwArry = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _vwPrm = (VwPrm)iPrm;
            _iVwArry = _vwPrm.IVwArry;
        }

        public void Stup(byte eVw, Camera[] cmrArry) { // setup 
            if (_iVwArry[_eCrrnVw] != null) {
                if (_eCrrnVw == eVw) {
                    return;
                }
                _iVwArry[_eCrrnVw].Stdwn();
                _vwPrm.Omt(_eCrrnVw);
            }
            _eCrrnVw = eVw;
            _vwPrm.Prm(_eCrrnVw);
            _iVwArry[_eCrrnVw].Stup(cmrArry);
        }

        public void Stdn() { // setdown current view
            if (_iVwArry[_eCrrnVw] != null ) {
                _iVwArry[_eCrrnVw].Stdwn();
                _vwPrm.Omt(_eCrrnVw);
            }
        }
        
        public void PrpUpd() { // prop update
            _iVwArry[_eCrrnVw]?.PrpUpdt();
        }

        public IVw GtIVw() { // return current view
            return _iVwArry[_eCrrnVw];
        }

        public bool IsStup(byte eVw) { // return specific UI is attached or not
            return _iVwArry[eVw] == null ? false : true;
        }

        public void Prjc(byte ePrj) { // set projection
            _iVwArry[_eCrrnVw]?.Prjc(ePrj);
        }

        public void Prjc(byte eCmr, byte ePrjc) { // set projection
            _iVwArry[_eCrrnVw]?.Prjc(eCmr, ePrjc);
        }

        public void Prjc(SCmrPrjc prjc) { // set projection directly
            _iVwArry[_eCrrnVw]?.Prjc(prjc);
        }

        public void Prjc(byte eCmr, SCmrPrjc prjc) { // set projection directly
            _iVwArry[_eCrrnVw]?.Prjc(eCmr, prjc);
        }

        public void Ornt(byte eOrnt) { // set orientation
            _iVwArry[_eCrrnVw]?.Ornt(eOrnt);
        }

        public void Ornt(byte eCmr, byte eOrnt) { // set orientation
            _iVwArry[_eCrrnVw]?.Ornt(eCmr, eOrnt);
        }

        public void Ornt(SOrnt3 ornt) { // set orientation directly
            _iVwArry[_eCrrnVw]?.Ornt(ornt);
        }

        public void Ornt(byte eCmr, SOrnt3 ornt) { // set orientation directly
            _iVwArry[_eCrrnVw]?.Ornt(eCmr, ornt);
        }

        // public void Mov(byte eVw, byte eMov) {
        //     _iVwArr[eVw].Mov(eMov);
        // }
    }
}