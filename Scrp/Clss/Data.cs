using UnityEngine;

namespace T {

    public class Data { // data

        public DataMngr Mngr { set { _mngr = value; } } // set manager
        public bool IsAppl { get { return _isAppl; } } // get is applied or not
        protected DActn<object>[] _dActAArry = null; // an array of react delegate
        protected DActn[] _dActArry = null; // an array of act delegate
        protected DActn[] _dCrtOprtArry = null; // an array of create operate delegate
        protected DActn[] _dOprtArry; // an array of operate delegate
        protected Transform[] _trnsfrmArry = null;
        protected DataMngr _mngr = null;
        protected object[] _objcArry = null;
        protected string[] _strnArry = null;
        protected float[] _fltArry = null;
        protected int[] _intArry = null;
        protected byte[] _bytArry = null;
        protected bool[] _blnArry = null;
        private bool _isAppl = false;

        public void Appl() { // apply
            if (_isAppl) {
                return;
            }
            _isAppl = true;
        }

        public void Cs() { // cease
            if (!_isAppl) {
                return;
            }
            _isAppl = false;
            _mngr = null;
            _dActAArry = null;
            _dActArry = null;
            _dCrtOprtArry = null;
            _dOprtArry = null;
            _trnsfrmArry = null;
            _objcArry = null;
            _strnArry = null;
            _fltArry = null;
            _intArry = null;
            _bytArry = null;
            _blnArry = null;
        }

        public void PrpUpdt() { // prop update
            if (!_isAppl || _dOprtArry == null) {
                return;
            }
            for (byte e = 0; e < _dOprtArry.Length; e++) {
                _dOprtArry[e]?.Invoke();
            }
        }

        public void Ract(byte eRact, object vl) { // react
            _dActAArry[eRact]?.Invoke(vl);
        }

        public void Act(byte eAct) { // act
            _dActArry[eAct]?.Invoke();
        }

        public void Oprt(byte eOprt) { // operate
            if (_dOprtArry[eOprt] == null) {
                _dCrtOprtArry[eOprt]?.Invoke();
            }
        }

        public void Abst(byte eOprt) { // abstain
            if (_dOprtArry[eOprt] != null) {
                _dOprtArry[eOprt] = null;
            }
        }

        public void St<T>(byte eObjc, T vl) {
            _objcArry[eObjc] = vl;
        }

        public T Gt<T>(byte eObjc) {
            return (T)_objcArry[eObjc];
        }

        public void StTrnsfrm(byte eTrnsfrm, Transform vl) {
            _trnsfrmArry[eTrnsfrm] = vl;
        }

        public Transform GtTrnsfrm(byte eTrnsfrm) {
            return _trnsfrmArry[eTrnsfrm];
        }

        public void StStrn(byte eFlt, string vl) {
            _strnArry[eFlt] = vl;
        }

        public string GtStrn(byte eStrn) {
            return _strnArry[eStrn];
        }

        public void StFlt(byte eFlt, float vl) {
            _fltArry[eFlt] = vl;
        }

        public float GtFlt(byte eFlt) {
            return _fltArry[eFlt];
        }

        public void StInt(byte eInt, int vl) {
            _intArry[eInt] = vl;
        }

        public int GtInt(byte eInt) {
            return _intArry[eInt];
        }

        public void StByt(byte eByt, byte vl) {
            _bytArry[eByt] = vl;
        }

        public byte GtByt(byte eByt) {
            return _bytArry[eByt];
        }

        public void StBln(byte eBln, bool vl) {
            _blnArry[eBln] = vl;
        }

        public bool GtBln(byte eBln) {
            return _blnArry[eBln];
        }
    }
}