using UnityEngine;

namespace T {

    public abstract class Scn { // scene

        public ScnMngr Mngr { set { _mngr = value; } } // set manager

        public bool IsEstb { // get is established or not
            get {
                if (_isEstbArry != null) {
                    for (byte i = 0; i < _isEstbArry.Length; i++) {
                        if (_isEstbArry[i]) {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        protected DActn[] _dAftrGnrtArry = null; // the array of after generating delegate
        protected ScnMngr _mngr = null; // registered scene manager
        protected Transform _rtTrnsfrm = null; // the root transform
        protected object[][][] _grpArry = null; // the array of object groups
        private GameObject[][] _addrblArry = null; // the array of instances
        private GameObject[][] _gmObjcArry = null; // the array of GameObjects
        private GameObject[] _tmpSbinstArry = null; // the temp array of sub GameObject
        private Transform[][] _tmpTrnsfrmArry = null; // the temp array of Transform
        private object[][] _qryArry = null; // the array of query
        private bool[] _isEstbArry = null; // is established or not

        public void Estb(Transform rtTrnsfrm, DActn dAftrEstb = null) { // establish scene by generating all objects group, dAftrEstb = after established
            if (_grpArry == null) {
                return;
            } else {
                for (byte g = 0; g < _grpArry.Length; g++) {
                    if (_grpArry[g] == null) {
                        return;
                    }
                }
            }
            if (_isEstbArry == null) {
                _isEstbArry = new bool[_grpArry.Length];
            }
            if (_addrblArry == null) {
                _addrblArry = new GameObject[_grpArry.Length][];
                _gmObjcArry = new GameObject[_grpArry.Length][];
            }
            _rtTrnsfrm = rtTrnsfrm;
            byte tg = 0;
            for (byte g = 0; g < _grpArry.Length; g++) {
                if (_addrblArry[g] == null) {
                    _addrblArry[g] = new GameObject[_grpArry[g].Length];
                    _gmObjcArry[g] = new GameObject[_grpArry[g].Length];
                }
                Gnrt(
                    g,
                    () => {
                        if (_dAftrGnrtArry != null) {
                            _dAftrGnrtArry[tg]?.Invoke();
                        }
                        _isEstbArry[tg] = true;
                        if (tg == _grpArry.Length - 1) {
                            dAftrEstb?.Invoke();
                        }
                        tg += 1;
                    }
                );
            }
        }

        public void Estb(Transform trnsfrm, byte eGrp, DActn dAftrEstb = null) { // establish scene by generating specific objects group by enum, dAftrEstb = after established
            if (_grpArry == null || _grpArry[eGrp] == null) {
                return;
            }
            if (_isEstbArry == null) {
                _isEstbArry = new bool[_grpArry.Length];
            } else if (_isEstbArry[eGrp]) {
                return;
            }
            if (_addrblArry == null) {
                _addrblArry = new GameObject[_grpArry.Length][];
                _gmObjcArry = new GameObject[_grpArry.Length][];
            }
            if (_addrblArry[eGrp] == null) {
                _addrblArry[eGrp] = new GameObject[_grpArry[eGrp].Length];
                _gmObjcArry[eGrp] = new GameObject[_grpArry[eGrp].Length];
            }
            _rtTrnsfrm = trnsfrm;
            Gnrt(
                eGrp,
                () => {
                    if (_dAftrGnrtArry != null) {
                        _dAftrGnrtArry[eGrp]?.Invoke();
                    }
                    _isEstbArry[eGrp] = true;
                    dAftrEstb?.Invoke();
                }
            );
        }

        public void Elmn() { // eliminate scene by release all object groups
            if (!IsEstb) {
                return;
            }
            for (byte g = 0; g < _addrblArry.Length; g++) {
                if (_addrblArry[g] != null) {
                    Rsrc.Rls(_addrblArry[g]);
                }
            }
            _dAftrGnrtArry = null;
            _mngr = null;
            _grpArry = null;
            _addrblArry = null;
            _gmObjcArry = null;
            _rtTrnsfrm = null;
            _isEstbArry = null;
        }

        public void Elmn(byte eGrp) { // eliminate scene by release specific object group by enum
            if (!IsEstb) {
                return;
            }
            if (!_isEstbArry[eGrp]) {
                return;
            }
            Rsrc.Rls(_addrblArry[eGrp]);
            _addrblArry[eGrp] = null;
            _gmObjcArry[eGrp] = null;
            _isEstbArry[eGrp] = false;
            if (!IsEstb) {
                _dAftrGnrtArry = null;
                _mngr = null;
                _grpArry = null;
                _addrblArry = null;
                
                _gmObjcArry = null;
                _rtTrnsfrm = null;
                _isEstbArry = null;
            }
        }

        public bool IsGrpEstb(byte eGrp) { // return is group established or not
            return _isEstbArry[eGrp];
        }

        public GameObject GtGmObjc(byte eGrp, byte eObjc) { // return specific gameObjcect in specific group by enum
            if (!_isEstbArry[eGrp]) {
                return null;
            }
            return _gmObjcArry[eGrp][eObjc];
        }

        public void Enbl(byte eGrp) { // enable specific object group by enum
            if (!_isEstbArry[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gmObjcArry[eGrp].Length; o++) {
                _gmObjcArry[eGrp][o].SetActive(true);
            }
        }

        public void Dsbl(byte eGrp) { // disable specific object group by enum
            if (!_isEstbArry[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gmObjcArry[eGrp].Length; o++) {
                _gmObjcArry[eGrp][o].SetActive(false);
            }
        }

        public void Enbl(byte eGrp, byte eObjc) { // enable specific object in specific group by enum
            if (!_isEstbArry[eGrp]) {
                return;
            }
            _gmObjcArry[eGrp][eObjc].SetActive(true);
        }

        public void Dsbl(byte eGrp, byte eObjc) { // disable specific object in specific group by enum
            if (!_isEstbArry[eGrp]) {
                return;
            }
            _gmObjcArry[eGrp][eObjc].SetActive(false);
        }

        private void Gnrt(byte eGrp, DActn dAftrGnrt) { // generate scene by instantiate objects from addressable asset
            _qryArry = new object[_grpArry[eGrp].Length][];
            for (byte o = 0; o < _grpArry[eGrp].Length; o++) {
                _qryArry[o] = new object[3] {
                    _grpArry[eGrp][o][0],
                    new Vector3(((float[])_grpArry[eGrp][o][1])[0], ((float[])_grpArry[eGrp][o][1])[1], ((float[])_grpArry[eGrp][o][1])[2]),
                    new Quaternion(((float[])_grpArry[eGrp][o][2])[0], ((float[])_grpArry[eGrp][o][2])[1], ((float[])_grpArry[eGrp][o][2])[2], ((float[])_grpArry[eGrp][o][2])[3]),
                };
            }
            Rsrc.Inst(_qryArry, _rtTrnsfrm, (rsltArry) => {
                for (byte r = 0; r < _grpArry[eGrp].Length; r++) {
                    rsltArry[r].name = _grpArry[eGrp][r][3].ToString();
                    _addrblArry[eGrp][r] = rsltArry[r];
                }
                _tmpTrnsfrmArry = new Transform[_addrblArry[eGrp].Length][];
                _tmpSbinstArry = new GameObject[_addrblArry[eGrp].Length * 32]; // array of subinstances
                int indx = 0;
                for (byte t1 = 0; t1 < _tmpTrnsfrmArry.Length; t1++) {
                    _tmpTrnsfrmArry[t1] = _addrblArry[eGrp][t1].GetComponentsInChildren<Transform>();
                    for (byte t2 = 1; t2 < _tmpTrnsfrmArry[t1].Length; t2++) {
                        _tmpSbinstArry[indx] = _tmpTrnsfrmArry[t1][t2].gameObject;
                        indx += 1;
                    }
                }
                _gmObjcArry[eGrp] = Arry.Apnd<GameObject>(_addrblArry[eGrp], Arry.Ct<GameObject>(_tmpSbinstArry, indx));
                _qryArry = null;
                _tmpTrnsfrmArry = null;
                _tmpSbinstArry = null;
                indx = 0;
                rsltArry = null;
                dAftrGnrt(); // after generate callback
            });
        }
    }
}