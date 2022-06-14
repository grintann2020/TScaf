using UnityEngine;

namespace T {

    public class UI {

        public UIMngr Mngr { set { _mngr = value; } }
        public bool IsAttc {
            get {
                if (_isAttcArry != null) {
                    for (byte i = 0; i < _isAttcArry.Length; i++) {
                        if (_isAttcArry[i]) {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        protected DActn<byte>[][][] _dBhvrArry = null; //delegate of behavior method
        protected DActn[] _dAftrGnrtArry = null; // array of after generating delegate
        protected UIMngr _mngr = null; // registered UI manager
        protected Canvas _mnCnvs = null; // the main canvas
        protected object[][][] _grpArry = null; // the array of groups
        protected object[][] _cmpnArry = null; // the array of components
        private GameObject[][] _addrblArry = null; // the array of instances
        private GameObject[][] _gmObjcArry = null; // the array of GameObjects
        private GameObject[] _tmpSbinstArry = null; // the array for temp storage of sub GameObject
        private Transform[][] _tmpTrnsfrmArry = null; // the array for temp storage of Transform
        private object[][] _tmpQryArry = null;
        private bool[] _isAttcArry = null; // the array of bool as is atached or not
        private ushort _tmpIndx = 0; // temp index;

        public void Attc(Canvas cnvs, DActn dAftrAttc = null) { // attach UI by generating all objects group, dAftrAttc = after attached
            if (_grpArry == null) {
                return;
            } else {
                for (byte g = 0; g < _grpArry.Length; g++) {
                    if (_grpArry[g] == null) {
                        return;
                    }
                }
            }
            if (_isAttcArry == null) {
                _isAttcArry = new bool[_grpArry.Length];
            }
            if (_addrblArry == null) {
                _addrblArry = new GameObject[_grpArry.Length][];
                _gmObjcArry = new GameObject[_grpArry.Length][];
                _cmpnArry = new object[_grpArry.Length][];
            }
            _mnCnvs = cnvs;
            byte tg = 0;
            for (byte g = 0; g < _grpArry.Length; g++) {
                if (_grpArry[g] == null) {
                    continue;
                }
                if (_addrblArry[g] == null) {
                    _addrblArry[g] = new GameObject[_grpArry[g].Length];
                    _gmObjcArry[g] = new GameObject[_grpArry[g].Length];
                    _cmpnArry[g] = new object[_grpArry[g].Length];
                }
                Gnr(
                    g,
                    () => {
                        if (_dAftrGnrtArry != null) {
                            _dAftrGnrtArry[tg]?.Invoke();
                        }
                        _isAttcArry[tg] = true;
                        if (tg == _grpArry.Length - 1) {
                            dAftrAttc?.Invoke();
                        }
                        tg += 1;
                    }
                );
            }
        }

        public void Attc(Canvas cnvs, byte eGrp, DActn dAftrAttc = null) { // attach UI by generating specific objects group by enum, dAftrAttc = after attached
            if (_grpArry == null || _grpArry[eGrp] == null) {
                return;
            }
            if (_isAttcArry == null) {
                _isAttcArry = new bool[_grpArry.Length];
            } else if (_isAttcArry[eGrp]) {
                return;
            }
            if (_addrblArry == null) {
                _addrblArry = new GameObject[_grpArry.Length][];
                _gmObjcArry = new GameObject[_grpArry.Length][];
                _cmpnArry = new object[_grpArry.Length][];
            }
            if (_addrblArry[eGrp] == null) {
                _addrblArry[eGrp] = new GameObject[_grpArry[eGrp].Length];
                _gmObjcArry[eGrp] = new GameObject[_grpArry[eGrp].Length];
                _cmpnArry[eGrp] = new object[_grpArry[eGrp].Length];
            }
            _mnCnvs = cnvs;
            Gnr(
                eGrp,
                () => {
                    _dAftrGnrtArry[eGrp]?.Invoke();
                    _isAttcArry[eGrp] = true;
                    dAftrAttc?.Invoke();
                }
            );
        }

        public void Dtch() { // detach UI by release all object groups, dBD = before detached, dAD = after detached
            if (!IsAttc) {
                return;
            }
            for (byte g = 0; g < _addrblArry.Length; g++) {
                if (_addrblArry[g] != null) {
                    Rsrc.Rls(_addrblArry[g]);
                }
            }
            _dBhvrArry = null;
            _dAftrGnrtArry = null;
            _mngr = null;
            _mnCnvs = null;
            _grpArry = null;
            _cmpnArry = null;
            _addrblArry = null;
            _gmObjcArry = null;
            _isAttcArry = null;
        }

        public void Dtch(byte eGrp) { // detach UI by release specific object group by enum, dBD = before detached, dAD = after detached
            if (!IsAttc) {
                return;
            }
            if (!_isAttcArry[eGrp]) {
                return;
            }
            Rsrc.Rls(_addrblArry[eGrp]);
            _addrblArry[eGrp] = null;
            _gmObjcArry[eGrp] = null;
            _isAttcArry[eGrp] = false;
            if (!IsAttc) { // if any group is not attached
                _dBhvrArry = null;
                _dAftrGnrtArry = null;
                _mngr = null;
                _mnCnvs = null;
                _grpArry = null;
                _cmpnArry = null;
                _addrblArry = null;
                _gmObjcArry = null;
                _isAttcArry = null;
            }
        }

        public void Actv(byte eGrp) { // activate specific behavior group by enum
            if (_dBhvrArry[eGrp] == null) {
                return;
            }
            for (byte b = 0; b < _dBhvrArry[eGrp].Length; b++) {
                if (_dBhvrArry[eGrp][b] != null) {
                    _dBhvrArry[eGrp][b][0].Invoke(eGrp);
                }
            }
        }

        public void Hlt(byte eGrp) { // halt specific behavior group by enum
            if (_dBhvrArry[eGrp] == null) {
                return;
            }
            for (byte b = 0; b < _dBhvrArry[eGrp].Length; b++) {
                if (_dBhvrArry[eGrp][b] != null) {
                    _dBhvrArry[eGrp][b][1].Invoke(eGrp);
                }
            }
        }

        public void Actv(byte eGrp, byte eBhvr) { // activate specific behavior in specific group by enum
            if (_dBhvrArry[eGrp] == null) {
                return;
            }
            if (_dBhvrArry[eGrp][eBhvr] != null) {
                _dBhvrArry[eGrp][eBhvr][0].Invoke(eGrp);
            }
        }

        public void Hlt(byte eGrp, byte eBhvr) { // halt specific behavior in specific group by enum
            if (_dBhvrArry[eGrp] == null) {
                return;
            }
            if (_dBhvrArry[eGrp][eBhvr] != null) {
                _dBhvrArry[eGrp][eBhvr][1].Invoke(eGrp);
            }
        }

        public bool IsGrpAttc(byte eGrp) { // return specific group by enum was attached or not 
            return _isAttcArry[eGrp];
        }

        public GameObject GtGmObjc(byte eGrp, byte eObjc) { // return specific gameObjcect in specific group by enum
            if (!_isAttcArry[eGrp]) {
                return null;
            }
            return _gmObjcArry[eGrp][eObjc];
        }

        public T GtCmpn<T>(byte eGrp, byte eCmpn) { // return specific component by enum
            if (!_isAttcArry[eGrp]) {
                return default(T);
            }
            return (T)_cmpnArry[eGrp][eCmpn];
        }

        public void Enbl(byte eGrp) { // enable specific object group by enum
            if (!_isAttcArry[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gmObjcArry[eGrp].Length; o++) {
                _gmObjcArry[eGrp][o].SetActive(true);
            }
        }

        public void Dsbl(byte eGrp) { // disable specific object group by enum
            if (!_isAttcArry[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gmObjcArry[eGrp].Length; o++) {
                _gmObjcArry[eGrp][o].SetActive(false);
            }
        }

        public void Enbl(byte eGrp, byte eObjc) { // enable specific object in specific group by enum
            if (!_isAttcArry[eGrp]) {
                return;
            }
            _gmObjcArry[eGrp][eObjc].SetActive(true);
        }

        public void Dsbl(byte eGrp, byte eObjc) { // disable specific object in specific group by enum
            if (!_isAttcArry[eGrp]) {
                return;
            }
            _gmObjcArry[eGrp][eObjc].SetActive(false);
        }

        public void Frnt(byte eGrp) {
            if (!_isAttcArry[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gmObjcArry[(byte)eGrp].Length; o++) {
                _gmObjcArry[(byte)eGrp][o].transform.SetAsLastSibling();
            }
        }

        public void Bck(byte eGrp) {
            if (!_isAttcArry[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gmObjcArry[(byte)eGrp].Length; o++) {
                _gmObjcArry[(byte)eGrp][o].transform.SetAsFirstSibling();
            }
        }

        public void Frnt(byte eGrp, byte eObjc) {
            if (!_isAttcArry[eGrp]) {
                return;
            }
            _gmObjcArry[(byte)eGrp][(byte)eObjc].transform.SetAsLastSibling();
        }

        public void Bck(byte eGrp, byte eObjc) {
            if (!_isAttcArry[eGrp]) {
                return;
            }
            _gmObjcArry[(byte)eGrp][(byte)eObjc].transform.SetAsFirstSibling();
        }

        private void Gnr(byte eGrp, DActn dAftrGnrt) { // generate scene
            _tmpQryArry = new object[_grpArry[eGrp].Length][];
            for (byte o = 0; o < _grpArry[eGrp].Length; o++) {
                _tmpQryArry[o] = new object[3] {
                    _grpArry[eGrp][o][0],
                    new Vector3(((short[])_grpArry[eGrp][o][1])[0], ((short[])_grpArry[eGrp][o][1])[1], 0),
                    Quaternion.identity
                };
            }
            Rsrc.Inst(_tmpQryArry, _mnCnvs.transform, (rsltArry) => {
                for (byte r = 0; r < _grpArry[eGrp].Length; r++) {
                    rsltArry[r].name = _grpArry[eGrp][r][2].ToString();
                    _addrblArry[eGrp][r] = rsltArry[r];
                }
                _tmpTrnsfrmArry = new Transform[_addrblArry[eGrp].Length][];
                _tmpSbinstArry = new GameObject[_addrblArry[eGrp].Length * 32]; // array of subinstances
                _tmpIndx = 0;
                for (byte t1 = 0; t1 < _tmpTrnsfrmArry.Length; t1++) {
                    _tmpTrnsfrmArry[t1] = _addrblArry[eGrp][t1].GetComponentsInChildren<Transform>();
                    for (byte t2 = 1; t2 < _tmpTrnsfrmArry[t1].Length; t2++) {
                        _tmpSbinstArry[_tmpIndx] = _tmpTrnsfrmArry[t1][t2].gameObject;
                        _tmpIndx += 1;
                    }
                }
                _gmObjcArry[eGrp] = Arry.Apnd<GameObject>(_addrblArry[eGrp], Arry.Ct<GameObject>(_tmpSbinstArry, _tmpIndx));
                _cmpnArry[eGrp] = Ftch(_gmObjcArry[eGrp]);
                _tmpQryArry = null;
                _tmpTrnsfrmArry = null;
                _tmpSbinstArry = null;
                _tmpIndx = 0;
                rsltArry = null;
                Actv(eGrp);
                dAftrGnrt(); // after generate callback
            });
        }

        private object[] Ftch(GameObject[] gmObjcArry) { // fetch UI component from array of sub GameObjcects
            object[] cmpnArry = new object[0];
            for (byte o = 0; o < gmObjcArry.Length; o++) {
                for (byte t = 0; t < _mngr.TypArry.Length; t++) {
                    if (gmObjcArry[o].GetComponent(_mngr.TypArry[t])) {
                        cmpnArry = Arry.Add<object>(cmpnArry, gmObjcArry[o].GetComponent(_mngr.TypArry[t]));
                    }
                }
            }
            return cmpnArry;
        }
    }
}