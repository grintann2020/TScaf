using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

namespace T {

    public static class Rsrc {

        public static void Load<T>(string ky, DActn<T> dLoad = null) {
            Addressables.LoadAssetAsync<T>(ky).Completed += (AsyncOperationHandle<T> hndl) => {
                dLoad?.Invoke(hndl.Result);
            };
        }

        public static async void Load<T>(string[] kyArry, DActn<T[]> dLoad = null) {
            T[] tArry = new T[kyArry.Length];
            Task[] tskArry = new Task[kyArry.Length];
            AsyncOperationHandle<T>[] hndlArry = new AsyncOperationHandle<T>[kyArry.Length];
            for (byte k = 0; k < kyArry.Length; k++) {
                hndlArry[k] = Addressables.LoadAssetAsync<T>(kyArry[k]);
                tskArry[k] = hndlArry[k].Task;
            }
            await Task.WhenAll(tskArry);
            for (byte k = 0; k < kyArry.Length; k++) {
                tArry[k] = hndlArry[k].Result;
            }
            dLoad?.Invoke(tArry);
        }

        public static void Inst(string ky, Transform prnt = null, DActn<GameObject> dInst = null) { // Addressables.InstantiateAsync will clone asset directlty
            Addressables.InstantiateAsync(ky, prnt).Completed += (AsyncOperationHandle<GameObject> hndl) => {
                dInst?.Invoke(hndl.Result);
            };
        }

        public static void Inst(string ky, Vector3 pstn, Quaternion rtt, Transform prnt = null, DActn<GameObject> dInst = null) { // Addressables.InstantiateAsync will clone asset directlty
            Addressables.InstantiateAsync(ky, pstn, rtt, prnt).Completed += (AsyncOperationHandle<GameObject> hndl) => {
                dInst?.Invoke(hndl.Result);
            };
        }

        public static async void Inst(string[] kyArry,  Transform prnt = null, DActn<GameObject[]> dInst = null) { // Addressables.InstantiateAsync will clone asset directlty
            GameObject[] gmObjcArry = new GameObject[kyArry.Length];
            Task[] tskArry = new Task[kyArry.Length];
            AsyncOperationHandle<GameObject>[] hndlArry = new AsyncOperationHandle<GameObject>[kyArry.Length];
            for (byte k = 0; k < kyArry.Length; k++) {
                hndlArry[k] = Addressables.InstantiateAsync(kyArry[k], prnt);
                tskArry[k] = hndlArry[k].Task;
            }
            await Task.WhenAll(tskArry);
            for (byte k = 0; k < kyArry.Length; k++) {
                gmObjcArry[k] = hndlArry[k].Result;
            }
            dInst?.Invoke(gmObjcArry);
        }

        public static async void Inst(SInst[] sIntArry, Transform prnt = null, DActn<GameObject[]> dInst = null) {
            GameObject[] gmObjcArry = new GameObject[sIntArry.Length];
            Task[] tskArry = new Task[sIntArry.Length];
            AsyncOperationHandle<GameObject>[] hndlArry = new AsyncOperationHandle<GameObject>[sIntArry.Length];
            for (byte k = 0; k < sIntArry.Length; k++) {
                hndlArry[k] = Addressables.InstantiateAsync(sIntArry[k].Ky, sIntArry[k].Pstn, sIntArry[k].Rttn, prnt);
                tskArry[k] = hndlArry[k].Task;
            }
            await Task.WhenAll(tskArry);
            for (byte k = 0; k < sIntArry.Length; k++) {
                gmObjcArry[k] = hndlArry[k].Result;
            }
            dInst?.Invoke(gmObjcArry);
        }

        public static void Rls<T>(T t, DActn dRls = null) {
            Addressables.Release<T>(t);
            dRls?.Invoke();
        }

        public static void Rls<T>(T[] tArry, DActn dRls = null) {
            for (ushort o = 0; o < tArry.Length; o++) {
                Addressables.Release<T>(tArry[o]);
            }
            dRls?.Invoke();
        }
    }
}