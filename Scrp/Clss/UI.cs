using UnityEngine;

namespace T {

    public class UI {

        public UIMngr Mngr { set { _mngr = value; } }
        public bool IsAttc {
            get {
                if (_isAttcs != null) {
                    for (byte i = 0; i < _isAttcs.Length; i++) {
                        if (_isAttcs[i]) {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        protected DActn<byte>[][][] _dBhvrs = null; //delegate of behavior method
        protected DActn[] _dAftrGnrts = null; // array of after generating delegate
        protected UIMngr _mngr = null; // registered UI manager
        protected Canvas _mnCnvs = null; // the main canvas
        protected object[][][] _grps = null; // the array of groups
        protected object[][] _cmpns = null; // the array of components
        private GameObject[][] _addrbls = null; // the array of instances
        private GameObject[][] _gmObjcs = null; // the array of GameObjects
        private GameObject[] _tmpSbinsts = null; // the array for temp storage of sub GameObject
        private Transform[][] _tmpTrnsfrms = null; // the array for temp storage of Transform
        private bool[] _isAttcs = null; // the array of bool as is atached or not

        public void Attc(Canvas cnvs, DActn dAftrAttc = null) { // attach UI by generating all objects group, dAftrAttc = after attached
            if (_grps == null) {
                return;
            } else {
                for (byte g = 0; g < _grps.Length; g++) {
                    if (_grps[g] == null) {
                        return;
                    }
                }
            }
            if (_isAttcs == null) {
                _isAttcs = new bool[_grps.Length];
            }
            if (_addrbls == null) {
                _addrbls = new GameObject[_grps.Length][];
                _gmObjcs = new GameObject[_grps.Length][];
                _cmpns = new object[_grps.Length][];
            }
            _mnCnvs = cnvs;
            byte tg = 0;
            for (byte g = 0; g < _grps.Length; g++) {
                if (_grps[g] == null) {
                    continue;
                }
                if (_addrbls[g] == null) {
                    _addrbls[g] = new GameObject[_grps[g].Length];
                    _gmObjcs[g] = new GameObject[_grps[g].Length];
                    _cmpns[g] = new object[_grps[g].Length];
                }
                Gnr(
                    g,
                    () => {
                        if (_dAftrGnrts != null) {
                            _dAftrGnrts[tg]?.Invoke();
                        }
                        _isAttcs[tg] = true;
                        if (tg == _grps.Length - 1) {
                            dAftrAttc?.Invoke();
                        }
                        tg += 1;
                    }
                );
            }
        }

        public void Attc(Canvas cnvs, byte eGrp, DActn dAftrAttc = null) { // attach UI by generating specific objects group by enum, dAftrAttc = after attached
            if (_grps == null || _grps[eGrp] == null) {
                return;
            }
            if (_isAttcs == null) {
                _isAttcs = new bool[_grps.Length];
            } else if (_isAttcs[eGrp]) {
                return;
            }
            if (_addrbls == null) {
                _addrbls = new GameObject[_grps.Length][];
                _gmObjcs = new GameObject[_grps.Length][];
                _cmpns = new object[_grps.Length][];
            }
            if (_addrbls[eGrp] == null) {
                _addrbls[eGrp] = new GameObject[_grps[eGrp].Length];
                _gmObjcs[eGrp] = new GameObject[_grps[eGrp].Length];
                _cmpns[eGrp] = new object[_grps[eGrp].Length];
            }
            _mnCnvs = cnvs;
            Gnr(
                eGrp,
                () => {
                    _dAftrGnrts[eGrp]?.Invoke();
                    _isAttcs[eGrp] = true;
                    dAftrAttc?.Invoke();
                }
            );
        }

        public void Dtch() { // detach UI by release all object groups, dBD = before detached, dAD = after detached
            if (!IsAttc) {
                return;
            }
            for (byte g = 0; g < _addrbls.Length; g++) {
                if (_addrbls[g] != null) {
                    Rsrc.Rls(_addrbls[g]);
                }
            }
            _dBhvrs = null;
            _dAftrGnrts = null;
            _mngr = null;
            _mnCnvs = null;
            _grps = null;
            _cmpns = null;
            _addrbls = null;
            _gmObjcs = null;
            _isAttcs = null;
        }

        public void Dtch(byte eGrp) { // detach UI by release specific object group by enum, dBD = before detached, dAD = after detached
            if (!IsAttc) {
                return;
            }
            if (!_isAttcs[eGrp]) {
                return;
            }
            Rsrc.Rls(_addrbls[eGrp]);
            _addrbls[eGrp] = null;
            _gmObjcs[eGrp] = null;
            _isAttcs[eGrp] = false;
            if (!IsAttc) { // if any group is not attached
                _dBhvrs = null;
                _dAftrGnrts = null;
                _mngr = null;
                _mnCnvs = null;
                _grps = null;
                _cmpns = null;
                _addrbls = null;
                _gmObjcs = null;
                _isAttcs = null;
            }
        }

        public void Actv(byte eGrp) { // activate specific behavior group by enum
            if (_dBhvrs[eGrp] == null) {
                return;
            }
            for (byte b = 0; b < _dBhvrs[eGrp].Length; b++) {
                if (_dBhvrs[eGrp][b] != null) {
                    _dBhvrs[eGrp][b][0].Invoke(eGrp);
                }
            }
        }

        public void Hlt(byte eGrp) { // halt specific behavior group by enum
            if (_dBhvrs[eGrp] == null) {
                return;
            }
            for (byte b = 0; b < _dBhvrs[eGrp].Length; b++) {
                if (_dBhvrs[eGrp][b] != null) {
                    _dBhvrs[eGrp][b][1].Invoke(eGrp);
                }
            }
        }

        public void Actv(byte eGrp, byte eBhvr) { // activate specific behavior in specific group by enum
            if (_dBhvrs[eGrp] == null) {
                return;
            }
            if (_dBhvrs[eGrp][eBhvr] != null) {
                _dBhvrs[eGrp][eBhvr][0].Invoke(eGrp);
            }
        }

        public void Hlt(byte eGrp, byte eBhvr) { // halt specific behavior in specific group by enum
            if (_dBhvrs[eGrp] == null) {
                return;
            }
            if (_dBhvrs[eGrp][eBhvr] != null) {
                _dBhvrs[eGrp][eBhvr][1].Invoke(eGrp);
            }
        }

        public bool IsGrpAttc(byte eGrp) { // return specific group by enum was attached or not 
            return _isAttcs[eGrp];
        }

        public GameObject GtGmObjc(byte eGrp, byte eObjc) { // return specific gameObjcect in specific group by enum
            if (!_isAttcs[eGrp]) {
                return null;
            }
            return _gmObjcs[eGrp][eObjc];
        }

        public T GtCmpn<T>(byte eGrp, byte eCmpn) { // return specific component by enum
            if (!_isAttcs[eGrp]) {
                return default(T);
            }
            return (T)_cmpns[eGrp][eCmpn];
        }

        public void Enbl(byte eGrp) { // enable specific object group by enum
            if (!_isAttcs[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gmObjcs[eGrp].Length; o++) {
                _gmObjcs[eGrp][o].SetActive(true);
            }
        }

        public void Dsbl(byte eGrp) { // disable specific object group by enum
            if (!_isAttcs[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gmObjcs[eGrp].Length; o++) {
                _gmObjcs[eGrp][o].SetActive(false);
            }
        }

        public void Enbl(byte eGrp, byte eObjc) { // enable specific object in specific group by enum
            if (!_isAttcs[eGrp]) {
                return;
            }
            _gmObjcs[eGrp][eObjc].SetActive(true);
        }

        public void Dsbl(byte eGrp, byte eObjc) { // disable specific object in specific group by enum
            if (!_isAttcs[eGrp]) {
                return;
            }
            _gmObjcs[eGrp][eObjc].SetActive(false);
        }

        public void Frnt(byte eGrp) {
            if (!_isAttcs[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gmObjcs[(byte)eGrp].Length; o++) {
                _gmObjcs[(byte)eGrp][o].transform.SetAsLastSibling();
            }
        }

        public void Bck(byte eGrp) {
            if (!_isAttcs[eGrp]) {
                return;
            }
            for (byte o = 0; o < _gmObjcs[(byte)eGrp].Length; o++) {
                _gmObjcs[(byte)eGrp][o].transform.SetAsFirstSibling();
            }
        }

        public void Frnt(byte eGrp, byte eObjc) {
            if (!_isAttcs[eGrp]) {
                return;
            }
            _gmObjcs[(byte)eGrp][(byte)eObjc].transform.SetAsLastSibling();
        }

        public void Bck(byte eGrp, byte eObjc) {
            if (!_isAttcs[eGrp]) {
                return;
            }
            _gmObjcs[(byte)eGrp][(byte)eObjc].transform.SetAsFirstSibling();
        }

        private void Gnr(byte eGrp, DActn dAftrGnrt) { // generate scene
            SInst[] sInsts = new SInst[_grps[eGrp].Length];
            for (byte o = 0; o < _grps[eGrp].Length; o++) {
                sInsts[o] = new SInst (
                    (string)_grps[eGrp][o][0],
                    new Vector3(((short[])_grps[eGrp][o][1])[0], ((short[])_grps[eGrp][o][1])[1], 0),
                    Quaternion.identity
                );
            }
            Rsrc.Inst(sInsts, _mnCnvs.transform, (rslts) => {
                for (byte r = 0; r < _grps[eGrp].Length; r++) {
                    rslts[r].name = _grps[eGrp][r][2].ToString();
                    _addrbls[eGrp][r] = rslts[r];
                }
                _tmpTrnsfrms = new Transform[_addrbls[eGrp].Length][];
                _tmpSbinsts = new GameObject[_addrbls[eGrp].Length * 32]; // array of subinstances
                int indx = 0;
                for (byte t1 = 0; t1 < _tmpTrnsfrms.Length; t1++) {
                    _tmpTrnsfrms[t1] = _addrbls[eGrp][t1].GetComponentsInChildren<Transform>();
                    for (byte t2 = 1; t2 < _tmpTrnsfrms[t1].Length; t2++) {
                        _tmpSbinsts[indx] = _tmpTrnsfrms[t1][t2].gameObject;
                        indx += 1;
                    }
                }
                _gmObjcs[eGrp] = Arry.Apnd<GameObject>(_addrbls[eGrp], Arry.Cut<GameObject>(_tmpSbinsts, indx));
                _cmpns[eGrp] = Ftch(_gmObjcs[eGrp]);
                _tmpTrnsfrms = null;
                _tmpSbinsts = null;
                rslts = null;
                Actv(eGrp);
                dAftrGnrt(); // after generate callback
            });
        }

        private object[] Ftch(GameObject[] gmObjcs) { // fetch UI component from array of sub GameObjcects
            object[] cmpns = new object[0];
            for (byte o = 0; o < gmObjcs.Length; o++) {
                for (byte t = 0; t < _mngr.Typs.Length; t++) {
                    if (gmObjcs[o].GetComponent(_mngr.Typs[t])) {
                        cmpns = Arry.Add<object>(cmpns, gmObjcs[o].GetComponent(_mngr.Typs[t]));
                    }
                }
            }
            return cmpns;
        }
    }
}