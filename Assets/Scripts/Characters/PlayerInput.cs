using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Characters {
	public class PlayerInput: MonoBehaviour {
		[SerializeField] private CharacterInput _input;
		[SerializeField] private InputAction _move;
		private void Update() {
			_input.SetMove(_move.ReadValue<Vector2>());
		}

		private void OnEnable() {
			_move.Enable();
		}
		private void OnDisable() {
			_move.Disable();
		}
	}
}