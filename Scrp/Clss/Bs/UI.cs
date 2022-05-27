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
        protected UIMngr _mngr = null; // registered UI manager
        protected Canvas _cnvs; // canvas
        protected object[][][] _grpArry = null; // array of groups
        protected object[][] _cmpnArry = null; // array of components
        protected DActn<byte>[][][] _dBhvrArry; //delegate of behavior method
        protected DActn[] _dAftrGnrtArry = null; // array of after generating delegate
        private GameObject[][] _instArry = null; // array of instances
        private GameObject[][] _gmObjcArry = null; // array of GameObjects
        private bool[] _isAttcArry = null; // array of bool as is atached or not

        public void Attc(Canvas cnvs, DActn dAftrAttc = null) { // attach UI by generating all objects group, dAftrAttc = after attached
            if (_isAttcArry == null) {
                _isAttcArry = new bool[_grpArry.Length];
            }
            if (_instArry == null) {
                _instArry = new GameObject[_grpArry.Length][];
                _gmObjcArry = new GameObject[_grpArry.Length][];
                _cmpnArry = new object[_grpArry.Length][];
            }
            _cnvs = cnvs;
            byte tg = 0;
            for (byte g = 0; g < _grpArry.Length; g++) {
                if (_instArry[g] == null) {
                    _instArry[g] = new GameObject[_grpArry[g].Length];
                    _gmObjcArry[g] = new GameObject[_grpArry[g].Length];
                    _cmpnArry[g] = new object[_grpArry[g].Length];
                }
                Gnr(
                    g,
                    () => {
                        _dAftrGnrtArry[tg]?.Invoke();
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
            if (_isAttcArry == null) {
                _isAttcArry = new bool[_grpArry.Length];
            } else if (_isAttcArry[eGrp]) {
                return;
            }
            if (_instArry == null) {
                _instArry = new GameObject[_grpArry.Length][];
                _gmObjcArry = new GameObject[_grpArry.Length][];
                _cmpnArry = new object[_grpArry.Length][];
            }
            if (_instArry[eGrp] == null) {
                _instArry[eGrp] = new GameObject[_grpArry[eGrp].Length];
                _gmObjcArry[eGrp] = new GameObject[_grpArry[eGrp].Length];
                _cmpnArry[eGrp] = new object[_grpArry[eGrp].Length];
            }
            _cnvs = cnvs;
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
            for (byte g = 0; g < _instArry.Length; g++) {
                if (_instArry[g] != null) {
                    Rsrc.Rls(_instArry[g]);
                }
            }
            _cnvs = null;
            _instArry = null;
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
            Rsrc.Rls(_instArry[eGrp]);
            _instArry[eGrp] = null;
            _gmObjcArry[eGrp] = null;
            _isAttcArry[eGrp] = false;
            if (!IsAttc) { // if any group is not attached
                _cnvs = null;
                _instArry = null;
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

        public GameObject GmObjc(byte eGrp, byte eObjc) { // return specific gameObjcect in specific group by enum
            if (!_isAttcArry[eGrp]) {
                return null;
            }
            return _gmObjcArry[eGrp][eObjc];
        }

        public T Cmpn<T>(byte eGrp, byte eCmpn) { // return specific component by enum
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
            object[][] qryArry = new object[_grpArry[eGrp].Length][];
            for (byte o = 0; o < _grpArry[eGrp].Length; o++) {
                qryArry[o] = new object[3] {
                    _grpArry[eGrp][o][0],
                    new Vector3(((short[])_grpArry[eGrp][o][1])[0], ((short[])_grpArry[eGrp][o][1])[1], 0),
                    Quaternion.identity
                };
            }
            Rsrc.Inst(qryArry, _cnvs.transform, (rslArry) => {
                for (byte r = 0; r < _grpArry[eGrp].Length; r++) {
                    rslArry[r].name = _grpArry[eGrp][r][2].ToString();
                    _instArry[eGrp][r] = rslArry[r];
                }
                Transform[][] trnsfrmArry = new Transform[_instArry[eGrp].Length][];
                GameObject[] sbinstArry = new GameObject[0]; // array of subinstances
                for (byte t1 = 0; t1 < trnsfrmArry.Length; t1++) {
                    trnsfrmArry[t1] = _instArry[eGrp][t1].GetComponentsInChildren<Transform>();
                    for (byte t2 = 1; t2 < trnsfrmArry[t1].Length; t2++) {
                        sbinstArry = Arry.Add<GameObject>(sbinstArry, trnsfrmArry[t1][t2].gameObject);
                    }
                }
                _gmObjcArry[eGrp] = Arry.Apnd<GameObject>(_instArry[eGrp], sbinstArry);
                _cmpnArry[eGrp] = Ftch(_gmObjcArry[eGrp]);
                qryArry = null;
                rslArry = null;
                trnsfrmArry = null;
                sbinstArry = null;
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