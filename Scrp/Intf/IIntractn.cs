namespace T {

    public interface IIntractn { // interface of interaction

        IntractnMngr Mngr { set; } // set interaction manager
        bool IsInstl { get; } // return is installed or not
        void Instl(); // install;
        void Uninstl(); // uninstall;
        void PrpUpdt(); // prop update
        void Prmp(byte eEvnt); // prompt
        void Dssd(byte eEvnt); // dissuade
    }
}
