namespace T {

    public struct SCmrPrjc {

        public bool Orthgrph; // Orthographic - Is the camera orthographic (true) or perspective (false)?
        public float OrthgrphSz;  // OrthographicSize - Camera's half-size when in orthographic mode.
        public float FOV; // FieldOfView - The field of view of the camera in degrees.
        public float Nr; // NearClipPlane - The distance of the near clipping plane from the the Camera, in world units.
        public float Fr; // FarClipPlane - The distance of the far clipping plane from the Camera, in world units.
        public bool PhyCmr; // UsePhysicalProperties - Enable [UsePhysicalProperties] to use physical camera properties to compute the field of view and the frustum.

        public SCmrPrjc(bool orthgrph, float orthgrphSz, float fov, float nr, float fr, bool phyCmr) {
            Orthgrph = orthgrph;
            OrthgrphSz =  orthgrph ? orthgrphSz : float.NaN;
            FOV = fov;
            Nr = nr;
            Fr = fr;
            PhyCmr = phyCmr;
        }
    }
}