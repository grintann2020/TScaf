using UnityEngine;

namespace T {

    public abstract class Scn { // scene

        public ScnMng Mng { set { _mng = value; } } // set manager

        public bool IsEst { // get is established or not
            get {
                if (_isEstArr != null) {
                    for (byte i = 0; i < _isEstArr.Length; i++) {
                        if (_isEstArr[i]) {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        protected DAct[] _dGnrArr = null; // the array of after generating delegate
        protected ScnMng _mng = null; // registered scene manager
        protected Transform _rT = null; // the root transform
        protected object[][][] _grpArr3 = null; // the array of object groups
        private GameObject[][] _aGOArr2 = null; // the array of addressable GameObjects
        private GameObject[][] _gOArr2 = null; // the array of GameObjects
        private GameObject[] _tmpSbGOArr = null; // the temp array of sub GameObject
        private Transform[][] _tmpTfArr2 = null; // the temp array of Transform
        private bool[] _isEstArr = null; // is established or not

        public void Est(Transform rT, DAct dEst = null) { // establish scene by generating all objects group, dEst = after established
            if (_grpArr3 == null) {
                return;
            } else {
                for (byte g = 0; g < _grpArr3.Length; g++) {
                    if (_grpArr3[g] == null) {
                        return;
                    }
                }
            }
            if (_isEstArr == null) {
                _isEstArr = new bool[_grpArr3.Length];
            }
            if (_aGOArr2 == null) {
                _aGOArr2 = new GameObject[_grpArr3.Length][];
                _gOArr2 = new GameObject[_grpArr3.Length][];
            }
            _rT = rT;
            byte tg = 0;
            for (byte g = 0; g < _grpArr3.Length; g++) {
                if (_aGOArr2[g] == null) {
                    _aGOArr2[g] = new GameObject[_grpArr3[g].Length];
                    _gOArr2[g] = new GameObject[_grpArr3[g].Length];
                }
                Gnr(
                    g,
                    () => {
                        if (_dGnrArr != null) {
                            _dGnrArr[tg]?.Invoke();
                        }
                        _isEstArr[tg] = true;
                        if (tg == _grpArr3.Length - 1) {
                            dEst?.Invoke();
                        }
                        tg += 1;
                    }
                );
            }
        }

        public void Est(Transform tf, byte eGrp, DAct dEst = null) { // establish scene by generating specific objects group by enum, dEst = after established
            if (_grpArr3 == null || _grpArr3[eGrp] == null) {
                return;
            }
            if (_isEstArr == null) {
                _isEstArr = new bool[_grpArr3.Length];
            } else if (_isEstArr[eGrp]) {
                return;
            }
            if (_aGOArr2 == null) {
                _aGOArr2 = new GameObject[_grpArr3.Length][];
                _gOArr2 = new GameObject[_grpArr3.Length][];
            }
            if (_aGOArr2[eGrp] == null) {
                _aGOArr2[eGrp] = new GameObject[_grpArr3[eGrp].Length];
                _gOArr2[eGrp] = new GameObject[_grpArr3[eGrp].Length];
            }
            _rT = tf;
            Gnr(
                eGrp,
                () => {
                    if (_dGnrArr != null) {
                        _dGnrArr[eGrp]?.Invoke();
                    }
                    _isEstArr[eGrp] = true;
                    dEst?.Invoke();
                }
            );
        }

        public void Elm() { // eliminate scene by release all object groups
            if (!IsEst) {
                return;
            }
            for (byte g = 0; g < _aGOArr2.Length; g++) {
                if (_aGOArr2[g] != null) {
                    Rs.Rls(_aGOArr2[g]);
                }
            }
            _dGnrArr = null;
            _mng = null;
            _grpArr3 = null;
            _aGOArr2 = null;
            _gOArr2 = null;
            _rT = null;
            _isEstArr = null;
        }

        public void Elm(byte eGrp) { // eliminate scene by release specific object group by enum
            if (!IsEst) {
                return;
            }
            if (!_isEstArr[eGrp]) {
                return;
            }
            Rs.Rls(_aGOArr2[eGrp]);
            _aGOArr2[eGrp] = null;
            _gOArr2[eGrp] = null;
            _isEstArr[eGrp] = false;
            if (!IsEst) {
                _dGnrArr = null;
                _mng = null;
                _grpArr3 = null;
                _aGOArr2 = null;
                
                _gOArr2 = null;
                _rT = null;
                _isEstArr = null;
            }
        }

        public bool IsGrpEst(byte eGrp) { // return is group established or not
            return _isEstArr[eGrp];
        }

        public GameObject GtGO(byte eGrp, byte eObj) { // return specific gameObject in specific group by enum
            if (!_isEstArr[eGrp]) {
                return null;
            }
            return _gOArr2[eGrp][eObj];
        }

        public void Enb(byte eGrp) { // enable specific object group by enum
            if (!_isEstArr[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gOArr2[eGrp].Length; o++) {
                _gOArr2[eGrp][o].SetActive(true);
            }
        }

        public void Dsb(byte eGrp) { // disable specific object group by enum
            if (!_isEstArr[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gOArr2[eGrp].Length; o++) {
                _gOArr2[eGrp][o].SetActive(false);
            }
        }

        public void Enb(byte eGrp, byte eObj) { // enable specific object in specific group by enum
            if (!_isEstArr[eGrp]) {
                return;
            }
            _gOArr2[eGrp][eObj].SetActive(true);
        }

        public void Dsb(byte eGrp, byte eObj) { // disable specific object in specific group by enum
            if (!_isEstArr[eGrp]) {
                return;
            }
            _gOArr2[eGrp][eObj].SetActive(false);
        }

        private void Gnr(byte eGrp, DAct dGnr) { // generate scene by instantiate objects from addressable asset
            SIns[] sInsArr = new SIns[_grpArr3[eGrp].Length];
            for (byte o = 0; o < sInsArr.Length; o++) {
                sInsArr[o] = new SIns (
                    (string)_grpArr3[eGrp][o][0],
                    new Vector3(((float[])_grpArr3[eGrp][o][1])[0], ((float[])_grpArr3[eGrp][o][1])[1], ((float[])_grpArr3[eGrp][o][1])[2]),
                    new Quaternion(((float[])_grpArr3[eGrp][o][2])[0], ((float[])_grpArr3[eGrp][o][2])[1], ((float[])_grpArr3[eGrp][o][2])[2], ((float[])_grpArr3[eGrp][o][2])[3])
                );
            }
            Rs.Ins(sInsArr, _rT, (rsltArr) => {
                for (byte r = 0; r < _grpArr3[eGrp].Length; r++) {
                    rsltArr[r].name = _grpArr3[eGrp][r][3].ToString();
                    _aGOArr2[eGrp][r] = rsltArr[r];
                }
                _tmpTfArr2 = new Transform[_aGOArr2[eGrp].Length][];
                _tmpSbGOArr = new GameObject[_aGOArr2[eGrp].Length * 32]; // the array of subinstances
                int indx = 0;
                for (byte t1 = 0; t1 < _tmpTfArr2.Length; t1++) {
                    _tmpTfArr2[t1] = _aGOArr2[eGrp][t1].GetComponentsInChildren<Transform>();
                    for (byte t2 = 1; t2 < _tmpTfArr2[t1].Length; t2++) {
                        _tmpSbGOArr[indx] = _tmpTfArr2[t1][t2].gameObject;
                        indx += 1;
                    }
                }
                _gOArr2[eGrp] = Arr.Apn<GameObject>(_aGOArr2[eGrp], Arr.Ct<GameObject>(_tmpSbGOArr, indx));
                _tmpTfArr2 = null;
                _tmpSbGOArr = null;
                indx = 0;
                rsltArr = null;
                dGnr(); // after generate callback
            });
        }
    }
}