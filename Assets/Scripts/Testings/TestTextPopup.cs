using Game.Dialogs;
using Game.Services;
using UnityEngine;

namespace Game.Testings {
	public class TestTextPopup: MonoBehaviour {
		private void Update() {
			if (Input.GetKeyDown(KeyCode.C)) {
				GameServices.GetService<TextPopupService>().Spawn(transform.position + Vector3.up / 2, "Test service text");
			}
		}
	}
}