using Game.Characters;
using System;
using UnityEngine;

namespace Game.Dialogs {
	public class TextTrigger: MonoBehaviour, IInteractable {
		[TextArea]
		[SerializeField] private string _text;
		[SerializeField] private float _keepAliveTime = 5;
		[SerializeField] private Transform _root;
		[SerializeField] private DialogueView _prefab;
		[SerializeField] private Vector2 _offset = Vector2.up;

		private DialogueView _view;

		private void Clear() {
			Destroy(_view.gameObject);
			_view = null;
		}

		public bool CanInteractWith(GameObject interactor) => _view == null;
		public void Interact(GameObject interactor, Action completedCallback = null) {
			_view = Instantiate(_prefab, _root);
			_view.transform.localPosition = _offset;
			_view.SetTextAnimated(_text, () => {
				Invoke(nameof(Clear), _keepAliveTime);
				completedCallback?.Invoke();
			});
		}
	}
}