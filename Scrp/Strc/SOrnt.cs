using System;

namespace T {

    public struct SOrnt2 {

        public SVctr2 P0, P1;
        public float DistX { get { return P1.X - P0.X; } }
        public float DistY { get { return P1.Y - P0.Y; } }
        public float Dist {
            get { return (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2)); }
        }

        public SOrnt2(SVctr2 p0, SVctr2 p1) {
            P0 = p0;
            P1 = p1;
        }
    }

    public struct SOrnt3 {

        public SVctr3 P0, P1;
        public float DistX { get { return P1.X - P0.X; } }
        public float DistY { get { return P1.Y - P0.Y; } }
        public float DistZ { get { return P1.Z - P0.Z; } }
        public float Dist {
            get { return (float)Math.Sqrt(Math.Pow(DistX, 2) + Math.Pow(DistY, 2) + Math.Pow(DistZ, 2)); }
        }

        public SOrnt3(SVctr3 p0, SVctr3 p1) {
            P0 = p0;
            P1 = p1;
        }
    }
}