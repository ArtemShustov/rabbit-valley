namespace Game.Rabbits.AI {
	public interface IGoal {
		bool IsRunning();
		bool CanStart();

		void Start();
		void Update();
		void Stop();
	}
}