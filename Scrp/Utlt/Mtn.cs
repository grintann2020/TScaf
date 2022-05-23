namespace T {

    public static class Mtn {

        public static SCrdn3[] Trck(SCrdn3 a, SCrdn3 b, ushort s) { // Trk
            SCrdn3[] arr = new SCrdn3[s];
            float x = (b.X - a.X) / s;
            float y = (b.Y - a.Y) / s;
            float z = (b.Z - a.Z) / s;
            for (ushort c = 0; c < s; c++) {
                arr[c] = new SCrdn3((x * c) + a.X, (y * c) + a.Y, (z * c) + a.Z);
            }
            return arr;
        }

        public static SCrdn3[][] Trck2(SCrdn3 a1, SCrdn3 b1, SCrdn3 a2, SCrdn3 b2, ushort s) {  // Trk
            SCrdn3[][] arr = new SCrdn3[s][];
            float x1 = (b1.X - a1.X) / s;
            float y1 = (b1.Y - a1.Y) / s;
            float z1 = (b1.Z - a1.Z) / s;
            float x2 = (b2.X - a2.X) / s;
            float y2 = (b2.Y - a2.Y) / s;
            float z2 = (b2.Z - a2.Z) / s;
            for (ushort c = 0; c < s; c++) {
                arr[c] = new SCrdn3[2] {
                    new SCrdn3((x1 * c) + a1.X, (y1 * c) + a1.Y, (z1 * c) + a1.Z),
                    new SCrdn3((x2 * c) + a2.X, (y2 * c) + a2.Y, (z2 * c) + a2.Z)
                };
            }
            return arr;
        }
    }
}