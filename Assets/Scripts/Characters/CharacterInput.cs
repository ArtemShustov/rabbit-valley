using UnityEngine;

namespace Game.Characters {
	public class CharacterInput: MonoBehaviour {
		public virtual Vector2 Move { get; private set; }

		public virtual void SetMove(Vector2 move) {
			Move = move;
		}
	}
}