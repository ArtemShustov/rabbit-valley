using System;
using UnityEngine;

namespace Game.Characters {
	public interface IInteractable {
		bool CanInteractWith(GameObject interactor);
		void Interact(GameObject interactor, Action completedCallback = null);
	}
}