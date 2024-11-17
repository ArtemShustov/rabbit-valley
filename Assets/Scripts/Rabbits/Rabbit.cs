using Game.Characters;
using UnityEngine;

namespace Game.Rabbits {
	public class Rabbit: Character {
		[field: SerializeField] public CarrotWallet Carrots { get; private set; }
	}
}