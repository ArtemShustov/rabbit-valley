using UnityEngine;

namespace Game {
	public class FPSLimit: MonoBehaviour {
		private void Awake() {
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 60;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)] 
		private static void OnLoad() {
			var instance = new GameObject("FPSLimit", typeof(FPSLimit));
			DontDestroyOnLoad(instance);
		}
	}
}