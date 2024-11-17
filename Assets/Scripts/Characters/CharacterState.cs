using UnityEngine;

namespace Game.Characters {
	public abstract class CharacterState: MonoBehaviour, ICharacterState {
		public CharacterStateMachine Machine { get; private set; }
		
		public virtual void Init(CharacterStateMachine machine) {
			Machine = machine;
		}

		public virtual void OnUpdate(float deltaTime) { }
		public virtual void OnFixedUpdate(float deltaTime) { }
		public virtual void OnEnter() { }
		public virtual void OnExit() { }
	}
}