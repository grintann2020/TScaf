using UnityEngine;

namespace T {

    public class VwMng : Sng<VwMng>, IMng { // view manager

        public bool IsInt { get { return _isInt; } }
        private VwPrm _vwPrm = null;
        private IVw[] _iVws = null;
        private byte _eCrrVw = 0;
        private bool _isInt = false;

        public void Rst() { // reset
            if (!_isInt) {
                return;
            }
            _isInt = false;
            StDwn();
            _vwPrm = null;
            _iVws = null;
        }

        public void Int(IPrm iPrm) { // initialize
            if (_isInt) {
                return;
            }
            _isInt = true;
            _vwPrm = (VwPrm)iPrm;
            _iVws = _vwPrm.IVws;
        }

        public void StUp(byte eVw, Camera[] cmrs) { // set up 
            if (_iVws[_eCrrVw] != null) {
                if (_eCrrVw == eVw) {
                    return;
                }
                _iVws[_eCrrVw].StDwn();
                _vwPrm.Omt(_eCrrVw);
            }
            _eCrrVw = eVw;
            _vwPrm.Prm(_eCrrVw);
            _iVws[_eCrrVw].StUp(cmrs);
        }

        public void StDwn() { // set down current view
            if (_iVws[_eCrrVw] != null ) {
                _iVws[_eCrrVw].StDwn();
                _vwPrm.Omt(_eCrrVw);
            }
        }
        
        public void PrpUpd() { // prop update
            _iVws[_eCrrVw]?.PrpUpd();
        }

        public IVw GtIVw() { // return current view
            return _iVws[_eCrrVw];
        }

        public bool IsSu(byte eVw) { // return specific UI is attached or not
            return _iVws[eVw] == null ? false : true;
        }

        public void Prj(byte ePrj) { // set projection
            _iVws[_eCrrVw]?.Prj(ePrj);
        }

        public void Prj(byte eCmr, byte ePrj) { // set projection
            _iVws[_eCrrVw]?.Prj(eCmr, ePrj);
        }

        public void Prj(SCmrPrj Prj) { // set projection directly
            _iVws[_eCrrVw]?.Prj(Prj);
        }

        public void Prj(byte eCmr, SCmrPrj Prj) { // set projection directly
            _iVws[_eCrrVw]?.Prj(eCmr, Prj);
        }

        public void Orn(byte eOrn) { // set orientation
            _iVws[_eCrrVw]?.Orn(eOrn);
        }

        public void Orn(byte eCmr, byte eOrn) { // set orientation
            _iVws[_eCrrVw]?.Orn(eCmr, eOrn);
        }

        public void Orn(SOrn3 orn) { // set orientation directly
            _iVws[_eCrrVw]?.Orn(orn);
        }

        public void Orn(byte eCmr, SOrn3 orn) { // set orientation directly
            _iVws[_eCrrVw]?.Orn(eCmr, orn);
        }

        // public void Mov(byte eVw, byte eMov) {
        //     _iVwArr[eVw].Mov(eMov);
        // }
    }
}