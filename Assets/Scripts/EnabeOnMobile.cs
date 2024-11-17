using UnityEngine;

namespace Game {
	public class EnabeOnMobile: MonoBehaviour {
		[SerializeField] private bool _enableInEditor = false;
		[SerializeField] private GameObject _root;

		private void Awake() {
			_root.SetActive(Application.isMobilePlatform || (_enableInEditor && Application.isEditor));
		}
		private void OnValidate() {
			if (Application.isPlaying) {
				_root.SetActive(_enableInEditor && Application.isEditor);
			}
		}
	}
}