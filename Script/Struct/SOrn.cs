using System;

namespace T {

    public struct SOrn2 {

        public SVct2 P0, P1;
        public float DstX { get { return P1.X - P0.X; } }
        public float DstY { get { return P1.Y - P0.Y; } }
        public float Dst {
            get { return (float)Math.Sqrt(Math.Pow(DstX, 2) + Math.Pow(DstY, 2)); }
        }

        public SOrn2(SVct2 p0, SVct2 p1) {
            P0 = p0;
            P1 = p1;
        }
    }

    public struct SOrn3 {

        public SVct3 P0, P1;
        public float DstX { get { return P1.X - P0.X; } }
        public float DstY { get { return P1.Y - P0.Y; } }
        public float DstZ { get { return P1.Z - P0.Z; } }
        public float Dst {
            get { return (float)Math.Sqrt(Math.Pow(DstX, 2) + Math.Pow(DstY, 2) + Math.Pow(DstZ, 2)); }
        }

        public SOrn3(SVct3 p0, SVct3 p1) {
            P0 = p0;
            P1 = p1;
        }
    }
}