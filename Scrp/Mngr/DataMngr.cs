using UnityEngine;

namespace T {

    public class DataMngr : Sngltn<DataMngr>, IMngr { // data manager

        public bool IsIntl { get { return _isIntl; } }
        private IData[] _iDatas = null;
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
            _iDatas = null;
        }

        public void Intl(IPrm iPrm) { // inithublize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _dataPrm = (DataPrm)iPrm;
            _iDatas = _dataPrm.IDatas;
        }

        public void Appl(byte eData) { // apply
            if (_iDatas[_eCrrnData] != null) {
                if (_eCrrnData == eData) {
                    return;
                }
                _iDatas[_eCrrnData].Cs();
                _dataPrm.Omt(_eCrrnData);
            }
            _eCrrnData = eData;
            _dataPrm.Prm(_eCrrnData);
            _iDatas[_eCrrnData].Appl();
        }
 
        public void Cs() { // cease
            if (_iDatas[_eCrrnData] != null) {
                _iDatas[_eCrrnData].Cs();
                _dataPrm.Omt(_eCrrnData);
            }
        }

        public void PrpUpdt() { // prop update
            _iDatas[_eCrrnData]?.PrpUpdt();
        }

        public IData GtIData() {
            return _iDatas[_eCrrnData];
        }

        public bool IsAppl(byte eData) { // return is specific hub connected or not
            return _iDatas[eData] == null ? false : true;
        }

        public void Ract(byte eRact, object vl) {
            _iDatas[_eCrrnData].Ract(eRact, vl);
        }

        public void Act(byte eAct) {
            _iDatas[_eCrrnData].Act(eAct);
        }

        public void Oprt(byte eOprt) {
            _iDatas[_eCrrnData].Oprt(eOprt);
        }

        public void Abst(byte eOprt) {
            _iDatas[_eCrrnData].Abst(eOprt);
        }

        public void StTrnsfrm(byte eTrnsfrm, Transform vl) {
            _iDatas[_eCrrnData].StTrnsfrm(eTrnsfrm, vl);
        }

        public Transform GtTrnsfrm(byte eTrnsfrm) {
            return _iDatas[_eCrrnData].GtTrnsfrm(eTrnsfrm);
        }

        public void St<T>(byte eVl, T vl) {
            _iDatas[_eCrrnData].St<T>(eVl, vl);
        }

        public T Gt<T>(byte eVl) {
            return _iDatas[_eCrrnData].Gt<T>(eVl);
        }

        public void StStrn(byte eStrn, string vl){
            _iDatas[_eCrrnData].StStrn(eStrn, vl);
        }

        public string GtStrn(byte eStrn) {
            return _iDatas[_eCrrnData].GtStrn(eStrn);
        }

        public void StFlt(byte eFlt, float vl) {
            _iDatas[_eCrrnData].StFlt(eFlt, vl);
        }

        public float GtFlt(byte eFlt) {
            return _iDatas[_eCrrnData].GtFlt(eFlt);
        }

        public void StInt(byte eInt, int vl) {
            _iDatas[_eCrrnData].StInt(eInt, vl);
        }

        public int GtInt(byte eInt) {
            return _iDatas[_eCrrnData].GtInt(eInt);
        }

        public void StBln(byte eBln, bool vl) {
            _iDatas[_eCrrnData].StBln(eBln, vl);
        }

        public bool GtBln(byte eBln) {
            return _iDatas[_eCrrnData].GtBln(eBln);
        }
    }
}