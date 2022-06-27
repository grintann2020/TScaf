using UnityEngine;

namespace T {

    public class DataMngr : Sngltn<DataMngr>, IMngr { // data manager

        public bool IsIntl { get { return _isIntl; } }
        private IData[] _iDataArry = null;
        private DataPrm _dataPrm = null;
        private byte _eCrrnData = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Cs();
            _dataPrm = null;
            _iDataArry = null;
        }

        public void Intl(IPrm iPrm) { // inithublize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _dataPrm = (DataPrm)iPrm;
            _iDataArry = _dataPrm.IDataArry;
        }

        public void Appl(byte eData) { // apply
            if (_iDataArry[_eCrrnData] != null) {
                if (_eCrrnData == eData) {
                    return;
                }
                _iDataArry[_eCrrnData].Cs();
                _dataPrm.Omt(_eCrrnData);
            }
            _eCrrnData = eData;
            _dataPrm.Prm(_eCrrnData);
            _iDataArry[_eCrrnData].Appl();
        }
 
        public void Cs() { // cease
            if (_iDataArry[_eCrrnData] != null) {
                _iDataArry[_eCrrnData].Cs();
                _dataPrm.Omt(_eCrrnData);
            }
        }

        public void PrpUpdt() { // prop update
            _iDataArry[_eCrrnData]?.PrpUpdt();
        }

        public IData GtIData() {
            return _iDataArry[_eCrrnData];
        }

        public bool IsAppl(byte eData) { // return is specific hub connected or not
            return _iDataArry[eData] == null ? false : true;
        }

        public void Ract(byte eRact, object vl) {
            _iDataArry[_eCrrnData].Ract(eRact, vl);
        }

        public void Act(byte eAct) {
            _iDataArry[_eCrrnData].Act(eAct);
        }

        public void Oprt(byte eOprt) {
            _iDataArry[_eCrrnData].Oprt(eOprt);
        }

        public void Abst(byte eOprt) {
            _iDataArry[_eCrrnData].Abst(eOprt);
        }

        public void StTrnsfrm(byte eTrnsfrm, Transform vl) {
            _iDataArry[_eCrrnData].StTrnsfrm(eTrnsfrm, vl);
        }

        public Transform GtTrnsfrm(byte eTrnsfrm) {
            return _iDataArry[_eCrrnData].GtTrnsfrm(eTrnsfrm);
        }

        public void St<T>(byte eVl, T vl) {
            _iDataArry[_eCrrnData].St<T>(eVl, vl);
        }

        public T Gt<T>(byte eVl) {
            return _iDataArry[_eCrrnData].Gt<T>(eVl);
        }

        public void StStrn(byte eStrn, string vl){
            _iDataArry[_eCrrnData].StStrn(eStrn, vl);
        }

        public string GtStrn(byte eStrn) {
            return _iDataArry[_eCrrnData].GtStrn(eStrn);
        }

        public void StFlt(byte eFlt, float vl) {
            _iDataArry[_eCrrnData].StFlt(eFlt, vl);
        }

        public float GtFlt(byte eFlt) {
            return _iDataArry[_eCrrnData].GtFlt(eFlt);
        }

        public void StInt(byte eInt, int vl) {
            _iDataArry[_eCrrnData].StInt(eInt, vl);
        }

        public int GtInt(byte eInt) {
            return _iDataArry[_eCrrnData].GtInt(eInt);
        }

        public void StBln(byte eBln, bool vl) {
            _iDataArry[_eCrrnData].StBln(eBln, vl);
        }

        public bool GtBln(byte eBln) {
            return _iDataArry[_eCrrnData].GtBln(eBln);
        }
    }
}