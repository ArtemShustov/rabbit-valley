using DG.Tweening;
using Game.Characters;
using System;
using UnityEngine;

namespace Game.Rabbits {
	public class CarrotFarm: MonoBehaviour, IInteractable {
		[SerializeField] private int _value;
		[SerializeField] private float _animationHeight = 1;
		[SerializeField] private Transform[] _carrots;

		public int Value => _value;

		public bool CanInteractWith(GameObject interactor) {
			return _value > 0 && interactor.TryGetComponent<CarrotWallet>(out var _);
		}
		public void Interact(GameObject interactor, Action completedCallback = null) {
			var sequence = DOTween.Sequence();
			foreach (var carrot in _carrots) {
				sequence.Append(carrot.DOLocalMoveY(_animationHeight, 1));
				sequence.AppendCallback(() => carrot.gameObject.SetActive(false));
			}
			sequence.OnComplete(() => {
				if (interactor.TryGetComponent<CarrotWallet>(out var wallet)) {
					wallet.Add(_value);
					_value = 0;
				}
				completedCallback?.Invoke();
			});
			sequence.Play();
		}
		public void ResetCarrots() {
			foreach (var carrot in _carrots) {
				carrot.localPosition = Vector3.zero;
				carrot.gameObject.SetActive(true);
			}
		}
	}
}