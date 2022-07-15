using UnityEngine;

namespace T {

    public class ObjcsMngr : Sngltn<ObjcsMngr>, IMngr { // data manager

        public bool IsIntl { get { return _isIntl; } }
        private IObjcs[] _iObjcss = null;
        private ObjcsPrm _objcsPrm = null;
        private byte _eCrrnObjcs = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Ruin();
            _objcsPrm = null;
            _iObjcss = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _objcsPrm = (ObjcsPrm)iPrm;
            _iObjcss = _objcsPrm.IObjcss;
        }

        public void Found(byte eObjcs, Transform rtTrnsfrm) { // found
            if (_iObjcss[_eCrrnObjcs] != null) {
                if (_eCrrnObjcs == eObjcs) {
                    return;
                }
                _iObjcss[_eCrrnObjcs].Ruin();
                _objcsPrm.Omt(_eCrrnObjcs);
            }
            _eCrrnObjcs = eObjcs;
            _objcsPrm.Prm(_eCrrnObjcs);
            _iObjcss[_eCrrnObjcs].Found(rtTrnsfrm);
        }
 
        public void Ruin() { // ruin
            if (_iObjcss[_eCrrnObjcs] != null) {
                _iObjcss[_eCrrnObjcs].Ruin();
                _objcsPrm.Omt(_eCrrnObjcs);
            }
        }

        public IObjcs GtIObjcs() {
            return _iObjcss[_eCrrnObjcs];
        }

        public bool IsFound(byte eObjcs) { // return is specific hub connected or not
            return _iObjcss[eObjcs] == null ? false : true;
        }

        public SObjc GtSObjc(byte eObjc, int id) {
            return _iObjcss[_eCrrnObjcs].GtSObjc(eObjc, id);
        }

        public SObjc[] GtSObjcs(byte eObjc) {
            return _iObjcss[_eCrrnObjcs].GtSObjcs(eObjc);
        }

        public GameObject GtGmObjc(byte eObjc, int id) {
            return _iObjcss[_eCrrnObjcs].GtGmObjc(eObjc, id);
        }

        public GameObject[] GtGmObjcs(byte eObjc) {
            return _iObjcss[_eCrrnObjcs].GtGmObjcs(eObjc);
        }

        public T GtInst<T>(byte eObjc, int id) {
            return _iObjcss[_eCrrnObjcs].GtInst<T>(eObjc, id);
        }

        public T[] GtInsts<T>(byte eObjc) {
            return _iObjcss[_eCrrnObjcs].GtInsts<T>(eObjc);
        }

        public void MltpCrt(byte[][] eObjcs, DActn dCrt = null) {
            _iObjcss[_eCrrnObjcs].MltpCrt(eObjcs, dCrt);
        }

        public void Crt(byte eObjc, byte amnt, DActn dCrt = null) {
            _iObjcss[_eCrrnObjcs].Crt(eObjc, amnt, dCrt);
        }

        public void Dlt(byte eObjc, int id) {
            _iObjcss[_eCrrnObjcs].Dlt(eObjc, id);
        }

        public void Enbl(byte eObjc, DActn<SObjc> dActn = null) {
            _iObjcss[_eCrrnObjcs].Enbl(eObjc, dActn);
        }

        public void Dsbl(byte eObjc, int id) {
            _iObjcss[_eCrrnObjcs].Dsbl(eObjc, id);
        }
    }
}