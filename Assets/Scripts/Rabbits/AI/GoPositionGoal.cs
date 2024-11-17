using Game.Characters;
using UnityEngine;

namespace Game.Rabbits.AI {
	public class GoPositionGoal: IGoal {
		private CharacterInput _input;
		private Transform _character;
		private Vector2 _target;
		private bool _isRunning;

		public Transform Character => _character;

		public GoPositionGoal(Transform character, CharacterInput input) {
			_input = input;
			_character = character;
		}

		public void SetTarget(Vector2 target) {
			_target = target;
		}

		public virtual bool IsRunning() => _isRunning;
		public virtual bool CanStart() => !_isRunning;

		public virtual void Start() {
			_isRunning = true;
		}
		public virtual void Update() {
			if (_isRunning) {
				var direction = (_target - (Vector2)_character.position);
				_input.SetMove(Vector2.ClampMagnitude(direction, 1));

				if (Vector2.Distance(_character.position, _target) <= 0.5f) {
					_isRunning = false;
				}
			}
		}
		public virtual void Stop() {
			_input.SetMove(Vector2.zero);
			_isRunning = false;
		}
	}
}