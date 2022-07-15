using UnityEngine;

namespace T {

    public class VwMngr : Sngltn<VwMngr>, IMngr { // view manager

        public bool IsIntl { get { return _isIntl; } }
        private VwPrm _vwPrm = null;
        private IVw[] _iVws = null;
        private byte _eCrrnVw = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Stdn();
            _vwPrm = null;
            _iVws = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _vwPrm = (VwPrm)iPrm;
            _iVws = _vwPrm.IVws;
        }

        public void Stup(byte eVw, Camera[] cmrs) { // setup 
            if (_iVws[_eCrrnVw] != null) {
                if (_eCrrnVw == eVw) {
                    return;
                }
                _iVws[_eCrrnVw].Stdwn();
                _vwPrm.Omt(_eCrrnVw);
            }
            _eCrrnVw = eVw;
            _vwPrm.Prm(_eCrrnVw);
            _iVws[_eCrrnVw].Stup(cmrs);
        }

        public void Stdn() { // setdown current view
            if (_iVws[_eCrrnVw] != null ) {
                _iVws[_eCrrnVw].Stdwn();
                _vwPrm.Omt(_eCrrnVw);
            }
        }
        
        public void PrpUpd() { // prop update
            _iVws[_eCrrnVw]?.PrpUpdt();
        }

        public IVw GtIVw() { // return current view
            return _iVws[_eCrrnVw];
        }

        public bool IsStup(byte eVw) { // return specific UI is attached or not
            return _iVws[eVw] == null ? false : true;
        }

        public void Prjc(byte ePrj) { // set projection
            _iVws[_eCrrnVw]?.Prjc(ePrj);
        }

        public void Prjc(byte eCmr, byte ePrjc) { // set projection
            _iVws[_eCrrnVw]?.Prjc(eCmr, ePrjc);
        }

        public void Prjc(SCmrPrjc prjc) { // set projection directly
            _iVws[_eCrrnVw]?.Prjc(prjc);
        }

        public void Prjc(byte eCmr, SCmrPrjc prjc) { // set projection directly
            _iVws[_eCrrnVw]?.Prjc(eCmr, prjc);
        }

        public void Ornt(byte eOrnt) { // set orientation
            _iVws[_eCrrnVw]?.Ornt(eOrnt);
        }

        public void Ornt(byte eCmr, byte eOrnt) { // set orientation
            _iVws[_eCrrnVw]?.Ornt(eCmr, eOrnt);
        }

        public void Ornt(SOrnt3 ornt) { // set orientation directly
            _iVws[_eCrrnVw]?.Ornt(ornt);
        }

        public void Ornt(byte eCmr, SOrnt3 ornt) { // set orientation directly
            _iVws[_eCrrnVw]?.Ornt(eCmr, ornt);
        }

        // public void Mov(byte eVw, byte eMov) {
        //     _iVwArr[eVw].Mov(eMov);
        // }
    }
}