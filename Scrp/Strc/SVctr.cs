using UnityEngine;

namespace T {

    public struct SVctr2 {

        public float X { get { return _arry[0]; } }
        public float Y { get { return _arry[1]; } }
        public float[] Arry { get { return _arry; } }
        private float[] _arry;

        public SVctr2(Vector2 vctr2) {
            _arry = new float[] { vctr2.x, vctr2.y };
        }

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

        public SVctr3(Vector3 vctr3) {
            _arry = new float[] { vctr3.x, vctr3.y, vctr3.z };
        }

        public SVctr3(float x, float y, float z) {
            _arry = new float[] { x, y, z };
        }
    }
}