using System.Collections.Generic;

namespace Game.Rabbits.AI {
	public class GoalSelector {
		private List<IGoal> _goals = new List<IGoal>();

		private IGoal _current;
		private int _currentPriotiry;

		public void Add(IGoal goal) {
			_goals.Add(goal);
		}
		public void Remove(IGoal goal) {
			_goals.Remove(goal);
		}

		public void Update() {
			if (_current != null && _current.IsRunning() == false) {
				_current.Stop();
				_current = null;
			}
			var priority = 0;
			foreach (var goal in _goals) {
				if (goal.CanStart() && (_current == null || priority < _currentPriotiry)) {
					_current?.Stop();
					_current = goal;
					_currentPriotiry = priority;
					_current.Start();
					break;
				}
				priority++;
			}
			_current?.Update();
		}
	}
}