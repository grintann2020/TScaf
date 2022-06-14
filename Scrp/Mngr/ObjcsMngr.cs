using UnityEngine;

namespace T {

    public class ObjcsMngr : Sngltn<ObjcsMngr>, IMngr { // data manager

        public bool IsIntl { get { return _isIntl; } }
        private IObjcs[] _iObjcsArry = null;
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
            _iObjcsArry = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _objcsPrm = (ObjcsPrm)iPrm;
            _iObjcsArry = _objcsPrm.IObjcsArry;
        }

        public void Found(byte eObjcs, Transform rtTrnsfrm) { // found
            if (_iObjcsArry[_eCrrnObjcs] != null) {
                if (_eCrrnObjcs == eObjcs) {
                    return;
                }
                _iObjcsArry[_eCrrnObjcs].Ruin();
                _objcsPrm.Omt(_eCrrnObjcs);
            }
            _eCrrnObjcs = eObjcs;
            _objcsPrm.Prm(_eCrrnObjcs);
            _iObjcsArry[_eCrrnObjcs].Found(rtTrnsfrm);
        }
 
        public void Ruin() { // ruin
            if (_iObjcsArry[_eCrrnObjcs] != null) {
                _iObjcsArry[_eCrrnObjcs].Ruin();
                _objcsPrm.Omt(_eCrrnObjcs);
            }
        }

        public IObjcs GtIObjcs() {
            return _iObjcsArry[_eCrrnObjcs];
        }

        public bool IsFound(byte eObjcs) { // return is specific hub connected or not
            return _iObjcsArry[eObjcs] == null ? false : true;
        }

        public SObjc GtSObjc(byte eObjc, int id) {
            return _iObjcsArry[_eCrrnObjcs].GtSObjc(eObjc, id);
        }

        public SObjc[] GtSObjcArry(byte eObjc) {
            return _iObjcsArry[_eCrrnObjcs].GtSObjcArry(eObjc);
        }

        public GameObject GtGmObjc(byte eObjc, int id) {
            return _iObjcsArry[_eCrrnObjcs].GtGmObjc(eObjc, id);
        }

        public GameObject[] GtGmObjcArry(byte eObjc) {
            return _iObjcsArry[_eCrrnObjcs].GtGmObjcArry(eObjc);
        }

        public T GtInst<T>(byte eObjc, int id) {
            return _iObjcsArry[_eCrrnObjcs].GtInst<T>(eObjc, id);
        }

        public T[] GtInstArry<T>(byte eObjc) {
            return _iObjcsArry[_eCrrnObjcs].GtInstArry<T>(eObjc);
        }

        public void MltpCrt(byte[][] eObjcArry, DActn dCrt = null) {
            _iObjcsArry[_eCrrnObjcs].MltpCrt(eObjcArry, dCrt);
        }

        public void Crt(byte eObjc, byte amnt, DActn dCrt = null) {
            _iObjcsArry[_eCrrnObjcs].Crt(eObjc, amnt, dCrt);
        }

        public void Dlt(byte eObjc, int id) {
            _iObjcsArry[_eCrrnObjcs].Dlt(eObjc, id);
        }

        public void Enbl(byte eObjc, DActn<SObjc> dActn) {
            _iObjcsArry[_eCrrnObjcs].Enbl(eObjc, dActn);
        }

        public void Dsbl(byte eObjc, int id) {
            _iObjcsArry[_eCrrnObjcs].Dsbl(eObjc, id);
        }
    }
}