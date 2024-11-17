namespace Game.Characters {
	public interface ICharacterState {
		void Init(CharacterStateMachine machine);

		void OnUpdate(float deltaTime);
		void OnFixedUpdate(float deltaTime);
		void OnEnter();
		void OnExit();
	}
}