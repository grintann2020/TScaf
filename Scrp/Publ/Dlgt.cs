namespace T {
    public delegate R DFnct<out R>();  // function delegate
    public delegate R DFnct<in T, out R>(T arg);
    public delegate R DFnct<in T0, in T1, out R>(T0 arg0, T1 arg1);
    public delegate R DFnct<in T0, in T1, in T2, out R>(T0 arg0, T1 arg1, T2 arg2);
    public delegate void DActn(); // action delegate
    public delegate void DActn<T>(T arg);
    public delegate void DActn<T0, T1>(T0 arg0, T1 arg1);
    public delegate void DActn<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2);
}