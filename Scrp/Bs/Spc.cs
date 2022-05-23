using System;

namespace T {

    public abstract class Spc { // Space

        public bool IsCnstr { get { return _isCnstr; } }

        protected byte _untWdth; // unit width
        protected byte _untHght; // unit height

        protected IBlck[][][] _iBlckArry;
        protected ISpc _iSpc;

        private bool _isCnstr = false;

        // public Spc(byte uWd, byte uHt) {
        //     _uWd = uWd;
        //     _uHt = uHt;
        // }

        public void Cnstr(SCrdn3 sCtr) {
            _isCnstr = true;
            // _iBlkArr = _iSpc.Cnstr(_curArr, sCtr);
        }

        public void Dcstr() {
            _isCnstr = false;
            Array.Clear(_iBlckArry, 0, _iBlckArry.Length);
        }

        public abstract IBlck[][][] Cnstr(byte[][][] eUArry, SCrdn3 ctr);
        public abstract void Estb(IBlck[][][] iBlckArr, string[][] uArry);
        public abstract void Elmn(IBlck[][][] iBlckArr);
    }
}