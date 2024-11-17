using System;
using UnityEngine;

namespace Game.Rabbits {
	public class CarrotWallet: MonoBehaviour {
		[SerializeField] private int _value;

		public int Value => _value;

		public event Action Changed;

		public void Add(int count) {
			_value += count;
			Changed?.Invoke();
		}
		public bool CanTake(int count) => _value >= count;
		public bool TryTake(int count) {
			if (CanTake(count)) {
				_value -= count;
				Changed?.Invoke();
				return true;
			}
			return false;
		}
	}
}