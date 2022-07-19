using UnityEngine;

namespace T {

    public struct SObj {

        public GameObject GO { get { return _gO; } }
        public Transform Tf { get { return _gO.transform; } }
        public Vector3 Pst {  get { return _gO.transform.position; } }
        public object Ins { get { return _ins; } }
        public int Id { get { return _gO.transform.GetInstanceID(); } }
        public byte EObj { get { return _eObj; } }
        public bool IsEnb { get { return _gO.activeSelf; } }
        private GameObject _gO;
        private object _ins;
        private byte _eObj;

        public SObj(byte eObj, object ins, GameObject gO) {
            _eObj = eObj;
            _ins = ins;
            _gO = gO;
        }

        public void Enb() {
            _gO.SetActive(true);
        }

        public void Dsb() {
            _gO.SetActive(false);
        }

        public void StPst(SVct3 sVct) {
            _gO.transform.position = new Vector3(sVct.X, sVct.Y, sVct.Z);
        }

        public void StRtt(SVct3 sVct) {
            _gO.transform.rotation = Quaternion.Euler(sVct.X, sVct.Y, sVct.Z);
        }

        public void StScl(SVct3 sVct) {
            _gO.transform.localScale = new Vector3(sVct.X, sVct.Y, sVct.Z);
        }
    }
}