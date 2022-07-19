using UnityEngine;

namespace T {

    public class ScnMng : Sng<ScnMng>, IMng { // scene manager

        public bool IsInt { get { return _isInt; } }
        private ScnPrm _scnPrm = null;
        private IScn[] _iScnArr = null;
        private byte _eCrrScn = 0;
        private bool _isInt = false;

        public void Rst() { // reset
            if (!_isInt) {
                return;
            }
            _isInt = false;
            Elm();
            _scnPrm = null;
            _iScnArr = null;
        }

        public void Int(IPrm iPrm) { // initialize
            if (_isInt) {
                return;
            }
            _isInt = true;
            _scnPrm = (ScnPrm)iPrm;
            _iScnArr = _scnPrm.IScnArr;
        }

        public void Est(Transform trnf, byte eScn, DAct dEst = null) { // establish scene by generating all object groups, dAE = after established
            if (_iScnArr[_eCrrScn] != null) {
                _iScnArr[_eCrrScn].Elm();
                _scnPrm.Omt(_eCrrScn);
            }
            _eCrrScn = eScn;
            _scnPrm.Prm(_eCrrScn);
            _iScnArr[_eCrrScn].Est(trnf, dEst);
        }

        public void Est(Transform trnf, byte eScn, byte eGrp, DAct dEst = null) { // establish scene by generating specific object group by enum, dAE = after established
            if (_iScnArr[_eCrrScn] != null) {
                if (_eCrrScn == eScn) {
                    if (_iScnArr[_eCrrScn].IsGrpEst(eGrp)) {
                        return;
                    } else {
                        _iScnArr[_eCrrScn].Est(trnf, eGrp, dEst);
                        return;
                    }
                } else {
                    _iScnArr[_eCrrScn].Elm();
                    _scnPrm.Omt(_eCrrScn);
                }
            }
            _eCrrScn = eScn;
            _scnPrm.Prm(_eCrrScn);
            _iScnArr[_eCrrScn].Est(trnf, eGrp, dEst);
        }

        public void Elm() { // eliminate scene by release all object groups
            if (_iScnArr[_eCrrScn] != null) {
                _iScnArr[_eCrrScn].Elm();
                _scnPrm.Omt(_eCrrScn);
            };
        }

        public void Elm(byte eGrp) { // eliminate scene by release specific object group by enum
            if (_iScnArr[_eCrrScn] != null) {
                _iScnArr[_eCrrScn].Elm(eGrp);
                if (!_iScnArr[_eCrrScn].IsEst) {
                    _scnPrm.Omt(_eCrrScn);
                }
            };
        }

        public IScn IScn() { // return current scene 
            return _iScnArr[_eCrrScn];
        }

        public bool IsEst(byte eScn) { // return secific scene is established or not
            return _iScnArr[eScn] == null ? false : true;
        }

        public bool IsGrpEst(byte eGrp) {
            if (_iScnArr[_eCrrScn] == null) {
                return false;
            }
            return _iScnArr[_eCrrScn].IsGrpEst(eGrp);
        }

        public GameObject GtGO(byte eGrp, byte eObjc) { // return specific GameObject in specific group by enum
            return _iScnArr[_eCrrScn].GtGO(eGrp, eObjc);
        }

        public void Enb(byte eGrp) { // enable specific object group by enum
            _iScnArr[_eCrrScn].Enb(eGrp);
        }

        public void Dsb(byte eGrp) { // disable specific object group by enum
            _iScnArr[_eCrrScn].Dsb(eGrp);
        }

        public void Enb(byte eGrp, byte eObjc) { // enable specific object in specific group by enum
            _iScnArr[_eCrrScn].Enb(eGrp, eObjc);
        }

        public void Dsbl(byte eGrp, byte eObjc) { // disable specific object in specific group by enum
            _iScnArr[_eCrrScn].Dsb(eGrp, eObjc);
        }
    }
}