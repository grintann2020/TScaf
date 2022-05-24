namespace T {

    public abstract class Spc { // Space

        public bool IsCnst { get { return _isCnst; } }
        protected byte _untWdth = 0; // unit width
        protected byte _untLngt = 0; // unit length
        protected byte _untHght = 0; // unit height

        protected IUnt[][][] _iUntArry;
        protected ISpc _iSpc;

        private bool _isCnst = false;

        public void Cnst(SCrdn3 sCtr) { // construct
            _isCnst = true;
            // _iBlkArr = _iSpc.Cnst(_curArr, sCtr);
        }

        public void Dcnst() { // deconstruct
            _isCnst = false;
            // Array.Clear(_iUntArry, 0, _iUntArry.Length);
        }

        // public abstract IUnt[][][] Cnst(byte[][][] eUArry, SCrdn3 ctr);
        // public abstract void Estb(IUnt[][][] iUntArr, string[][] uArry);
        // public abstract void Elmn(IUnt[][][] iUntArr);
    }
}