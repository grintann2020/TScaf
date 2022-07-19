using UnityEngine;

namespace T {

    public interface IDt { // data interface

        DtMng Mng { set; } // set data manager
        bool IsApp { get; } // return is applied or not
        void App(); // apply
        void Cs(); // cease
        void PrpUpd(); // prop update
        void Rct(byte eRct, object vl); // react
        void Act(byte eAct); // act
        void Opr(byte eOpr); // operate
        void Abs(byte eOpr); // abstain
        void St<T>(byte eVl, T vl);
        T Gt<T>(byte eVl);
        void StTf(byte eTf, Transform vl);
        Transform GtTf(byte eTf);
        void StStr(byte eStr, string vl);
        string GtStr(byte eStr);
        void StFlt(byte eFlt, float vl);
        float GtFlt(byte eFlt);
        void StInt(byte eInt, int vl);
        int GtInt(byte eInt);
        void StBln(byte eBln, bool vl);
        bool GtBln(byte eBln);
    }
}