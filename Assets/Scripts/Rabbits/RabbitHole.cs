using Game.Dialogs;
using Game.Services;
using UnityEngine;

namespace Game.Rabbits {
	public class RabbitHole: MonoBehaviour {
		[SerializeField] private Vector2 _textOffset;
		private TextPopupService _service;

		private void Awake() {
			_service = GameServices.GetService<TextPopupService>();
		}
	}
}