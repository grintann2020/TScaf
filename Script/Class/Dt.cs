using UnityEngine;

namespace T {

    public class Dt { // data

        public DtMng Mng { set { _mng = value; } } // set manager
        public bool IsApp { get { return _isApp; } } // get is applied or not
        protected DRct<object>[] _dRctArr = null; // an array of react delegate
        protected DAct[] _dActArr = null; // an array of act delegate
        protected DAct[] _dCrtOprArr = null; // an array of create operate delegate
        protected DAct[] _dOprArr; // an array of operate delegate
        protected Transform[][] _tfArr2 = null;
        protected Transform[] _tfArr = null;
        protected DtMng _mng = null;
        protected string[][] _strArr2 = null;
        protected float[][] _fltArr2 = null;
        protected int[][] _intArr2 = null;
        protected byte[][] _bytArr2 = null;
        protected bool[][] _blnArr2 = null;
        protected object[] _objArr = null;
        protected string[] _strArr = null;
        protected float[] _fltArr = null;
        protected int[] _intArr = null;
        protected byte[] _bytArr = null;
        protected bool[] _blnArr = null;
        private bool _isApp = false;

        public void App() { // apply
            if (_isApp) {
                return;
            }
            _isApp = true;
        }

        public void Cs() { // cease
            if (!_isApp) {
                return;
            }
            _isApp = false;
            _mng = null;
            _dRctArr = null;
            _dActArr = null;
            _dCrtOprArr = null;
            _dOprArr = null;
            _tfArr2 = null;
            _tfArr = null;
            _objArr = null;
            _strArr2 = null;
            _strArr = null;
            _fltArr2 = null;
            _fltArr = null;
            _intArr2 = null;
            _intArr = null;
            _bytArr2 = null;
            _bytArr = null;
            _blnArr2 = null;
            _blnArr = null;
        }

        public void PrpUpd() { // prop update
            if (!_isApp || _dOprArr == null) {
                return;
            }
            for (byte e = 0; e < _dOprArr.Length; e++) {
                _dOprArr[e]?.Invoke();
            }
        }

        public void Rct(byte eRact, object vl) { // react
            _dRctArr[eRact]?.Invoke(vl);
        }

        public void Act(byte eAct) { // act
            _dActArr[eAct]?.Invoke();
        }

        public void Opr(byte eOpr) { // operate
            if (_dOprArr[eOpr] == null) {
                _dCrtOprArr[eOpr]?.Invoke();
            }
        }

        public void Abs(byte eOpr) { // abstain
            if (_dOprArr[eOpr] != null) {
                _dOprArr[eOpr] = null;
            }
        }

        public void St<T>(byte eObjc, T vl) {
            _objArr[eObjc] = vl;
        }

        public T Gt<T>(byte eObjc) {
            return (T)_objArr[eObjc];
        }

        public void StTfArr(byte eTfArr, Transform[] vlArr) {
            _tfArr2[eTfArr] = vlArr;
        }

        public void StTf(byte eTf, Transform vl) {
            _tfArr[eTf] = vl;
        }

        public Transform[] GtTfArr(byte eTfArr) {
            return _tfArr2[eTfArr];
        }

        public Transform GtTf(byte eTf) {
            return _tfArr[eTf];
        }

        public void StStrArr(byte eFltArr, string[] vlArr) {
            _strArr2[eFltArr] = vlArr;
        }

        public void StStr(byte eFlt, string vl) {
            _strArr[eFlt] = vl;
        }

        public string[] GtStrArr(byte eStrArr) {
            return _strArr2[eStrArr];
        }

        public string GtStr(byte eStr) {
            return _strArr[eStr];
        }

        public void StFltArr(byte eFltArr, float[] vlArr) {
            _fltArr2[eFltArr] = vlArr;
        }

        public void StFlt(byte eFlt, float vl) {
            _fltArr[eFlt] = vl;
        }

        public float[] GtFltArr(byte eFltArr) {
            return _fltArr2[eFltArr];
        }

        public float GtFlt(byte eFlt) {
            return _fltArr[eFlt];
        }

        public void StIntArr(byte eIntArr, int[] vlArr) {
            _intArr2[eIntArr] = vlArr;
        }

        public void StInt(byte eInt, int vl) {
            _intArr[eInt] = vl;
        }

        public int[] GtIntArr(byte eIntArr) {
            return _intArr2[eIntArr];
        }

        public int GtInt(byte eInt) {
            return _intArr[eInt];
        }

        public void StBytArr(byte eBytArr, byte[] vlArr) {
            _bytArr2[eBytArr] = vlArr;
        }

        public void StByt(byte eByt, byte vl) {
            _bytArr[eByt] = vl;
        }

        public byte[] GtBytArr(byte eBytArr) {
            return _bytArr2[eBytArr];
        }

        public byte GtByt(byte eByt) {
            return _bytArr[eByt];
        }

        public void StBln(byte eBln, bool vl) {
            _blnArr[eBln] = vl;
        }

        public bool GtBln(byte eBln) {
            return _blnArr[eBln];
        }
    }
}