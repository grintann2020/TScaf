using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

namespace T {

    public static class Rs {

        public static void Ld<T>(string ky, DRct<T> dLd = null) {
            Addressables.LoadAssetAsync<T>(ky).Completed += (AsyncOperationHandle<T> hnd) => {
                dLd?.Invoke(hnd.Result);
            };
        }

        public static async void Ld<T>(string[] kyArr, DRct<T[]> dLd = null) {
            T[] tArr = new T[kyArr.Length];
            Task[] tskArr = new Task[kyArr.Length];
            AsyncOperationHandle<T>[] hndArr = new AsyncOperationHandle<T>[kyArr.Length];
            for (byte k = 0; k < kyArr.Length; k++) {
                hndArr[k] = Addressables.LoadAssetAsync<T>(kyArr[k]);
                tskArr[k] = hndArr[k].Task;
            }
            await Task.WhenAll(tskArr);
            for (byte k = 0; k < kyArr.Length; k++) {
                tArr[k] = hndArr[k].Result;
            }
            dLd?.Invoke(tArr);
        }

        public static void Ins(string ky, Transform prnt = null, DRct<GameObject> dIns = null) { // Addressables.InsantiateAsync will clone asset directlty
            Addressables.InstantiateAsync(ky, prnt).Completed += (AsyncOperationHandle<GameObject> hnd) => {
                dIns?.Invoke(hnd.Result);
            };
        }

        public static void Ins(string ky, Vector3 pstn, Quaternion rtt, Transform prnt = null, DRct<GameObject> dIns = null) { // Addressables.InsantiateAsync will clone asset directlty
            Addressables.InstantiateAsync(ky, pstn, rtt, prnt).Completed += (AsyncOperationHandle<GameObject> hnd) => {
                dIns?.Invoke(hnd.Result);
            };
        }

        public static async void Ins(string[] kyArr,  Transform prnt = null, DRct<GameObject[]> dIns = null) { // Addressables.InsantiateAsync will clone asset directlty
            GameObject[] gOArr = new GameObject[kyArr.Length];
            Task[] tskArr = new Task[kyArr.Length];
            AsyncOperationHandle<GameObject>[] hndArr = new AsyncOperationHandle<GameObject>[kyArr.Length];
            for (byte k = 0; k < kyArr.Length; k++) {
                hndArr[k] = Addressables.InstantiateAsync(kyArr[k], prnt);
                tskArr[k] = hndArr[k].Task;
            }
            await Task.WhenAll(tskArr);
            for (byte k = 0; k < kyArr.Length; k++) {
                gOArr[k] = hndArr[k].Result;
            }
            dIns?.Invoke(gOArr);
        }

        public static async void Ins(SIns[] sIntArr, Transform prnt = null, DRct<GameObject[]> dIns = null) {
            GameObject[] gOArr = new GameObject[sIntArr.Length];
            Task[] tskArr = new Task[sIntArr.Length];
            AsyncOperationHandle<GameObject>[] hndArr = new AsyncOperationHandle<GameObject>[sIntArr.Length];
            for (byte k = 0; k < sIntArr.Length; k++) {
                hndArr[k] = Addressables.InstantiateAsync(sIntArr[k].Ky, sIntArr[k].Pst, sIntArr[k].Rtt, prnt);
                tskArr[k] = hndArr[k].Task;
            }
            await Task.WhenAll(tskArr);
            for (byte k = 0; k < sIntArr.Length; k++) {
                gOArr[k] = hndArr[k].Result;
            }
            dIns?.Invoke(gOArr);
        }

        public static void Rls<T>(T t, DAct dRls = null) {
            Addressables.Release<T>(t);
            dRls?.Invoke();
        }

        public static void Rls<T>(T[] tArr, DAct dRls = null) {
            for (ushort o = 0; o < tArr.Length; o++) {
                Addressables.Release<T>(tArr[o]);
            }
            dRls?.Invoke();
        }
    }
}