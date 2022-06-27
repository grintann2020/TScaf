using UnityEngine;

namespace T {

    public class Data { // data

        public DataMngr Mngr { set { _mngr = value; } } // set manager
        public bool IsAppl { get { return _isAppl; } } // get is applied or not
        protected DActn<object>[] _dActAArry = null; // an array of react delegate
        protected DActn[] _dActArry = null; // an array of act delegate
        protected DActn[] _dCrtOprtArry = null; // an array of create operate delegate
        protected DActn[] _dOprtArry; // an array of operate delegate
        protected Transform[][] _trnsfrmsArry = null;
        protected Transform[] _trnsfrmArry = null;
        protected DataMngr _mngr = null;
        protected string[][] _strnsArry = null;
        protected float[][] _fltsArry = null;
        protected int[][] _intsArry = null;
        protected byte[][] _bytsArry = null;
        protected bool[][] _blnsArry = null;
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
            _trnsfrmsArry = null;
            _trnsfrmArry = null;
            _objcArry = null;
            _strnsArry = null;
            _strnArry = null;
            _fltsArry = null;
            _fltArry = null;
            _intsArry = null;
            _intArry = null;
            _bytsArry = null;
            _bytArry = null;
            _blnsArry = null;
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

        public void StTrnsfrmArry(byte eTrnsfrms, Transform[] vlArry) {
            _trnsfrmsArry[eTrnsfrms] = vlArry;
        }

        public void StTrnsfrm(byte eTrnsfrm, Transform vl) {
            _trnsfrmArry[eTrnsfrm] = vl;
        }

        public Transform[] GtTrnsfrmArry(byte eTrnsfrms) {
            return _trnsfrmsArry[eTrnsfrms];
        }

        public Transform GtTrnsfrm(byte eTrnsfrm) {
            return _trnsfrmArry[eTrnsfrm];
        }

        public void StStrnArry(byte eFlts, string[] vlArry) {
            _strnsArry[eFlts] = vlArry;
        }

        public void StStrn(byte eFlt, string vl) {
            _strnArry[eFlt] = vl;
        }

        public string[] GtStrnArry(byte eStrns) {
            return _strnsArry[eStrns];
        }

        public string GtStrn(byte eStrn) {
            return _strnArry[eStrn];
        }

        public void StFltArry(byte eFlts, float[] vlArry) {
            _fltsArry[eFlts] = vlArry;
        }

        public void StFlt(byte eFlt, float vl) {
            _fltArry[eFlt] = vl;
        }

        public float[] GtFltArry(byte eFlts) {
            return _fltsArry[eFlts];
        }

        public float GtFlt(byte eFlt) {
            return _fltArry[eFlt];
        }

        public void StIntArry(byte eInts, int[] vlArry) {
            _intsArry[eInts] = vlArry;
        }

        public void StInt(byte eInt, int vl) {
            _intArry[eInt] = vl;
        }

        public int[] GtIntArry(byte eInts) {
            return _intsArry[eInts];
        }

        public int GtInt(byte eInt) {
            return _intArry[eInt];
        }

        public void StBytArry(byte eByts, byte[] vlArry) {
            _bytsArry[eByts] = vlArry;
        }

        public void StByt(byte eByt, byte vl) {
            _bytArry[eByt] = vl;
        }

        public byte[] GtBytArry(byte eByts) {
            return _bytsArry[eByts];
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