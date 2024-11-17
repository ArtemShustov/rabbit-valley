using Game.Characters.States;
using Game.Rabbits;
using UnityEngine;

namespace Game.Characters {
	public class ObjectIneractor: MonoBehaviour {
		[SerializeField] private CharacterStateMachine _machine;
		[SerializeField] private CarrotWallet _wallet;

		public void OnTriggerStay2D(Collider2D collision) {
			if (_machine.Current is IdleState && collision.gameObject.TryGetComponent<IInteractable>(out var interactable)) {
				if (interactable.CanInteractWith(gameObject)) {
					StartInteract(interactable);
				}
			}
		}

		private void StartInteract(IInteractable interactable) {
			_machine.GetState<LockState>().Lock();
			interactable.Interact(gameObject, completedCallback: OnCompleted);
		}
		private void OnCompleted() {
			_machine.GetState<LockState>().Release();
		}
	}
}