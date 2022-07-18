using System;
using UnityEngine;

namespace T {

    public abstract class Objs { // objects

        public ObjsMng Mng { set { _mng = value; } } // set manager
        public bool IsFnd { get { return _isFnd; } } // get is founded or not
        protected Transform _rT = null;
        protected ObjsMng _mng = null;
        protected SObj[][] _sObjArr2 = null;
        protected string[] _kyArr = null;
        private DRct<SObj>[][] _dQArr2 = null; // queue
        private bool _isFnd = false;

        public void Fnd(Transform rT) { // found
            if (_isFnd || rT == null || _kyArr == null) {
                return;
            }
            _isFnd = true;
            _rT = rT;
            _sObjArr2 = new SObj[_kyArr.Length][];
            _dQArr2 = new DRct<SObj>[_kyArr.Length][];
            for (byte q = 0; q < _dQArr2.Length; q++) {
                _dQArr2[q] = new DRct<SObj>[0];
            }
        }

        public void Rn() { // ruin
            if (!_isFnd) {
                return;
            }
            _isFnd = false;
            _rT = null;
            _mng = null;
            _sObjArr2 = null;
            _kyArr = null;
            _dQArr2 = null;
        }

        public GameObject[] GtGOArr(byte eObj) { // get the array of GameObjects
            GameObject[] gOs = new GameObject[_sObjArr2[eObj].Length];
            for (byte o = 0; o < _sObjArr2[eObj].Length; o++) {
                gOs[o] = _sObjArr2[eObj][o].GO;
            }
            return gOs;
        }

        public GameObject GtGO(byte eObj, int id) { // get GameObject
            return _sObjArr2[eObj][Idx(eObj, id)].GO;
        }

        public SObj[] GtSObjArr(byte eObj) { // get the array of SObjArr
            SObj[] objArr = new SObj[_sObjArr2[eObj].Length];
            for (byte o = 0; o < _sObjArr2[eObj].Length; o++) {
                objArr[o] = _sObjArr2[eObj][o];
            }
            return objArr;
        }

        public SObj GtSObj(byte eObj, int id) { // get SObj
            return _sObjArr2[eObj][Idx(eObj, id)];
        }

        public T[] GtInsArr<T>(byte eObj) { // get the array of instances
            T[] insArr = new T[_sObjArr2[eObj].Length];
            for (byte o = 0; o < _sObjArr2[eObj].Length; o++) {
                insArr[o] = (T)_sObjArr2[eObj][o].Ins;
            }
            return insArr;
        }

        public T GtIns<T>(byte eObj, int id) { // get instance
            return (T)_sObjArr2[eObj][Idx(eObj, id)].Ins;
        }

        public void MltCrt(byte[][] eObjArr, DAct dCrt = null) { // multiple create
            byte cnt = 0;
            for (byte e = 0; e < eObjArr.Length; e++) {
                Crt(eObjArr[e][0], eObjArr[e][1], () => {
                    cnt += 1;
                    if (cnt == eObjArr.Length) {
                        dCrt?.Invoke();
                    }
                });
            }
        }

        public void Crt(byte eObj, int amn, DAct dInst = null) { // create
            SObj[] sObjArr = new SObj[amn];
            string[] kyArr = new string[amn];
            for (int e = 0; e < amn; e++) {
                kyArr[e] = _kyArr[eObj];
            }
            Rs.Ins(
                kyArr,
                _rT,
                (gOs) => {
                    string nm = gOs[0].name.Split("(")[0] + "_e" + eObj;
                    for (int g = 0; g < gOs.Length; g++) {
                        gOs[g].name = nm;
                        sObjArr[g] = CrtSObj(eObj, gOs[g]);
                    }
                    _sObjArr2[eObj] = Arr.Apn<SObj>(_sObjArr2[eObj], sObjArr);
                    sObjArr = null;
                    dInst?.Invoke();
                }
            );
        }

        public void Dlt(byte eObj, int id) { // delete 
            int idx = Idx(eObj, id);
            if (idx < 0) {
                return;
            }
            UnityEngine.Object.Destroy(_sObjArr2[eObj][idx].GO);
            _sObjArr2[eObj] = Arr.Rmv<SObj>(_sObjArr2[eObj], idx);
        }

        public void Enb(byte eObj, DRct<SObj> dRct = null) { // request
            // Debug.Log("eObj = " + eObj + ", _dQArr2[eObj].Length =" + _dQArr2[eObj].Length);
            if (_dQArr2[eObj].Length == 0) {
                int idx = SwtNxt(eObj, false);
                if (idx >= 0) {
                    _sObjArr2[eObj][idx].Enb();
                    dRct?.Invoke(_sObjArr2[eObj][idx]);
                } else {
                    _dQArr2[eObj] = Arr.Psh<DRct<SObj>>(_dQArr2[eObj], dRct);
                    Rqs(eObj, dRct);
                }
            } else {
                _dQArr2[eObj] = Arr.Psh<DRct<SObj>>(_dQArr2[eObj], dRct);
            }
        }

        public void Dsb(byte eObj, int id) {
            _sObjArr2[eObj][Idx(eObj, id)].Dsb();
        }

        public void Dsb(byte eObj) {
            _sObjArr2[eObj][SwtNxt(eObj, true)].Dsb();
        }

        protected abstract object NwIns(byte eObj, GameObject gO);

        private void Rqs(byte eObj, DRct<SObj> dRct = null) { // requisition
            int idx = SwtNxt(eObj, false);
            if (idx > 0) {
                _sObjArr2[eObj][idx].Enb();
                dRct?.Invoke(_sObjArr2[eObj][idx]);
                _dQArr2[eObj] = Arr.Pp<DRct<SObj>>(_dQArr2[eObj]);
                if (_dQArr2[eObj].Length != 0) {
                    Rqs(eObj, _dQArr2[eObj][0]);
                }
            } else {
                idx = _sObjArr2[eObj].Length;
                Crt(eObj, _sObjArr2[eObj].Length, () => {
                    _sObjArr2[eObj][idx].Enb();
                    _dQArr2[eObj][0]?.Invoke(_sObjArr2[eObj][idx]);
                    _dQArr2[eObj] = Arr.Pp<DRct<SObj>>(_dQArr2[eObj]);
                    if (_dQArr2[eObj].Length != 0) {
                        Rqs(eObj, _dQArr2[eObj][0]);
                    }
                });
            }
        }

        private SObj CrtSObj(byte eObj, GameObject gO) { // create object
            return new SObj(eObj, NwIns(eObj, gO), gO);
        }

        private int Idx(byte eObj, int id) {
            int str = 0;
            int end = _sObjArr2[eObj].Length - 1;
            int mdd;
            while (end >= str) {
                mdd = str + ((end - str) >> 1);
                if (id == _sObjArr2[eObj][mdd].Id) {
                    return mdd;
                } else if (id < _sObjArr2[eObj][mdd].Id) {
                    str = mdd + 1;
                } else {
                    end = mdd - 1;
                }
            }
            return -1;
        }

        private int SwtNxt(byte eObj, bool bln) {
            for (int s = 0; s < _sObjArr2[eObj].Length; s++) {
                if (_sObjArr2[eObj][s].IsEnb == bln) {
                    return s;
                }
            }
            return -1;
        }
    }
}