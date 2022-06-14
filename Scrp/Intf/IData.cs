using UnityEngine;

namespace T {

    public interface IData { // data interface

        DataMngr Mngr { set; } // set data manager
        bool IsAppl { get; } // return is applied or not
        void Appl(); // apply
        void Cs(); // cease
        void PrpUpdt(); // prop update
        void Ract(byte eRact, object vl); // react
        void Act(byte eAct); // act
        void Oprt(byte eOprt); // operate
        void Abst(byte eOprt); // abstain
        void St<T>(byte eVl, T vl);
        T Gt<T>(byte eVl);
        void StTrnsfrm(byte eTrnsfrm, Transform vl);
        Transform GtTrnsfrm(byte eTrnsfrm);
        void StStrn(byte eStrn, string vl);
        string GtStrn(byte eStrn);
        void StFlt(byte eFlt, float vl);
        float GtFlt(byte eFlt);
        void StInt(byte eInt, int vl);
        int GtInt(byte eInt);
        void StBln(byte eBln, bool vl);
        bool GtBln(byte eBln);
    }
}