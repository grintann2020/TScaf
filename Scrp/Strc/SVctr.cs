namespace T {

    public struct SVctr2 {

        public float X { get { return _arry[0]; } }
        public float Y { get { return _arry[1]; } }
        public float[] Arry { get { return _arry; } }
        private float[] _arry;

        public SVctr2(float x, float y) {
            _arry = new float[] { x, y };
        }
    }

    public struct SVctr3 {

        public float X { get { return _arry[0]; } }
        public float Y { get { return _arry[1]; } }
        public float Z { get { return _arry[2]; } }
        public float[] Arry { get { return _arry; } }
        private float[] _arry;

        public SVctr3(float x, float y, float z) {
            _arry = new float[] { x, y, z };
        }
    }
}