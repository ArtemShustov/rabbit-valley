using UnityEngine;

namespace Game.Characters {
	public class CharacterModel: MonoBehaviour {
		[SerializeField] private Transform _root;
		[SerializeField] private SpriteRenderer _sprite;

		public void FlipHorizontal() {
			var scale = _root.localScale;
			scale.z *= -1;
			_root.localScale = scale;
			_sprite.flipX  = !_sprite.flipX;
		}
		public float GetDirection() {
			return _root.localScale.z;
		}
	}
}