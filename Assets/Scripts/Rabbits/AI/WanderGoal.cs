using Game.Characters;
using UnityEngine;

namespace Game.Rabbits.AI {
	public class WanderGoal: GoPositionGoal {
		private float _maxDist = 10;
		
		public WanderGoal(float maxDist, Transform character, CharacterInput input) : base(character, input) {
			_maxDist = maxDist;
		}

		public override void Start() {
			var target = (Vector2)Character.position + Random.insideUnitCircle * _maxDist;
			SetTarget(target);
			base.Start();
		}
	}
}