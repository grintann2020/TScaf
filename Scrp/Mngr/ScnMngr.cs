using UnityEngine;

namespace T {

    public class ScnMngr : Sngltn<ScnMngr>, IMngr { // scene manager

        public bool IsIntl { get { return _isIntl; } }
        private ScnPrm _scnPrm = null;
        private IScn[] _iScns = null;
        private byte _eCrrnScn = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Elmn();
            _scnPrm = null;
            _iScns = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _scnPrm = (ScnPrm)iPrm;
            _iScns = _scnPrm.IScns;
        }

        public void Estb(Transform trnf, byte eScn, DActn dAE = null) { // establish scene by generating all object groups, dAE = after established
            if (_iScns[_eCrrnScn] != null) {
                _iScns[_eCrrnScn].Elmn();
                _scnPrm.Omt(_eCrrnScn);
            }
            _eCrrnScn = eScn;
            _scnPrm.Prm(_eCrrnScn);
            _iScns[_eCrrnScn].Estb(trnf, dAE);
        }

        public void Estb(Transform trnf, byte eScn, byte eGrp, DActn dAE = null) { // establish scene by generating specific object group by enum, dAE = after established
            if (_iScns[_eCrrnScn] != null) {
                if (_eCrrnScn == eScn) {
                    if (_iScns[_eCrrnScn].IsGrpEstb(eGrp)) {
                        return;
                    } else {
                        _iScns[_eCrrnScn].Estb(trnf, eGrp, dAE);
                        return;
                    }
                } else {
                    _iScns[_eCrrnScn].Elmn();
                    _scnPrm.Omt(_eCrrnScn);
                }
            }
            _eCrrnScn = eScn;
            _scnPrm.Prm(_eCrrnScn);
            _iScns[_eCrrnScn].Estb(trnf, eGrp, dAE);
        }

        public void Elmn() { // eliminate scene by release all object groups
            if (_iScns[_eCrrnScn] != null) {
                _iScns[_eCrrnScn].Elmn();
                _scnPrm.Omt(_eCrrnScn);
            };
        }

        public void Elmn(byte eGrp) { // eliminate scene by release specific object group by enum
            if (_iScns[_eCrrnScn] != null) {
                _iScns[_eCrrnScn].Elmn(eGrp);
                if (!_iScns[_eCrrnScn].IsEstb) {
                    _scnPrm.Omt(_eCrrnScn);
                }
            };
        }

        public IScn IScn() { // return current scene 
            return _iScns[_eCrrnScn];
        }

        public bool IsEstb(byte eScn) { // return secific scene is established or not
            return _iScns[eScn] == null ? false : true;
        }

        public bool IsGrpEstb(byte eGrp) {
            if (_iScns[_eCrrnScn] == null) {
                return false;
            }
            return _iScns[_eCrrnScn].IsGrpEstb(eGrp);
        }

        public GameObject GtGmObjc(byte eGrp, byte eObjc) { // return specific GameObject in specific group by enum
            return _iScns[_eCrrnScn].GtGmObjc(eGrp, eObjc);
        }

        public void Enbl(byte eGrp) { // enable specific object group by enum
            _iScns[_eCrrnScn].Enbl(eGrp);
        }

        public void Dsbl(byte eGrp) { // disable specific object group by enum
            _iScns[_eCrrnScn].Dsbl(eGrp);
        }

        public void Enbl(byte eGrp, byte eObjc) { // enable specific object in specific group by enum
            _iScns[_eCrrnScn].Enbl(eGrp, eObjc);
        }

        public void Dsbl(byte eGrp, byte eObjc) { // disable specific object in specific group by enum
            _iScns[_eCrrnScn].Dsbl(eGrp, eObjc);
        }
    }
}