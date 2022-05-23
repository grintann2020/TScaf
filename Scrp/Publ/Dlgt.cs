namespace T {
    public delegate T DRtrn<T>(T arg); // return delegate
    public delegate (T0, T1) DRtrn<T0, T1>(T0 arg0, T1 arg1);
    public delegate (T0, T1, T2) DRtrn<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2);
    public delegate R DFnct<out R>();  // function delegate
    public delegate R DFnct<in T, out R>(T arg);
    public delegate R DFnct<in T0, in T1, out R>(T0 arg0, T1 arg1);
    public delegate R DFnct<in T0, in T1, in T2, out R>(T0 arg0, T1 arg1, T2 arg2);
    public delegate void DActn(); // action delegate
    public delegate void DActn<T>(T arg);
    public delegate void DActn<T0, T1>(T0 arg0, T1 arg1);
    public delegate void DActn<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2);
    public delegate void DActns<T>(T[] arr);
    public delegate void DActns<T0, T1>(T0[] arr0, T1[] arr1);
    public delegate void DActns<T0, T1, T2>(T0[] arr0, T1[] arr1, T2[] arr2);
}