using System;
using UnityEngine;

namespace T {

    public abstract class Objcs { // objects

        public ObjcsMngr Mngr { set { _mngr = value; } } // set manager
        public bool IsFound { get { return _isFound; } } // get is founded or not
        protected Transform _rtTrnsfrm = null;
        protected ObjcsMngr _mngr = null;
        protected SObjc[][] _sObjcArry = null;
        protected string[] _kyArry = null;
        private DActn<SObjc>[][] _dActnQArry = null;
        private bool _isFound = false;

        public void Found(Transform rtTrnsfrm) { // found
            if (_isFound || rtTrnsfrm == null || _kyArry == null) {
                return;
            }
            _isFound = true;
            _rtTrnsfrm = rtTrnsfrm;
            _sObjcArry = new SObjc[_kyArry.Length][];
            _dActnQArry = new DActn<SObjc>[_kyArry.Length][];
            for (byte q = 0; q < _dActnQArry.Length; q++) {
                _dActnQArry[q] = new DActn<SObjc>[0];
            }
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
            _dActnQArry = null;
        }

        public GameObject[] GtGmObjcArry(byte eObjc) { // get the array of GameObjects
            GameObject[] gmObjcArry = new GameObject[_sObjcArry[eObjc].Length];
            for (byte o = 0; o < _sObjcArry[eObjc].Length; o++) {
                gmObjcArry[o] = _sObjcArry[eObjc][o].GmObjc;
            }
            return gmObjcArry;
        }

        public GameObject GtGmObjc(byte eObjc, int id) { // get GameObject
            return _sObjcArry[eObjc][Indx(eObjc, id)].GmObjc;
        }

        public SObjc[] GtSObjcArry(byte eObjc) { // get the array of SObjcs
            SObjc[] objcArry = new SObjc[_sObjcArry[eObjc].Length];
            for (byte o = 0; o < _sObjcArry[eObjc].Length; o++) {
                objcArry[o] = _sObjcArry[eObjc][o];
            }
            return objcArry;
        }

        public SObjc GtSObjc(byte eObjc, int id) { // get SObjc
            return _sObjcArry[eObjc][Indx(eObjc, id)];
        }

        public T[] GtInstArry<T>(byte eObjc) { // get the array of instances
            T[] instArry = new T[_sObjcArry[eObjc].Length];
            for (byte o = 0; o < _sObjcArry[eObjc].Length; o++) {
                instArry[o] = (T)_sObjcArry[eObjc][o].Inst;
            }
            return instArry;
        }

        public T GtInst<T>(byte eObjc, int id) { // get instance
            return (T)_sObjcArry[eObjc][Indx(eObjc, id)].Inst;
        }

        public void MltpCrt(byte[][] eObjcArry, DActn dCrt = null) { // multiple create
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
            SObjc[] sObjcArry = new SObjc[amnt];
            string[] kyArry = new string[amnt];
            for (int e = 0; e < amnt; e++) {
                kyArry[e] = _kyArry[eObjc];
            }
            Rsrc.Inst(
                kyArry,
                _rtTrnsfrm,
                (gmObjcArry) => {
                    string nm = gmObjcArry[0].name.Split("(")[0] + "_e" + eObjc;
                    for (int g = 0; g < gmObjcArry.Length; g++) {
                        gmObjcArry[g].name = nm;
                        sObjcArry[g] = CrtSObjc(eObjc, gmObjcArry[g]);
                    }
                    _sObjcArry[eObjc] = Arry.Apnd<SObjc>(_sObjcArry[eObjc], sObjcArry);
                    sObjcArry = null;
                    dInst?.Invoke();
                }
            );
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
            // Debug.Log("eObjc = " + eObjc + ", _dActnQArry[eObjc].Length =" + _dActnQArry[eObjc].Length);
            if (_dActnQArry[eObjc].Length == 0) {
                int indx = SwtcNxt(eObjc, false);
                if (indx >= 0) {
                    _sObjcArry[eObjc][indx].Enbl();
                    dActn?.Invoke(_sObjcArry[eObjc][indx]);
                } else {
                    _dActnQArry[eObjc] = Arry.Psh<DActn<SObjc>>(_dActnQArry[eObjc], dActn);
                    Rqst(eObjc, dActn);
                }
            } else {
                _dActnQArry[eObjc] = Arry.Psh<DActn<SObjc>>(_dActnQArry[eObjc], dActn);
            }
        }

        public void Dsbl(byte eObjc, int id) {
            _sObjcArry[eObjc][Indx(eObjc, id)].Dsbl();
        }

        public void Dsbl(byte eObjc) {
            _sObjcArry[eObjc][SwtcNxt(eObjc, true)].Dsbl();
        }

        protected abstract object NwInst(byte eObjc, GameObject gmObjc);

        private void Rqst(byte eObjc, DActn<SObjc> dActn = null) { // requisition
            int indx = SwtcNxt(eObjc, false);
            if (indx > 0) {
                _sObjcArry[eObjc][indx].Enbl();
                dActn?.Invoke(_sObjcArry[eObjc][indx]);
                _dActnQArry[eObjc] = Arry.Pp<DActn<SObjc>>(_dActnQArry[eObjc]);
                if (_dActnQArry[eObjc].Length != 0) {
                    Rqst(eObjc, _dActnQArry[eObjc][0]);
                }
            } else {
                indx = _sObjcArry[eObjc].Length;
                Crt(eObjc, _sObjcArry[eObjc].Length, () => {
                    _sObjcArry[eObjc][indx].Enbl();
                    _dActnQArry[eObjc][0]?.Invoke(_sObjcArry[eObjc][indx]);
                    _dActnQArry[eObjc] = Arry.Pp<DActn<SObjc>>(_dActnQArry[eObjc]);
                    if (_dActnQArry[eObjc].Length != 0) {
                        Rqst(eObjc, _dActnQArry[eObjc][0]);
                    }
                });
            }
        }

        private SObjc CrtSObjc(byte eObjc, GameObject gmObjc) { // create object
            return new SObjc(eObjc, NwInst(eObjc, gmObjc), gmObjc);
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
    }
}