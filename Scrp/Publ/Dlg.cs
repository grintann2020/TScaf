namespace T {
    public delegate R DFnc<out R>();  // function delegate
    public delegate R DMth<in T, out R>(T arg); // method delegate
    public delegate R DMth<in T0, in T1, out R>(T0 arg0, T1 arg1);
    public delegate R DMth<in T0, in T1, in T2, out R>(T0 arg0, T1 arg1, T2 arg2);
    public delegate void DAct(); // action delegate
    public delegate void DRct<T>(T arg); // reaction delegate
    public delegate void DRct<T0, T1>(T0 arg0, T1 arg1);
    public delegate void DRct<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2);
}