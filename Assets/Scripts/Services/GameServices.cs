using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Services {
	public class GameServices: MonoBehaviour {
		private Dictionary<Type, IGameService> _services = new Dictionary<Type, IGameService>();

		public T Get<T>() {
			return (T)_services[typeof(T)];
		}
		public static T GetService<T>() => _instance.Get<T>();

		public void Add(IGameService service) {
			var type = service.GetType();
			if (_services.ContainsKey(type) == false) {
				_services.Add(type, service);
				service.Init(this);
			}
		}

		#region Init
		private static GameServices _instance;
		public static GameServices GetInstance() => _instance;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad() {
			_instance = new GameObject(nameof(GameServices), typeof(GameServices)).GetComponent<GameServices>();
			_instance.LoadFromResources();
			DontDestroyOnLoad(_instance);
		}

		private void LoadFromResources() {
			var files = Resources.LoadAll<GameService>("Services");
			foreach (var file in files) {
				Add(file);
			}
		}
		#endregion
	}
}