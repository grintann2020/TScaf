using System;
using UnityEngine;

namespace T {

    public abstract class Objcs { // objects

        public ObjcsMngr Mngr { set { _mngr = value; } } // set manager
        public bool IsFound { get { return _isFound; } } // get is founded or not
        protected Transform _rtTrnsfrm = null;
        protected ObjcsMngr _mngr = null;
        protected SObjc[][] _sObjcs = null;
        protected string[] _kys = null;
        private DActn<SObjc>[][] _dActnQs = null;
        private bool _isFound = false;

        public void Found(Transform rtTrnsfrm) { // found
            if (_isFound || rtTrnsfrm == null || _kys == null) {
                return;
            }
            _isFound = true;
            _rtTrnsfrm = rtTrnsfrm;
            _sObjcs = new SObjc[_kys.Length][];
            _dActnQs = new DActn<SObjc>[_kys.Length][];
            for (byte q = 0; q < _dActnQs.Length; q++) {
                _dActnQs[q] = new DActn<SObjc>[0];
            }
        }

        public void Ruin() { // cease
            if (!_isFound) {
                return;
            }
            _isFound = false;
            _rtTrnsfrm = null;
            _mngr = null;
            _sObjcs = null;
            _kys = null;
            _dActnQs = null;
        }

        public GameObject[] GtGmObjcs(byte eObjc) { // get the array of GameObjects
            GameObject[] gmObjcs = new GameObject[_sObjcs[eObjc].Length];
            for (byte o = 0; o < _sObjcs[eObjc].Length; o++) {
                gmObjcs[o] = _sObjcs[eObjc][o].GmObjc;
            }
            return gmObjcs;
        }

        public GameObject GtGmObjc(byte eObjc, int id) { // get GameObject
            return _sObjcs[eObjc][Indx(eObjc, id)].GmObjc;
        }

        public SObjc[] GtSObjcs(byte eObjc) { // get the array of SObjcs
            SObjc[] objcs = new SObjc[_sObjcs[eObjc].Length];
            for (byte o = 0; o < _sObjcs[eObjc].Length; o++) {
                objcs[o] = _sObjcs[eObjc][o];
            }
            return objcs;
        }

        public SObjc GtSObjc(byte eObjc, int id) { // get SObjc
            return _sObjcs[eObjc][Indx(eObjc, id)];
        }

        public T[] GtInsts<T>(byte eObjc) { // get the array of instances
            T[] insts = new T[_sObjcs[eObjc].Length];
            for (byte o = 0; o < _sObjcs[eObjc].Length; o++) {
                insts[o] = (T)_sObjcs[eObjc][o].Inst;
            }
            return insts;
        }

        public T GtInst<T>(byte eObjc, int id) { // get instance
            return (T)_sObjcs[eObjc][Indx(eObjc, id)].Inst;
        }

        public void MltpCrt(byte[][] eObjcs, DActn dCrt = null) { // multiple create
            byte cnt = 0;
            for (byte e = 0; e < eObjcs.Length; e++) {
                Crt(eObjcs[e][0], eObjcs[e][1], () => {
                    cnt += 1;
                    if (cnt == eObjcs.Length) {
                        dCrt?.Invoke();
                    }
                });
            }
        }

        public void Crt(byte eObjc, int amnt, DActn dInst = null) { // create
            SObjc[] sObjcs = new SObjc[amnt];
            string[] kys = new string[amnt];
            for (int e = 0; e < amnt; e++) {
                kys[e] = _kys[eObjc];
            }
            Rsrc.Inst(
                kys,
                _rtTrnsfrm,
                (gmObjcs) => {
                    string nm = gmObjcs[0].name.Split("(")[0] + "_e" + eObjc;
                    for (int g = 0; g < gmObjcs.Length; g++) {
                        gmObjcs[g].name = nm;
                        sObjcs[g] = CrtSObjc(eObjc, gmObjcs[g]);
                    }
                    _sObjcs[eObjc] = Arry.Apnd<SObjc>(_sObjcs[eObjc], sObjcs);
                    sObjcs = null;
                    dInst?.Invoke();
                }
            );
        }

