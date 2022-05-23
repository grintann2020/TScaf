namespace T {

    public struct SCmrPrjc {

        public bool Orthgrph; // orthographic - Is the camera orthographic (true) or perspective (false)?
        public float Sz;  // orthographicSize - Camera's half-size when in orthographic mode.
        // public float FOV; // fieldOfView - The field of view of the camera in degrees.
        // public bool PhyCam; // usePhysicalProperties - Enable [UsePhysicalProperties] to use physical camera properties to compute the field of view and the frustum.
        public float Nr; // nearClipPlane - The distance of the near clipping plane from the the Camera, in world units.
        public float Fr; // farClipPlane - The distance of the far clipping plane from the Camera, in world units.
        // public bool FOVAxis; // FieldOfViewAxis

        // public SCmrPrjc(bool op, float opSize, float fov, bool phyCam, float near, float far /*, bool fovAxis */) {
        public SCmrPrjc(bool orthgrph, float sz, float nr, float fr) {
            Orthgrph = orthgrph;
            Sz =  orthgrph ? sz : float.NaN;
            Nr = nr;
            Fr = fr;
        }
    }
}