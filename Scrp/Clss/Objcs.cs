using System;
using UnityEngine;

namespace T {

    public abstract class Objcs { // objects

        public enum ESt : byte {
            Enbl = 0,
            Id = 1,
            Inst = 2,
            Objc = 3,
        }

        public ObjcsMngr Mngr { set { _mngr = value; } } // set manager
        public bool IsFound { get { return _isFound; } } // get is founded or not
        protected Transform _rtTrnsfrm = null;
        protected ObjcsMngr _mngr = null;
        protected SObjc[][] _sObjcArry = null;
        protected string[] _kyArry = null;

        private bool _isFound = false;

        public void Found(Transform rtTrnsfrm) { // found
            if (_isFound) {
                return;
            }
            _isFound = true;
            _rtTrnsfrm = rtTrnsfrm;
        }

        public void Ruin() { // cease
            if (!_isFound) {
                return;
            }
            _isFound = false;
            _rtTrnsfrm = null;
            _mngr = null;
            _sObjcArry = null;
            _kyArry = null;
        }

        public GameObject[] GtGmObjcArry(byte eObjc) { // get the array of GameObjects
            GameObject[] gmObjcArry = new GameObject[_sObjcArry[eObjc].Length];
            for (byte o = 0; o < _sObjcArry[eObjc].Length; o++) {
                gmObjcArry[o] = _sObjcArry[eObjc][o].GmObjc;
            }
            return gmObjcArry;
        }

        public GameObject GtGmObjc(byte eObjc, int id) { // get GameObject
            int indx = Indx(eObjc, id);
            if (indx < 0) {
                return null;
            }
            return _sObjcArry[eObjc][indx].GmObjc;
        }

        public SObjc[] GtSObjcArry(byte eObjc) { // get the array of instances
            SObjc[] objcArry = new SObjc[_sObjcArry[eObjc].Length];
            for (byte o = 0; o < _sObjcArry[eObjc].Length; o++) {
                objcArry[o] = _sObjcArry[eObjc][o];
            }
            return objcArry;
        }

        public SObjc GtSObjc(byte eObjc, int id) { // get instance
            int indx = Indx(eObjc, id);
            if (indx < 0) {
                return null;
            }
            return _sObjcArry[eObjc][indx];
        }

        public T[] GtInstArry<T>(byte eObjc) { // get the array of instances
            T[] instArry = new T[_sObjcArry[eObjc].Length];
            for (byte o = 0; o < _sObjcArry[eObjc].Length; o++) {
                instArry[o] = (T)_sObjcArry[eObjc][o].Inst;
            }
            return instArry;
        }

        public T GtInst<T>(byte eObjc, int id) { // get instance
            int indx = Indx(eObjc, id);
            if (indx < 0) {
                return default(T);
            }
            return (T)_sObjcArry[eObjc][indx].Inst;
        }

        public void MltpCrt(byte[][] eObjcArry, DActn dCrt = null) { // multiple create
            if (!_isFound) {
                return;
            }
            byte cnt = 0;
            for (byte e = 0; e < eObjcArry.Length; e++) {
                Crt(eObjcArry[e][0], eObjcArry[e][1], () => {
                    cnt += 1;
                    if (cnt == eObjcArry.Length) {
                        dCrt?.Invoke();
                    }
                });
            }
        }

        public void Crt(byte eObjc, int amnt, DActn dInst = null) { // create
            if (!_isFound) {
                return;
            }
            SObjc[] sObjcArry = new SObjc[amnt];
            int cnt = 0;
            for (int a = 0; a < amnt; a++) {
                Rsrc.Inst(
                    _kyArry[eObjc],
                    _rtTrnsfrm,
                    (gmObjc) => {
                        gmObjc.name = gmObjc.name.Split("(")[0] + "_e" + eObjc;
                        sObjcArry[cnt] = CrtObjc(eObjc, gmObjc);
                        cnt += 1;
                        if (cnt == amnt) {
                            _sObjcArry[eObjc] = Arry.Apnd<SObjc>(_sObjcArry[eObjc], sObjcArry);
                            sObjcArry = null;
                            dInst?.Invoke();
                        }
                    }
                );
            }
        }

        public void Dlt(byte eObjc, int id) { // delete
            int indx = Indx(eObjc, id);
            if (indx < 0) {
                return;
            }
            UnityEngine.Object.Destroy(_sObjcArry[eObjc][indx].GmObjc);
            _sObjcArry[eObjc] = Arry.Rmv<SObjc>(_sObjcArry[eObjc], indx);
        }

        public void Enbl(byte eObjc, DActn<SObjc> dActn = null) { // request
            int indx = SwtcNxt(eObjc, true);
            if (indx >= 0) {
                SwtcObjc(eObjc, indx, true);
                dActn?.Invoke(_sObjcArry[eObjc][indx]);
            } else {
                indx = _sObjcArry[eObjc].Length;
                Crt(eObjc, _sObjcArry[eObjc].Length, () => {
                    SwtcObjc(eObjc, indx, true);
                    dActn?.Invoke(_sObjcArry[eObjc][indx]);
                });
            }
        }

        public void Dsbl(byte eObjc) {
            SwtcObjc(eObjc, SwtcNxt(eObjc, false), false);
        }

        public void Dsbl(byte eObjc, int id) {
            SwtcObjc(eObjc, Indx(eObjc, id), false);
        }

        protected abstract object NwObjc(byte eObjc, GameObject gmObjc);

        protected abstract void SwtcInst(object inst, bool bln);

        private SObjc CrtObjc(byte eObjc, GameObject gmObjc) { // create object
            return new SObjc(false, eObjc, NwObjc(eObjc, gmObjc), gmObjc);
        }

        private int Indx(byte eObjc, int id) {
            int strt = 0;
            int end = _sObjcArry[eObjc].Length - 1;
            int mddl;
            while (end >= strt) {
                mddl = strt + ((end - strt) >> 1);
                if (id == _sObjcArry[eObjc][mddl].Id) {
                    return mddl;
                } else if (id < _sObjcArry[eObjc][mddl].Id) {
                    strt = mddl + 1;
                } else {
                    end = mddl - 1;
                }
            }
            return -1;
        }

        private int SwtcNxt(byte eObjc, bool bln) {
            for (int s = 0; s < _sObjcArry[eObjc].Length; s++) {
                if (_sObjcArry[eObjc][s].IsEnbl == bln) {
                    return s;
                }
            }
            return -1;
        }

        private void SwtcObjc(byte eObjc, int indx, bool bln) {
            _sObjcArry[eObjc][indx].IsEnbl = bln;
            _sObjcArry[eObjc][indx].GmObjc.SetActive(bln);
            SwtcInst(_sObjcArry[eObjc][indx].Inst, bln);
        }
    }
}