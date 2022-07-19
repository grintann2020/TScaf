namespace T {

    public interface ITxt {

        TxtMng Mng { set; } // set manager
        string[][] StrArr2 { get; } // get the array of strings
        bool IsApp { get;} // get is applied or not
        void App(); // apply
        void Cnc(); // cancel
    }
}