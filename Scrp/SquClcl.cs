namespace T {

    public static class SquClcl {

        public static SCrdn3 Org(byte rows, byte cols, byte uWd) { // xUs = number of units along x axis

            return new SCrdn3(
                -(((float)rows * (float)uWd) / 2) + ((float)uWd / 2),
                0.0f,
                (((float)cols * (float)uWd) / 2) - ((float)uWd / 2)
            );
        }
    }
}