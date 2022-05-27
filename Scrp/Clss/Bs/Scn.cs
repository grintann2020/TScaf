using UnityEngine;

namespace T {

    public class Scn { // scene

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
        protected DActn[] _dAftrGnrtArry = null; // an array of after generating delegate
        protected ScnMngr _mngr = null; // registered scene manager
        protected ISpc _iSpc = null; // space interface
        protected object[][][] _grpArry = null; // an array of object groups
        private Transform _trnsfrm = null; // transform
        private GameObject[][] _instArry = null; // an array of instances
        private GameObject[][] _gmObjcArry = null; // an array of GameObjects
        private bool[] _isEstbArry = null; // is established or not
        
        public Scn(ISpc iSpc = null) {
            _iSpc = iSpc;
        }

        public void Estb(Transform trnsfrm, DActn dAftrEstb = null, byte eExst = 0) { // establish scene by generating all objects group, dAftrEstb = after established
            _iSpc?.Cnst(eExst);
            if (_isEstbArry == null) {
                _isEstbArry = new bool[_grpArry.Length];
            }
            if (_instArry == null) {
                _instArry = new GameObject[_grpArry.Length][];
                _gmObjcArry = new GameObject[_grpArry.Length][];
            }
            _trnsfrm = trnsfrm;
            byte tg = 0;
            for (byte g = 0; g < _grpArry.Length; g++) {
                if (_instArry[g] == null) {
                    _instArry[g] = new GameObject[_grpArry[g].Length];
                    _gmObjcArry[g] = new GameObject[_grpArry[g].Length];
                }
                Gnrt(
                    g,
                    () => {
                        _dAftrGnrtArry[tg]?.Invoke();
                        _isEstbArry[tg] = true;
                        if (tg == _grpArry.Length - 1) {
                            dAftrEstb?.Invoke();
                        }
                        tg += 1;
                    }
                );
            }
        }

        public void Estb(Transform trnsfrm, byte eGrp, DActn dAftrEstb = null, byte eExst = 0) { // establish scene by generating specific objects group by enum, dAftrEstb = after established
            _iSpc?.Cnst(eExst);
            if (_isEstbArry == null) {
                _isEstbArry = new bool[_grpArry.Length];
            } else if (_isEstbArry[eGrp]) {
                return;
            }
            if (_instArry == null) {
                _instArry = new GameObject[_grpArry.Length][];
                _gmObjcArry = new GameObject[_grpArry.Length][];
            }
            if (_instArry[eGrp] == null) {
                _instArry[eGrp] = new GameObject[_grpArry[eGrp].Length];
                _gmObjcArry[eGrp] = new GameObject[_grpArry[eGrp].Length];
            }
            _trnsfrm = trnsfrm;
            Gnrt(
                eGrp,
                () => {
                    _dAftrGnrtArry[eGrp]?.Invoke();
                    _isEstbArry[eGrp] = true;
                    dAftrEstb?.Invoke();
                }
            );
        }

        public void Elmn() { // eliminate scene by release all object groups
            if (!IsEstb) {
                return;
            }
            for (byte g = 0; g < _instArry.Length; g++) {
                if (_instArry[g] != null) {
                    Rsrc.Rls(_instArry[g]);
                }
            }
            _trnsfrm = null;
            _instArry = null;
            _gmObjcArry = null;
            _isEstbArry = null;
            _iSpc?.Dcnst();
        }

        public void Elmn(byte eGrp) { // eliminate scene by release specific object group by enum
            if (!IsEstb) {
                return;
            }
            if (!_isEstbArry[eGrp]) {
                return;
            }
            Rsrc.Rls(_instArry[eGrp]);
            _instArry[eGrp] = null;
            _gmObjcArry[eGrp] = null;
            _isEstbArry[eGrp] = false;
            if (!IsEstb) {
                _trnsfrm = null;
                _instArry = null;
                _gmObjcArry = null;
                _isEstbArry = null;
            }
            _iSpc?.Dcnst();
        }

        public bool IsGrpEstb(byte eGrp) { // return is group established or not
            return _isEstbArry[eGrp];
        }

        public GameObject GmObjc(byte eGrp, byte eObjc) { // return specific gameObjcect in specific group by enum
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
            object[][] qryArry = new object[_grpArry[eGrp].Length][];
            for (byte o = 0; o < _grpArry[eGrp].Length; o++) {
                qryArry[o] = new object[3] {
                    _grpArry[eGrp][o][0],
                    new Vector3(((float[])_grpArry[eGrp][o][1])[0], ((float[])_grpArry[eGrp][o][1])[1], ((float[])_grpArry[eGrp][o][1])[2]),
                    new Quaternion(((float[])_grpArry[eGrp][o][2])[0], ((float[])_grpArry[eGrp][o][2])[1], ((float[])_grpArry[eGrp][o][2])[2], ((float[])_grpArry[eGrp][o][2])[3]),
                };
            }
            Rsrc.Inst(qryArry, _trnsfrm, (rslArry) => {
                for (byte r = 0; r < _grpArry[eGrp].Length; r++) {
                    rslArry[r].name = _grpArry[eGrp][r][3].ToString();
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
                qryArry = null;
                rslArry = null;
                trnsfrmArry = null;
                sbinstArry = null;
                dAftrGnrt(); // after generate callback
            });
        }
    }
}