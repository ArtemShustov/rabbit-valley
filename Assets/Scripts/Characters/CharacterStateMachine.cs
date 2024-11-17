using Game.Logging;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Characters {
	public class CharacterStateMachine: MonoBehaviour {
		[field: SerializeField] public CharacterInput Input { get; private set; }
		[field: SerializeField] public Animator Animator { get; private set; }
		[field: SerializeField] public CharacterModel Model { get; private set; }
		[SerializeField] private GameLogger _logger;

		private Dictionary<Type, ICharacterState> _states = new Dictionary<Type, ICharacterState>();

		private ICharacterState _current;

		public ICharacterState Current => _current;

		private void Awake() {
			InitLocalStates();
		}
		private void InitLocalStates() {
			var states = GetComponents<ICharacterState>();
			foreach (var state in states) {
				AddState(state);
			}
		}

		private void Update() {
			_current?.OnUpdate(Time.deltaTime);
		}
		private void FixedUpdate() {
			_current?.OnFixedUpdate(Time.fixedDeltaTime);
		}

		public void AddState<T>(T state) where T: ICharacterState {
			var type = state.GetType();
			if (_states.ContainsKey(type)) {
				return;
			}
			_states.Add(type, state);
			state.Init(this);
		}
		public T GetState<T>() where T: ICharacterState {
			return (T)_states[typeof(T)];
		}
		public bool TryGetState<T>(out T state) where T: ICharacterState {
			var result = _states.TryGetValue(typeof(T), out var iState);
			state = iState != null ? (T)iState : default;
			return result;
		}
		public void ChangeState(ICharacterState state) {
			_logger?.Log($"StateChanged: {_current?.GetType()} > {state.GetType()}");
			_current?.OnExit();
			_current = state;
			_current?.OnEnter();
		}
		public void ChangeState<T>() where T: ICharacterState {
			ChangeState(GetState<T>());
		}
	}
}