using UnityEngine;

namespace T {

    public class SObjc {

        public GameObject GmObjc { get { return _gmObjc; } }
        public object Inst { get { return _inst; } }
        public int Id { get { return _gmObjc.GetInstanceID(); } }
        public byte EObjc { get { return _eObjc; } }
        public bool IsEnbl;
        private GameObject _gmObjc;
        private object _inst;
        private byte _eObjc;

        public SObjc(bool isEnbl, byte eObjc, object inst, GameObject gmObjc) {
            IsEnbl = isEnbl;
            _eObjc = eObjc;
            _inst = inst;
            _gmObjc = gmObjc;
        }
    }
}