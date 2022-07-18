using UnityEngine;

namespace T {

    public class UI {

        public UIMng Mng { set { _mng = value; } }
        public bool IsAtt {
            get {
                if (_isAttArr != null) {
                    for (byte i = 0; i < _isAttArr.Length; i++) {
                        if (_isAttArr[i]) {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        protected DRct<byte>[][][] _dBhvArr3 = null; //delegate of behavior method
        protected DAct[] _dGnrArr = null; // array of after generating delegate
        protected UIMng _mng = null; // registered UI manager
        protected Canvas _mnCnv = null; // the main canvas
        protected object[][][] _grpArr3 = null; // the array of groups
        protected object[][] _cmpArr2 = null; // the array of components
        private GameObject[][] _aGOArr2 = null; // the array of instances
        private GameObject[][] _gOArr2 = null; // the array of GameObjects
        private GameObject[] _tmpSbGOArr = null; // the array for temp storage of sub GameObject
        private Transform[][] _tmpTfArr2 = null; // the array for temp storage of Transform
        private bool[] _isAttArr = null; // the array of bool as is atached or not

        public void Att(Canvas cnv, DAct dAtt = null) { // attach UI by generating all objects group, dAtt = after attached
            if (_grpArr3 == null) {
                return;
            } else {
                for (byte g = 0; g < _grpArr3.Length; g++) {
                    if (_grpArr3[g] == null) {
                        return;
                    }
                }
            }
            if (_isAttArr == null) {
                _isAttArr = new bool[_grpArr3.Length];
            }
            if (_aGOArr2 == null) {
                _aGOArr2 = new GameObject[_grpArr3.Length][];
                _gOArr2 = new GameObject[_grpArr3.Length][];
                _cmpArr2 = new object[_grpArr3.Length][];
            }
            _mnCnv = cnv;
            byte tg = 0;
            for (byte g = 0; g < _grpArr3.Length; g++) {
                if (_grpArr3[g] == null) {
                    continue;
                }
                if (_aGOArr2[g] == null) {
                    _aGOArr2[g] = new GameObject[_grpArr3[g].Length];
                    _gOArr2[g] = new GameObject[_grpArr3[g].Length];
                    _cmpArr2[g] = new object[_grpArr3[g].Length];
                }
                Gnr(
                    g,
                    () => {
                        if (_dGnrArr != null) {
                            _dGnrArr[tg]?.Invoke();
                        }
                        _isAttArr[tg] = true;
                        if (tg == _grpArr3.Length - 1) {
                            dAtt?.Invoke();
                        }
                        tg += 1;
                    }
                );
            }
        }

        public void Att(Canvas cnv, byte eGrp, DAct dAtt = null) { // attach UI by generating specific objects group by enum, dAtt = after attached
            if (_grpArr3 == null || _grpArr3[eGrp] == null) {
                return;
            }
            if (_isAttArr == null) {
                _isAttArr = new bool[_grpArr3.Length];
            } else if (_isAttArr[eGrp]) {
                return;
            }
            if (_aGOArr2 == null) {
                _aGOArr2 = new GameObject[_grpArr3.Length][];
                _gOArr2 = new GameObject[_grpArr3.Length][];
                _cmpArr2 = new object[_grpArr3.Length][];
            }
            if (_aGOArr2[eGrp] == null) {
                _aGOArr2[eGrp] = new GameObject[_grpArr3[eGrp].Length];
                _gOArr2[eGrp] = new GameObject[_grpArr3[eGrp].Length];
                _cmpArr2[eGrp] = new object[_grpArr3[eGrp].Length];
            }
            _mnCnv = cnv;
            Gnr(
                eGrp,
                () => {
                    _dGnrArr[eGrp]?.Invoke();
                    _isAttArr[eGrp] = true;
                    dAtt?.Invoke();
                }
            );
        }

        public void Dtc() { // detach UI by release all object groups, dBD = before detached, dAD = after detached
            if (!IsAtt) {
                return;
            }
            for (byte g = 0; g < _aGOArr2.Length; g++) {
                if (_aGOArr2[g] != null) {
                    Rs.Rls(_aGOArr2[g]);
                }
            }
            _dBhvArr3 = null;
            _dGnrArr = null;
            _mng = null;
            _mnCnv = null;
            _grpArr3 = null;
            _cmpArr2 = null;
            _aGOArr2 = null;
            _gOArr2 = null;
            _isAttArr = null;
        }

        public void Dtc(byte eGrp) { // detach UI by release specific object group by enum, dBD = before detached, dAD = after detached
            if (!IsAtt) {
                return;
            }
            if (!_isAttArr[eGrp]) {
                return;
            }
            Rs.Rls(_aGOArr2[eGrp]);
            _aGOArr2[eGrp] = null;
            _gOArr2[eGrp] = null;
            _isAttArr[eGrp] = false;
            if (!IsAtt) { // if any group is not attached
                _dBhvArr3 = null;
                _dGnrArr = null;
                _mng = null;
                _mnCnv = null;
                _grpArr3 = null;
                _cmpArr2 = null;
                _aGOArr2 = null;
                _gOArr2 = null;
                _isAttArr = null;
            }
        }

        public void Act(byte eGrp) { // activate specific behavior group by enum
            if (_dBhvArr3[eGrp] == null) {
                return;
            }
            for (byte b = 0; b < _dBhvArr3[eGrp].Length; b++) {
                if (_dBhvArr3[eGrp][b] != null) {
                    _dBhvArr3[eGrp][b][0].Invoke(eGrp);
                }
            }
        }

        public void Hlt(byte eGrp) { // halt specific behavior group by enum
            if (_dBhvArr3[eGrp] == null) {
                return;
            }
            for (byte b = 0; b < _dBhvArr3[eGrp].Length; b++) {
                if (_dBhvArr3[eGrp][b] != null) {
                    _dBhvArr3[eGrp][b][1].Invoke(eGrp);
                }
            }
        }

        public void Act(byte eGrp, byte eBhvr) { // activate specific behavior in specific group by enum
            if (_dBhvArr3[eGrp] == null) {
                return;
            }
            if (_dBhvArr3[eGrp][eBhvr] != null) {
                _dBhvArr3[eGrp][eBhvr][0].Invoke(eGrp);
            }
        }

        public void Hlt(byte eGrp, byte eBhvr) { // halt specific behavior in specific group by enum
            if (_dBhvArr3[eGrp] == null) {
                return;
            }
            if (_dBhvArr3[eGrp][eBhvr] != null) {
                _dBhvArr3[eGrp][eBhvr][1].Invoke(eGrp);
            }
        }

        public bool IsGrpAtt(byte eGrp) { // return specific group by enum was attached or not 
            return _isAttArr[eGrp];
        }

        public GameObject GtGO(byte eGrp, byte eObj) { // return specific gameObject in specific group by enum
            if (!_isAttArr[eGrp]) {
                return null;
            }
            return _gOArr2[eGrp][eObj];
        }

        public T GtCmp<T>(byte eGrp, byte eCmpn) { // return specific component by enum
            if (!_isAttArr[eGrp]) {
                return default(T);
            }
            return (T)_cmpArr2[eGrp][eCmpn];
        }

        public void Enb(byte eGrp) { // enable specific object group by enum
            if (!_isAttArr[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gOArr2[eGrp].Length; o++) {
                _gOArr2[eGrp][o].SetActive(true);
            }
        }

        public void Dsb(byte eGrp) { // disable specific object group by enum
            if (!_isAttArr[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gOArr2[eGrp].Length; o++) {
                _gOArr2[eGrp][o].SetActive(false);
            }
        }

        public void Enb(byte eGrp, byte eObj) { // enable specific object in specific group by enum
            if (!_isAttArr[eGrp]) {
                return;
            }
            _gOArr2[eGrp][eObj].SetActive(true);
        }

        public void Dsb(byte eGrp, byte eObj) { // disable specific object in specific group by enum
            if (!_isAttArr[eGrp]) {
                return;
            }
            _gOArr2[eGrp][eObj].SetActive(false);
        }

        public void Frn(byte eGrp) {
            if (!_isAttArr[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gOArr2[(byte)eGrp].Length; o++) {
                _gOArr2[(byte)eGrp][o].transform.SetAsLastSibling();
            }
        }

        public void Bck(byte eGrp) {
            if (!_isAttArr[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gOArr2[(byte)eGrp].Length; o++) {
                _gOArr2[(byte)eGrp][o].transform.SetAsFirstSibling();
            }
        }

        public void Frn(byte eGrp, byte eObj) {
            if (!_isAttArr[eGrp]) {
                return;
            }
            _gOArr2[(byte)eGrp][(byte)eObj].transform.SetAsLastSibling();
        }

        public void Bck(byte eGrp, byte eObj) {
            if (!_isAttArr[eGrp]) {
                return;
            }
            _gOArr2[(byte)eGrp][(byte)eObj].transform.SetAsFirstSibling();
        }

        private void Gnr(byte eGrp, DAct dGnr) { // generate scene
            SIns[] sInsArr = new SIns[_grpArr3[eGrp].Length];
            for (byte o = 0; o < _grpArr3[eGrp].Length; o++) {
                sInsArr[o] = new SIns (
                    (string)_grpArr3[eGrp][o][0],
                    new Vector3(((short[])_grpArr3[eGrp][o][1])[0], ((short[])_grpArr3[eGrp][o][1])[1], 0),
                    Quaternion.identity
                );
            }
            Rs.Ins(sInsArr, _mnCnv.transform, (rslts) => {
                for (byte r = 0; r < _grpArr3[eGrp].Length; r++) {
                    rslts[r].name = _grpArr3[eGrp][r][2].ToString();
                    _aGOArr2[eGrp][r] = rslts[r];
                }
                _tmpTfArr2 = new Transform[_aGOArr2[eGrp].Length][];
                _tmpSbGOArr = new GameObject[_aGOArr2[eGrp].Length * 32]; // array of subinstances
                int indx = 0;
                for (byte t1 = 0; t1 < _tmpTfArr2.Length; t1++) {
                    _tmpTfArr2[t1] = _aGOArr2[eGrp][t1].GetComponentsInChildren<Transform>();
                    for (byte t2 = 1; t2 < _tmpTfArr2[t1].Length; t2++) {
                        _tmpSbGOArr[indx] = _tmpTfArr2[t1][t2].gameObject;
                        indx += 1;
                    }
                }
                _gOArr2[eGrp] = Arr.Apn<GameObject>(_aGOArr2[eGrp], Arr.Ct<GameObject>(_tmpSbGOArr, indx));
                _cmpArr2[eGrp] = Ftc(_gOArr2[eGrp]);
                _tmpTfArr2 = null;
                _tmpSbGOArr = null;
                rslts = null;
                Act(eGrp);
                dGnr(); // after generate callback
            });
        }

        private object[] Ftc(GameObject[] gOs) { // fetch UI component from array of sub GameObjects
            object[] cmp = new object[0];
            for (byte o = 0; o < gOs.Length; o++) {
                for (byte t = 0; t < _mng.Typs.Length; t++) {
                    if (gOs[o].GetComponent(_mng.Typs[t])) {
                        cmp = Arr.Add<object>(cmp, gOs[o].GetComponent(_mng.Typs[t]));
                    }
                }
            }
            return cmp;
        }
    }
}