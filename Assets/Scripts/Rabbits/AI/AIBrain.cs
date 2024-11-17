using UnityEngine;

namespace Game.Rabbits.AI {
	public class AIBrain: MonoBehaviour {
		private GoalSelector _goalSelector = new GoalSelector();

		protected void Update() {
			_goalSelector.Update();
		}
		public void AddGoal(IGoal goal) {
			_goalSelector.Add(goal);
		}
	}
}