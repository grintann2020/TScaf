using UnityEngine;

namespace T {

    public struct SObjc {

        public GameObject GmObjc { get { return _gmObjc; } }
        public Transform Trnsfrm { get { return _gmObjc.transform; } }
        public Vector3 Pstn {  get { return _gmObjc.transform.position; } }
        public object Inst { get { return _inst; } }
        public int Id { get { return _gmObjc.transform.GetInstanceID(); } }
        public byte EObjc { get { return _eObjc; } }
        public bool IsEnbl { get { return _gmObjc.activeSelf; } }
        private GameObject _gmObjc;
        private object _inst;
        private byte _eObjc;

        public SObjc(byte eObjc, object inst, GameObject gmObjc) {
            _eObjc = eObjc;
            _inst = inst;
            _gmObjc = gmObjc;
        }

        public void Enbl() {
            _gmObjc.SetActive(true);
        }

        public void Dsbl() {
            _gmObjc.SetActive(false);
        }

        public void StPstn(SVctr3 sVctr) {
            _gmObjc.transform.position = new Vector3(sVctr.X, sVctr.Y, sVctr.Z);
        }

        public void StRttn(SVctr3 sVctr) {
            _gmObjc.transform.rotation = Quaternion.Euler(sVctr.X, sVctr.Y, sVctr.Z);
        }

        public void StScl(SVctr3 sVctr) {
            _gmObjc.transform.localScale = new Vector3(sVctr.X, sVctr.Y, sVctr.Z);
        }
    }
}