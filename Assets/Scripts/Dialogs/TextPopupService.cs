using Game.Services;
using UnityEngine;

namespace Game.Dialogs {
	[CreateAssetMenu(menuName = "GameServices/TextPopup")]
	public class TextPopupService: GameService {
		[SerializeField] private float _lifeTime = 5;
		[SerializeField] private DialogueView _prefab;

		public override void Init(GameServices gameServices) { }

		public DialogueView Spawn(Vector2 position, string text) {
			return Spawn(position, text, _lifeTime);
		}
		public DialogueView Spawn(Vector2 position, string text, float lifeTime) {
			var instance = Instantiate(_prefab);
			instance.transform.position = position;
			instance.SetTextAnimated(text, () => {
				instance.DestoryAfter(_lifeTime);
			});
			return instance;
		}
	}
}