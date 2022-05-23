using UnityEngine;

namespace T {

    public class ScnMngr : Sngltn<ScnMngr>, IMngr { // scene manager

        public bool IsIntl { get { return _isIntl; } }
        private ScnPrm _scnPrm = null;
        private IScn[] _iScnArry = null;
        private byte _eScn = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            Elmn();
            _scnPrm = null;
            _iScnArry = null;
            _isIntl = false;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _scnPrm = (ScnPrm)iPrm;
            _iScnArry = _scnPrm.IScnArry;
            _isIntl = true;
        }

        public void Estb(Transform trnf, byte eScn, DActn dAE = null) { // establish scene by generating all object groups, dAE = after established
            if (_iScnArry[_eScn] != null) {
                _iScnArry[_eScn].Elmn();
                _scnPrm.Omt(_eScn);
            }
            _eScn = eScn;
            _scnPrm.Prm(_eScn);
            _iScnArry[_eScn].Estb(trnf, dAE);
        }

        public void Estb(Transform trnf, byte eScn, byte eGrp, DActn dAE = null) { // establish scene by generating specific object group by enum, dAE = after established
            if (_iScnArry[_eScn] != null) {
                if (_eScn == eScn) {
                    if (_iScnArry[_eScn].IsGrpEstb(eGrp)) {
                        return;
                    } else {
                        _iScnArry[_eScn].Estb(trnf, eGrp, dAE);
                        return;
                    }
                } else {
                    _iScnArry[_eScn].Elmn();
                    _scnPrm.Omt(_eScn);
                }
            }
            _eScn = eScn;
            _scnPrm.Prm(_eScn);
            _iScnArry[_eScn].Estb(trnf, eGrp, dAE);
            
        }

        public void Elmn() { // eliminate scene by release all object groups
            if (_iScnArry[_eScn] != null) {
                _iScnArry[_eScn].Elmn();
                _scnPrm.Omt(_eScn);
            };
        }

        public void Elmn(byte eGrp) { // eliminate scene by release specific object group by enum
            if (_iScnArry[_eScn] != null) {
                _iScnArry[_eScn].Elmn(eGrp);
                if (!_iScnArry[_eScn].IsEstb) {
                    _scnPrm.Omt(_eScn);
                }
            };
        }

        public bool IsEstb() { // return current scene is established or not
            return _iScnArry[_eScn] == null ? false : true;
        }

        public bool IsEstb(byte eScn) { // return secific scene is established or not
            return _iScnArry[eScn] == null ? false : true;
        }

        public bool IsGrpEstb(byte eGrp) {
            if (_iScnArry[_eScn] == null) {
                return false;
            }
            return _iScnArry[_eScn].IsGrpEstb(eGrp);
        }

        public bool IsGrpEstb(byte eScn, byte eGrp) {
            if (_iScnArry[eScn] == null) {
                return false;
            }
            return _iScnArry[eScn].IsGrpEstb(eGrp);
        }

        public IScn Scn() { // return current scene 
            return _iScnArry[_eScn];
        }

        public IScn Scn(byte eScn) { // return specific scene by enum
            return _iScnArry[eScn];
        }

        public GameObject GmObjc(byte eGrp, byte eObjc) { // return specific GameObject in specific group by enum
            return _iScnArry[_eScn].GmObjc(eGrp, eObjc);
        }

        public GameObject GmObjc(byte eScn, byte eGrp, byte eObjc) { // return specific GameObject in specific group by enum
            if (_iScnArry[eScn] == null) {
                return null;
            }
            return _iScnArry[eScn].GmObjc(eGrp, eObjc);
        }

        public void Enbl(byte eGrp) { // enable specific object group by enum
            _iScnArry[_eScn].Enbl(eGrp);
        }

        public void Dsbl(byte eGrp) { // disable specific object group by enum
            _iScnArry[_eScn].Dsbl(eGrp);
        }

        public void Enbl(byte eGrp, byte eObjc) { // enable specific object in specific group by enum
            _iScnArry[_eScn].Enbl(eGrp, eObjc);
        }

        public void Dsbl(byte eGrp, byte eObjc) { // disable specific object in specific group by enum
            _iScnArry[_eScn].Dsbl(eGrp, eObjc);
        }
    }
}