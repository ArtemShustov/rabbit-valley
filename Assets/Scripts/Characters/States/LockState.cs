namespace Game.Characters.States {
	public class LockState: CharacterState {
		private ICharacterState _last;

		public void Lock() {
			if (Machine.Current is LockState) {
				return;
			}
			_last = Machine.Current;
			Machine.ChangeState(this);
		}
		public void Release() {
			if (_last != null) {
				Machine.ChangeState(_last);
				_last = null;
			}
		}
	}
}