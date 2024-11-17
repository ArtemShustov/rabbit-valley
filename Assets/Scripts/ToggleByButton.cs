using UnityEngine;
using UnityEngine.InputSystem;

namespace Game {
	public class ToggleByButton: MonoBehaviour {
		[SerializeField] private float _clickTime = 0.5f;
		[SerializeField] private InputAction _button;
		[SerializeField] private GameObject _root;

		private bool _isTemp;

		private void Awake() {
			_root.SetActive(false);
		}

		private void SetTemp() => _isTemp = true;

		private void OnButtonPerformed(InputAction.CallbackContext context) {
			if (_root.activeSelf) {
				_root.SetActive(false);
				return;
			}
			_root.SetActive(true);
			Invoke(nameof(SetTemp), _clickTime);
		}
		private void OnButtonCanceled(InputAction.CallbackContext context) {
			if (_isTemp) {
				_isTemp = false;
				_root.SetActive(false);
			} else {
				CancelInvoke(nameof(SetTemp));
			}
		}

		private void OnEnable() {
			_button.Enable();
			_button.performed += OnButtonPerformed;
			_button.canceled += OnButtonCanceled;
		}
		private void OnDisable() {
			_button.performed -= OnButtonPerformed;
			_button.canceled -= OnButtonCanceled;
			_button.Disable();
		}
	}
}
