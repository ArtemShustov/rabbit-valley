using Game.Characters;
using Game.Rabbits.AI;
using UnityEngine;

namespace Game.Rabbits {
	public class RabbitAI: AIBrain {
		[SerializeField] private float _maxWanderDist = 5;
		[SerializeField] private CharacterStateMachine _machine;

		private void Awake() {
			AddGoal(new WanderGoal(_maxWanderDist, transform, _machine.Input));
		}
	}
}