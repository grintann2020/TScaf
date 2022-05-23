using UnityEngine;

namespace T {

    public class HbMngr : Sngltn<HbMngr> {

        public bool IsIntl { get { return _isIntl; } }
        private HbPrm _hbPrm = null;
        private IHb[] _iHbArry = null;
        // private IHb _iCurHb;
        private byte _eHb = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _hbPrm = null;
            _iHbArry = null;
            _isIntl = false;
        }

        // public void Bind(HbPrm hubPrm) {
        //     _iHbArry = hubPrm.IHbArry;
        // }

        public void Intl(IPrm iPrm) { // inithublize
            if (_isIntl) {
                return;
            }
            _hbPrm = (HbPrm)iPrm;
            _iHbArry = _hbPrm.IHbArry;
            _isIntl = true;
        }

        // public void Cnnc(byte eHb) { // excute specific program by Enum
        //     if (_iCurHb != null) {
        //         if (_iHbArry[eHb] == _iCurHb) {
        //             return;
        //         }
        //         _iCurHb.Dscn();
        //     }
        //     _iCurHb = _iHbArry[eHb]; 
        //     _iCurHb.Cnnc();
        // }

        public void Cnnc(byte eHb) { // connect
            if (_iHbArry[_eHb] != null) {
                if (_eHb == eHb) {
                    return;
                }
                _iHbArry[_eHb].Dscn();
                _hbPrm.Omt(_eHb);
            }
            _eHb = eHb;
            _hbPrm.Prm(_eHb);
            _iHbArry[_eHb].Cnnc();
        }
 
        public void Dscn(byte eHb) { // disconnect
            if (_iHbArry[_eHb] != null) {
                _iHbArry[_eHb].Dscn();
                _hbPrm.Omt(_eHb);
            }
        }

        public void PrpUpdt() { // prop update
            _iHbArry[_eHb]?.PrpUpdt();
        }

        public bool IsCnnc() { // return current hub is installed or not
            return _iHbArry[_eHb] == null ? false : true;
        }

        public bool IsCnnc(byte eIa) { // return specific hub is installed or not
            return _iHbArry[eIa] == null ? false : true;
        }

        public IHb Hb() {
            return _iHbArry[_eHb];
        }

        public IHb Hb(byte eHb) {
            return _iHbArry[eHb];
        }

        // public void Act(byte eAct) {
        //     _iCurHb.Act(eAct);
        // }

        // public void Act(byte eHb, byte eAct) {
        //     _iHbArry[eHb].Act(eAct);
        // }

        // public void Mot(byte eAct) {
        //     _iCurHb.Mot(eAct);
        // }

        // public void Mot(byte eHb, byte eAct) {
        //     _iHbArry[eHb].Mot(eAct);
        // }

        public void StGO(byte eGO, GameObject go) {
            // _iCurHb.StGO(eGO, go);
        }

        public void StGO(byte eHb, byte eGO, GameObject go) {
            _iHbArry[eHb].StGO(eGO, go);
        }

        // public GameObject GtGO(byte eGO) {
            // return _iCurHb.GtGO(eGO);
        // }

        public GameObject GtGO(byte eHb, byte eGO) {
            return _iHbArry[eHb].GtGO(eGO);
        }

        public void StVal<T>(byte eVal, T val) {
            // _iCurHb.StVal<T>(eVal, val);
        }

        public void StVal<T>(byte eHb, byte eVal, T val) {
            _iHbArry[eHb].StVal<T>(eVal, val);
        }

        // public T GtVal<T>(byte eVal) {
            // return _iCurHb.GtVal<T>(eVal);
        // }

        public T GtVal<T>(byte eHb, byte eVal) {
            return _iHbArry[eHb].GtVal<T>(eVal);
        }
    }
}