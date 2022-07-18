using UnityEngine;

namespace T {

    public class DtMng : Sng<DtMng>, IMng { // data manager

        public bool IsInt { get { return _isInt; } }
        private IDt[] _iDtArr = null;
        private DtPrm _dtPrm = null;
        private byte _eCrrDt = 0;
        private bool _isInt = false;

        public void Rst() { // reset
            if (!_isInt) {
                return;
            }
            _isInt = false;
            Cs();
            _dtPrm = null;
            _iDtArr = null;
        }

        public void Int(IPrm iPrm) { // inithublize
            if (_isInt) {
                return;
            }
            _isInt = true;
            _dtPrm = (DtPrm)iPrm;
            _iDtArr = _dtPrm.IDtArr;
        }

        public void App(byte eDt) { // apply
            if (_iDtArr[_eCrrDt] != null) {
                if (_eCrrDt == eDt) {
                    return;
                }
                _iDtArr[_eCrrDt].Cs();
                _dtPrm.Omt(_eCrrDt);
            }
            _eCrrDt = eDt;
            _dtPrm.Prm(_eCrrDt);
            _iDtArr[_eCrrDt].App();
        }
 
        public void Cs() { // cease
            if (_iDtArr[_eCrrDt] != null) {
                _iDtArr[_eCrrDt].Cs();
                _dtPrm.Omt(_eCrrDt);
            }
        }

        public void PrpUpd() { // prop update
            _iDtArr[_eCrrDt]?.PrpUpd();
        }

        public IDt GtIDt() {
            return _iDtArr[_eCrrDt];
        }

        public bool IsApp(byte eDt) { // return is specific hub connected or not
            return _iDtArr[eDt] == null ? false : true;
        }

        public void Rct(byte eRact, object vl) {
            _iDtArr[_eCrrDt].Rct(eRact, vl);
        }

        public void Act(byte eAct) {
            _iDtArr[_eCrrDt].Act(eAct);
        }

        public void Opr(byte eOprt) {
            _iDtArr[_eCrrDt].Opr(eOprt);
        }

        public void Abs(byte eOprt) {
            _iDtArr[_eCrrDt].Abs(eOprt);
        }

        public void StTf(byte eTrnsfrm, Transform vl) {
            _iDtArr[_eCrrDt].StTf(eTrnsfrm, vl);
        }

        public Transform GtTf(byte eTrnsfrm) {
            return _iDtArr[_eCrrDt].GtTf(eTrnsfrm);
        }

        public void St<T>(byte eVl, T vl) {
            _iDtArr[_eCrrDt].St<T>(eVl, vl);
        }

        public T Gt<T>(byte eVl) {
            return _iDtArr[_eCrrDt].Gt<T>(eVl);
        }

        public void StStr(byte eStrn, string vl){
            _iDtArr[_eCrrDt].StStr(eStrn, vl);
        }

        public string GtStr(byte eStrn) {
            return _iDtArr[_eCrrDt].GtStr(eStrn);
        }

        public void StFlt(byte eFlt, float vl) {
            _iDtArr[_eCrrDt].StFlt(eFlt, vl);
        }

        public float GtFlt(byte eFlt) {
            return _iDtArr[_eCrrDt].GtFlt(eFlt);
        }

        public void StInt(byte eInt, int vl) {
            _iDtArr[_eCrrDt].StInt(eInt, vl);
        }

        public int GtInt(byte eInt) {
            return _iDtArr[_eCrrDt].GtInt(eInt);
        }

        public void StBln(byte eBln, bool vl) {
            _iDtArr[_eCrrDt].StBln(eBln, vl);
        }

        public bool GtBln(byte eBln) {
            return _iDtArr[_eCrrDt].GtBln(eBln);
        }
    }
}