using UnityEngine;

namespace Game.Logging {
	[CreateAssetMenu(menuName = "Logger")]
	public class GameLogger: ScriptableObject {
		[SerializeField] private string _tag = "";
		[SerializeField] private bool _active = true;

		public void Log(object message) {
			if (_active) {
				Debug.Log($"[{_tag}] {message}");
			}
		}
	}
}