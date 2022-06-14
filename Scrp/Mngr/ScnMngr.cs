using UnityEngine;

namespace T {

    public class ScnMngr : Sngltn<ScnMngr>, IMngr { // scene manager

        public bool IsIntl { get { return _isIntl; } }
        private ScnPrm _scnPrm = null;
        private IScn[] _iScnArry = null;
        private byte _eCrrnScn = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Elmn();
            _scnPrm = null;
            _iScnArry = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _scnPrm = (ScnPrm)iPrm;
            _iScnArry = _scnPrm.IScnArry;
        }

        public void Estb(Transform trnf, byte eScn, DActn dAE = null) { // establish scene by generating all object groups, dAE = after established
            if (_iScnArry[_eCrrnScn] != null) {
                _iScnArry[_eCrrnScn].Elmn();
                _scnPrm.Omt(_eCrrnScn);
            }
            _eCrrnScn = eScn;
            _scnPrm.Prm(_eCrrnScn);
            _iScnArry[_eCrrnScn].Estb(trnf, dAE);
        }

        public void Estb(Transform trnf, byte eScn, byte eGrp, DActn dAE = null) { // establish scene by generating specific object group by enum, dAE = after established
            if (_iScnArry[_eCrrnScn] != null) {
                if (_eCrrnScn == eScn) {
                    if (_iScnArry[_eCrrnScn].IsGrpEstb(eGrp)) {
                        return;
                    } else {
                        _iScnArry[_eCrrnScn].Estb(trnf, eGrp, dAE);
                        return;
                    }
                } else {
                    _iScnArry[_eCrrnScn].Elmn();
                    _scnPrm.Omt(_eCrrnScn);
                }
            }
            _eCrrnScn = eScn;
            _scnPrm.Prm(_eCrrnScn);
            _iScnArry[_eCrrnScn].Estb(trnf, eGrp, dAE);
        }

        public void Elmn() { // eliminate scene by release all object groups
            if (_iScnArry[_eCrrnScn] != null) {
                _iScnArry[_eCrrnScn].Elmn();
                _scnPrm.Omt(_eCrrnScn);
            };
        }

        public void Elmn(byte eGrp) { // eliminate scene by release specific object group by enum
            if (_iScnArry[_eCrrnScn] != null) {
                _iScnArry[_eCrrnScn].Elmn(eGrp);
                if (!_iScnArry[_eCrrnScn].IsEstb) {
                    _scnPrm.Omt(_eCrrnScn);
                }
            };
        }

        public IScn IScn() { // return current scene 
            return _iScnArry[_eCrrnScn];
        }

        public bool IsEstb(byte eScn) { // return secific scene is established or not
            return _iScnArry[eScn] == null ? false : true;
        }

        public bool IsGrpEstb(byte eGrp) {
            if (_iScnArry[_eCrrnScn] == null) {
                return false;
            }
            return _iScnArry[_eCrrnScn].IsGrpEstb(eGrp);
        }

        public GameObject GtGmObjc(byte eGrp, byte eObjc) { // return specific GameObject in specific group by enum
            return _iScnArry[_eCrrnScn].GtGmObjc(eGrp, eObjc);
        }

        public void Enbl(byte eGrp) { // enable specific object group by enum
            _iScnArry[_eCrrnScn].Enbl(eGrp);
        }

        public void Dsbl(byte eGrp) { // disable specific object group by enum
            _iScnArry[_eCrrnScn].Dsbl(eGrp);
        }

        public void Enbl(byte eGrp, byte eObjc) { // enable specific object in specific group by enum
            _iScnArry[_eCrrnScn].Enbl(eGrp, eObjc);
        }

        public void Dsbl(byte eGrp, byte eObjc) { // disable specific object in specific group by enum
            _iScnArry[_eCrrnScn].Dsbl(eGrp, eObjc);
        }
    }
}