using System;
using UnityEngine;

namespace T {
    
    public class Mn : SngMB<Mn> {

        public string GmPrmNm;
        [SerializeField] private SttSO _sttngs;

        private void Awake() {
            GmMng.Ins.Int((IPrm)Activator.CreateInstance(Type.GetType(GmPrmNm)));
            GmMng.Ins.Stt(_sttngs);
        }

        private void Start() {
            GmMng.Ins.Str();
        }

        private void Update() {
            GmMng.Ins.PrpUpd();
        }
    }
}