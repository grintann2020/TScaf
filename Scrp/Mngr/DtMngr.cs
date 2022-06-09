using UnityEngine;

namespace T {

    public class DtMngr : Sngltn<DtMngr>, IMngr { // data manager

        public bool IsIntl { get { return _isIntl; } }
        private IDt[] _iDtArry = null;
        private DtPrm _hbPrm = null;
        private byte _eDt = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Cs();
            _hbPrm = null;
            _iDtArry = null;
        }

        public void Intl(IPrm iPrm) { // inithublize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _hbPrm = (DtPrm)iPrm;
            _iDtArry = _hbPrm.IDtArry;
        }

        public void Appl(byte eDt) { // connect
            if (_iDtArry[_eDt] != null) {
                if (_eDt == eDt) {
                    return;
                }
                _iDtArry[_eDt].Cs();
                _hbPrm.Omt(_eDt);
            }
            _eDt = eDt;
            _hbPrm.Prm(_eDt);
            _iDtArry[_eDt].Appl();
        }
 
        public void Cs() { // disconnect
            if (_iDtArry[_eDt] != null) {
                _iDtArry[_eDt].Cs();
                _hbPrm.Omt(_eDt);
            }
        }

        public void PrpUpdt() { // prop update
            _iDtArry[_eDt]?.PrpUpdt();
        }

        public IDt IDt() {
            return _iDtArry[_eDt];
        }

        public bool IsAppl(byte eDt) { // return is specific hub connected or not
            return _iDtArry[eDt] == null ? false : true;
        }

        public void Ract(byte eRact, object vl) {
            _iDtArry[_eDt].Ract(eRact, vl);
        }

        public void Act(byte eAct) {
            _iDtArry[_eDt].Act(eAct);
        }

        public void Oprt(byte eOprt) {
            _iDtArry[_eDt].Oprt(eOprt);
        }

        public void Abst(byte eOprt) {
            _iDtArry[_eDt].Abst(eOprt);
        }

        public void StTrnsfrm(byte eTrnsfrm, Transform vl) {
            _iDtArry[_eDt].StTrnsfrm(eTrnsfrm, vl);
        }

        public Transform GtTrnsfrm(byte eTrnsfrm) {
            return _iDtArry[_eDt].GtTrnsfrm(eTrnsfrm);
        }

        public void St<T>(byte eVl, T vl) {
            _iDtArry[_eDt].St<T>(eVl, vl);
        }

        public T Gt<T>(byte eVl) {
            return _iDtArry[_eDt].Gt<T>(eVl);
        }

        public void StStrn(byte eStrn, string vl){
            _iDtArry[_eDt].StStrn(eStrn, vl);
        }

        public string GtStrn(byte eStrn) {
            return _iDtArry[_eDt].GtStrn(eStrn);
        }

        public void StFlt(byte eFlt, float vl) {
            _iDtArry[_eDt].StFlt(eFlt, vl);
        }

        public float GtFlt(byte eFlt) {
            return _iDtArry[_eDt].GtFlt(eFlt);
        }

        public void StInt(byte eInt, int vl) {
            _iDtArry[_eDt].StInt(eInt, vl);
        }

        public int GtInt(byte eInt) {
            return _iDtArry[_eDt].GtInt(eInt);
        }

        public void StBln(byte eBln, bool vl) {
            _iDtArry[_eDt].StBln(eBln, vl);
        }

        public bool GtBln(byte eBln) {
            return _iDtArry[_eDt].GtBln(eBln);
        }
    }
}