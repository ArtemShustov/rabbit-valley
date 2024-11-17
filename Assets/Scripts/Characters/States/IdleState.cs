using UnityEngine;

namespace Game.Characters.States {
	public class IdleState: CharacterState {
		[SerializeField] private bool _isDeault = true;

		public override void Init(CharacterStateMachine machine) {
			base.Init(machine);
			if (_isDeault) {
				Machine.ChangeState(this);
			}
		}

		public override void OnUpdate(float deltaTime) {
			if (Machine.Input.Move.sqrMagnitude > 0) {
				Machine.ChangeState<MoveState>();
			}
		}
		public override void OnEnter() { }
		public override void OnExit() { }
	}
}