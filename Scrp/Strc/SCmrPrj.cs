namespace T {

    public struct SCmrPrj {

        public bool Og; // Orthographic - Is the camera orthographic (true) or perspective (false)?
        public float OgSz;  // OrthographicSize - Camera's half-size when in orthographic mode.
        public float FOV; // FieldOfView - The field of view of the camera in degrees.
        public float NCP; // NearClipPlane - The distance of the near clipping plane from the the Camera, in world units.
        public float FCP; // FarClipPlane - The distance of the far clipping plane from the Camera, in world units.
        public bool PhyCmr; // UsePhysicalProperties - Enable [UsePhysicalProperties] to use physical camera properties to compute the field of view and the frustum.

        public SCmrPrj(bool og, float ogSz, float fOV, float nCP, float fCP, bool phyCmr) {
            Og = og;
            OgSz =  og ? ogSz : float.NaN;
            FOV = fOV;
            NCP = nCP;
            FCP = fCP;
            PhyCmr = phyCmr;
        }
    }
}