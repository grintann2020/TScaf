using UnityEngine;

namespace T {

    public class ObjsMng : Sng<ObjsMng>, IMng { // data manager

        public bool IsInt { get { return _isInt; } }
        private IObjs[] _iObjsArr = null;
        private ObjsPrm _objsPrm = null;
        private byte _eCrrObjs = 0;
        private bool _isInt = false;

        public void Rst() { // reset
            if (!_isInt) {
                return;
            }
            _isInt = false;
            Rn();
            _objsPrm = null;
            _iObjsArr = null;
        }

        public void Int(IPrm iPrm) { // initialize
            if (_isInt) {
                return;
            }
            _isInt = true;
            _objsPrm = (ObjsPrm)iPrm;
            _iObjsArr = _objsPrm.IObjsArr;
        }

        public void Fnd(byte eObjs, Transform rtTrnsfrm) { // found
            if (_iObjsArr[_eCrrObjs] != null) {
                if (_eCrrObjs == eObjs) {
                    return;
                }
                _iObjsArr[_eCrrObjs].Rn();
                _objsPrm.Omt(_eCrrObjs);
            }
            _eCrrObjs = eObjs;
            _objsPrm.Prm(_eCrrObjs);
            _iObjsArr[_eCrrObjs].Fnd(rtTrnsfrm);
        }
 
        public void Rn() { // ruin
            if (_iObjsArr[_eCrrObjs] != null) {
                _iObjsArr[_eCrrObjs].Rn();
                _objsPrm.Omt(_eCrrObjs);
            }
        }

        public IObjs GtIObjs() {
            return _iObjsArr[_eCrrObjs];
        }

        public bool IsFnd(byte eObjs) { // return is specific hub connected or not
            return _iObjsArr[eObjs] == null ? false : true;
        }

        public SObj GtSObj(byte eObj, int id) {
            return _iObjsArr[_eCrrObjs].GtSObj(eObj, id);
        }

        public SObj[] GtSObjArr(byte eObj) {
            return _iObjsArr[_eCrrObjs].GtSObjArr(eObj);
        }

        public GameObject GtGO(byte eObj, int id) {
            return _iObjsArr[_eCrrObjs].GtGO(eObj, id);
        }

        public GameObject[] GtGOs(byte eObj) {
            return _iObjsArr[_eCrrObjs].GtGOArr(eObj);
        }

        public T GtInst<T>(byte eObj, int id) {
            return _iObjsArr[_eCrrObjs].GtIns<T>(eObj, id);
        }

        public T[] GtInsts<T>(byte eObj) {
            return _iObjsArr[_eCrrObjs].GtInsArr<T>(eObj);
        }

        public void MltCrt(byte[][] eObjs, DAct dCrt = null) {
            _iObjsArr[_eCrrObjs].MltCrt(eObjs, dCrt);
        }

        public void Crt(byte eObj, byte amnt, DAct dCrt = null) {
            _iObjsArr[_eCrrObjs].Crt(eObj, amnt, dCrt);
        }

        public void Dlt(byte eObj, int id) {
            _iObjsArr[_eCrrObjs].Dlt(eObj, id);
        }

        public void Enb(byte eObj, DRct<SObj> dEnbl = null) {
            _iObjsArr[_eCrrObjs].Enb(eObj, dEnbl);
        }

        public void Dsb(byte eObj, int id) {
            _iObjsArr[_eCrrObjs].Dsb(eObj, id);
        }
    }
}