        public void Dlt(byte eObjc, int id) { // delete 
            int indx = Indx(eObjc, id);
            if (indx < 0) {
                return;
            }
            UnityEngine.Object.Destroy(_sObjcs[eObjc][indx].GmObjc);
            _sObjcs[eObjc] = Arry.Rmv<SObjc>(_sObjcs[eObjc], indx);
        }

        public void Enbl(byte eObjc, DActn<SObjc> dActn = null) { // request
            // Debug.Log("eObjc = " + eObjc + ", _dActnQs[eObjc].Length =" + _dActnQs[eObjc].Length);
            if (_dActnQs[eObjc].Length == 0) {
                int indx = SwtcNxt(eObjc, false);
                if (indx >= 0) {
                    _sObjcs[eObjc][indx].Enbl();
                    dActn?.Invoke(_sObjcs[eObjc][indx]);
                } else {
                    _dActnQs[eObjc] = Arry.Psh<DActn<SObjc>>(_dActnQs[eObjc], dActn);
                    Rqst(eObjc, dActn);
                }
            } else {
                _dActnQs[eObjc] = Arry.Psh<DActn<SObjc>>(_dActnQs[eObjc], dActn);
            }
        }

        public void Dsbl(byte eObjc, int id) {
            _sObjcs[eObjc][Indx(eObjc, id)].Dsbl();
        }

        public void Dsbl(byte eObjc) {
            _sObjcs[eObjc][SwtcNxt(eObjc, true)].Dsbl();
        }

        protected abstract object NwInst(byte eObjc, GameObject gmObjc);

        private void Rqst(byte eObjc, DActn<SObjc> dActn = null) { // requisition
            int indx = SwtcNxt(eObjc, false);
            if (indx > 0) {
                _sObjcs[eObjc][indx].Enbl();
                dActn?.Invoke(_sObjcs[eObjc][indx]);
                _dActnQs[eObjc] = Arry.Pop<DActn<SObjc>>(_dActnQs[eObjc]);
                if (_dActnQs[eObjc].Length != 0) {
                    Rqst(eObjc, _dActnQs[eObjc][0]);
                }
            } else {
                indx = _sObjcs[eObjc].Length;
                Crt(eObjc, _sObjcs[eObjc].Length, () => {
                    _sObjcs[eObjc][indx].Enbl();
                    _dActnQs[eObjc][0]?.Invoke(_sObjcs[eObjc][indx]);
                    _dActnQs[eObjc] = Arry.Pop<DActn<SObjc>>(_dActnQs[eObjc]);
                    if (_dActnQs[eObjc].Length != 0) {
                        Rqst(eObjc, _dActnQs[eObjc][0]);
                    }
                });
            }
        }

        private SObjc CrtSObjc(byte eObjc, GameObject gmObjc) { // create object
            return new SObjc(eObjc, NwInst(eObjc, gmObjc), gmObjc);
        }

        private int Indx(byte eObjc, int id) {
            int strt = 0;
            int end = _sObjcs[eObjc].Length - 1;
            int mddl;
            while (end >= strt) {
                mddl = strt + ((end - strt) >> 1);
                if (id == _sObjcs[eObjc][mddl].Id) {
                    return mddl;
                } else if (id < _sObjcs[eObjc][mddl].Id) {
                    strt = mddl + 1;
                } else {
                    end = mddl - 1;
                }
            }
            return -1;
        }

        private int SwtcNxt(byte eObjc, bool bln) {
            for (int s = 0; s < _sObjcs[eObjc].Length; s++) {
                if (_sObjcs[eObjc][s].IsEnbl == bln) {
                    return s;
                }
            }
            return -1;
        }
    }
}