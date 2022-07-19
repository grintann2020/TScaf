namespace T {

    public interface IIa { // interface of interaction

        IaMng Mng { set; } // set interaction manager
        bool IsInstl { get; } // return is installed or not
        void Instl(); // install;
        void Unnst(); // uninstall;
        void PrpUpd(); // prop update
        void Prmp(byte eEvn); // prompt
        void Dssd(byte eEvn); // dissuade
    }
}
