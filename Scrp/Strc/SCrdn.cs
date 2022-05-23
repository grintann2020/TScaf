namespace T {

    public struct SCrdn2 {

        public float X { get { return _arry[0]; } }
        public float Y { get { return _arry[1]; } }
        public float[] Arry { get { return _arry; } }
        private float[] _arry;

        public SCrdn2(float x, float y) {
            _arry = new float[] { x, y };
        }
    }

    public struct SCrdn3 {

        public float X { get { return _arry[0]; } }
        public float Y { get { return _arry[1]; } }
        public float Z { get { return _arry[2]; } }
        public float[] Arry { get { return _arry; } }
        private float[] _arry;

        public SCrdn3(float x, float y, float z) {
            _arry = new float[] { x, y, z };
        }
    }
}