using UnityEngine;

namespace T {

    public class HbMngr : Sngltn<HbMngr>, IMngr { // hub manager

        public bool IsIntl { get { return _isIntl; } }
        private IHb[] _iHbArry = null;
        private HbPrm _hbPrm = null;
        private byte _eHb = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Dscnnc();
            _hbPrm = null;
            _iHbArry = null;
        }

        public void Intl(IPrm iPrm) { // inithublize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _hbPrm = (HbPrm)iPrm;
            _iHbArry = _hbPrm.IHbArry;
        }

        public void Cnnc(byte eHb) { // connect
            if (_iHbArry[_eHb] != null) {
                if (_eHb == eHb) {
                    return;
                }
                _iHbArry[_eHb].Dscnnc();
                _hbPrm.Omt(_eHb);
            }
            _eHb = eHb;
            _hbPrm.Prm(_eHb);
            _iHbArry[_eHb].Cnnc();
        }
 
        public void Dscnnc() { // disconnect
            if (_iHbArry[_eHb] != null) {
                _iHbArry[_eHb].Dscnnc();
                _hbPrm.Omt(_eHb);
            }
        }

        public void PrpUpdt() { // prop update
            _iHbArry[_eHb]?.PrpUpdt();
        }

        public IHb IHb() {
            return _iHbArry[_eHb];
        }

        public bool IsCnnc(byte eHb) { // return is specific hub connected or not
            return _iHbArry[eHb] == null ? false : true;
        }

        public void Ract(byte eRact, object vl) {
            _iHbArry[_eHb].Ract(eRact, vl);
        }

        public void Act(byte eAct) {
            _iHbArry[_eHb].Act(eAct);
        }

        public void Oprt(byte eOprt) {
            _iHbArry[_eHb].Oprt(eOprt);
        }

        public void Abst(byte eOprt) {
            _iHbArry[_eHb].Abst(eOprt);
        }

        public void StTrnsfrm(byte eTrnsfrm, Transform vl) {
            _iHbArry[_eHb].StTrnsfrm(eTrnsfrm, vl);
        }

        public Transform GtTrnsfrm(byte eTrnsfrm) {
            return _iHbArry[_eHb].GtTrnsfrm(eTrnsfrm);
        }

        public void St<T>(byte eVl, T vl) {
            _iHbArry[_eHb].St<T>(eVl, vl);
        }

        public T Gt<T>(byte eVl) {
            return _iHbArry[_eHb].Gt<T>(eVl);
        }

        public void StStrn(byte eStrn, string vl){
            _iHbArry[_eHb].StStrn(eStrn, vl);
        }

        public string GtStrn(byte eStrn) {
            return _iHbArry[_eHb].GtStrn(eStrn);
        }

        public void StFlt(byte eFlt, float vl) {
            _iHbArry[_eHb].StFlt(eFlt, vl);
        }

        public float GtFlt(byte eFlt) {
            return _iHbArry[_eHb].GtFlt(eFlt);
        }

        public void StInt(byte eInt, int vl) {
            _iHbArry[_eHb].StInt(eInt, vl);
        }

        public int GtInt(byte eInt) {
            return _iHbArry[_eHb].GtInt(eInt);
        }

        public void StBln(byte eBln, bool vl) {
            _iHbArry[_eHb].StBln(eBln, vl);
        }

        public bool GtBln(byte eBln) {
            return _iHbArry[_eHb].GtBln(eBln);
        }
    }
}