using System;
using UnityEngine;

namespace T {

    public class Hb { // hub

        public HbMngr Mngr { set { _mngr = value; } } // set manager
        public bool IsCnnc { get { return _isCnnc; } } // get is connected or not
        protected DActn<object>[] _dRactArry; // an array of react delegate
        protected DActn[] _dActArry; // an array of act delegate
        protected DActn[] _dGrtOprtArry;
        protected DActn[] _dOprtArry; // an array of operate delegate
        protected Transform[] _trnsfrmArry;
        protected HbMngr _mngr = null;
        protected object[] _objcArry;
        protected string[] _strnArry;
        protected float[] _fltArry;
        protected int[] _intArry;
        protected bool[] _blnArry;
        private bool _isCnnc;

        public virtual void Cnnc() { // connect
            if (_isCnnc) {
                return;
            }
            _isCnnc = true;
        }

        public virtual void Dscnnc() { // disconnect
            if (!_isCnnc) {
                return;
            }
            _isCnnc = false;
        }

        public void PrpUpdt() { // prop update
            if (!_isCnnc) {
                return;
            }
            for (byte e = 0; e < _dOprtArry.Length; e++) {
                _dOprtArry[e]?.Invoke();
            }
        }

        public void Ract(byte eRact, object vl) { // react
            _dRactArry[eRact]?.Invoke(vl);
        }

        public void Act(byte eAct) { //act
            _dActArry[eAct]?.Invoke();
        }

        public void Oprt(byte eOprt) { // operate
            if (_dOprtArry[eOprt] == null) {
                _dGrtOprtArry[eOprt]?.Invoke();
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

        public void StBln(byte eBln, bool vl) {
            _blnArry[eBln] = vl;
        }

        public bool GtBln(byte eBln) {
            return _blnArry[eBln];
        }
    }
}