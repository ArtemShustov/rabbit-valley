using UnityEngine;

namespace Game.Characters.States {
	public class MoveState: CharacterState {
		[SerializeField] private float _speed;
		[SerializeField] private string _movingAnimationKey = "IsMoving";
		[SerializeField] private Rigidbody2D _rigidbody;

		private Vector2 _velocity;

		public override void OnUpdate(float deltaTime) {
			if (Machine.Input.Move.sqrMagnitude == 0) {
				Machine.ChangeState<IdleState>();
			}

			_velocity = Machine.Input.Move.normalized * _speed;

			if (_velocity.x != 0 && Mathf.Sign(_velocity.x) != Mathf.Sign(Machine.Model.GetDirection())) {
				Machine.Model.FlipHorizontal();
			}
		}
		public override void OnFixedUpdate(float deltaTime) {
			_rigidbody.MovePosition(_rigidbody.position + _velocity * deltaTime);
		}

		public override void OnEnter() {
			Machine.Animator.SetBool(_movingAnimationKey, true);
		}
		public override void OnExit() {
			Machine.Animator.SetBool(_movingAnimationKey, false);
		}
	}
}