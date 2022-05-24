namespace T {

    public static class HxClcl {

        private const float ASPC_RT = 1.732050807568877f; // aspect ratio

        private static int[,][] drctArry = {
            {new int[]{0, +1}, new int[]{-1,  0}, new int[]{-1, -1}, new int[]{0, -1}, new int[]{+1, -1}, new int[]{+1,  0}},
            {new int[]{0, +1}, new int[]{-1, +1}, new int[]{-1,  0}, new int[]{0, -1}, new int[]{+1,  0}, new int[]{+1, +1}}
        };

        public static int[] Adjc(int rw, int drct) {
            int prty = rw & 1;
            return drctArry[prty, drct]; // parity, direction
        }

        // public Hex Adjc(Hex[,] hexs, Hex hex, int hexDirection)
        // {

        // if (hex.Row <= 0 || hex.Col <= 0 || hex.Row >= hexs.GetLength(0) - 1 || hex.Col >= hexs.GetLength(1) - 1)
        // {
        //     return null;
        // }
        //     int parity = hex.Row & 1;
        //     int[] direct = this.drctArry[parity, hexDirection];
        //     Debug.Log(
        //         " direct = "+ hexDirection + ", " +
        //         " rw = " + hex.Row + ", rw + direct[0] = " + (hex.Row + direct[0]) + " || " +
        //         " col = " + hex.Col + ", col + direct[1] = " + (hex.Col + direct[1])
        //     );
        //     return hexs[hex.Row + direct[0], hex.Col + direct[1]];
        // }

        public static (float hrznDist, float vrtcDist) DstrDstn(float sz) { // return distribute distance
            return (HrznDstn(sz), VrtcDstn(sz));
        }

        public static float HrznDstn(float size) { // horizontal distance
            return UntWdth(HxWdth(size)) * 2;
        }

        public static float VrtcDstn(float size) { // vertical distance
            return UntHght(HxHght(size)) * 3;
        }

        public static float UntWdth(float hxWdth) { // unit width
            return hxWdth / 2;
        }

        public static float UntHght(float hxHght) { // unit height
            return hxHght / 4;
        }

        public static float HxWdth(float sz) { // hexagon width
            return sz * ASPC_RT;
        }

        public static float HxHght(float sz) { // hexagon height
            return sz * 2;
        }

        public static SCrdn3 CntrPstn(int hrznUnts, int vrtcUnts, float hrznUntSpcn, float vrtcUntSpcn) { // return center position, spcn = spacing
            return new SCrdn3(
                -((hrznUntSpcn * (float)hrznUnts) / 2) + (hrznUntSpcn / 2),
                0.0f,
                ((vrtcUntSpcn * (float)vrtcUnts) / 2) - (vrtcUntSpcn / 2)
            );
        }
    }
}