namespace T {

    public static class Mtn {

        public static SVctr3[] Trck(SVctr3 a, SVctr3 b, ushort s) { // Trk
            SVctr3[] arr = new SVctr3[s];
            float x = (b.X - a.X) / s;
            float y = (b.Y - a.Y) / s;
            float z = (b.Z - a.Z) / s;
            for (ushort c = 0; c < s; c++) {
                arr[c] = new SVctr3((x * c) + a.X, (y * c) + a.Y, (z * c) + a.Z);
            }
            return arr;
        }

        public static SVctr3[][] Trck2(SVctr3 a1, SVctr3 b1, SVctr3 a2, SVctr3 b2, ushort s) {  // Trk
            SVctr3[][] arr = new SVctr3[s][];
            float x1 = (b1.X - a1.X) / s;
            float y1 = (b1.Y - a1.Y) / s;
            float z1 = (b1.Z - a1.Z) / s;
            float x2 = (b2.X - a2.X) / s;
            float y2 = (b2.Y - a2.Y) / s;
            float z2 = (b2.Z - a2.Z) / s;
            for (ushort c = 0; c < s; c++) {
                arr[c] = new SVctr3[2] {
                    new SVctr3((x1 * c) + a1.X, (y1 * c) + a1.Y, (z1 * c) + a1.Z),
                    new SVctr3((x2 * c) + a2.X, (y2 * c) + a2.Y, (z2 * c) + a2.Z)
                };
            }
            return arr;
        }
    }
}