using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Game.Dialogs {
	[ExecuteInEditMode]
	public class DialogueView: MonoBehaviour {
		[SerializeField] private RectTransform _containter;
		[SerializeField] private TMP_Text _label;

		private void Update() {
			if (_containter != null) {
				_containter.localPosition = new Vector2(0, _containter.rect.height / 2f);
			}
		}

		public void SetText(string text) {
			_label.text = text;
		}
		public void SetTextAnimated(string text, Action completedCallback = null) {
			StartCoroutine(TextAnimation(text, completedCallback));
		}
		public void DestroySelf() {
			Destroy(gameObject);
		}
		public void DestoryAfter(float time) {
			Invoke(nameof(DestroySelf), time);
		}

		private IEnumerator TextAnimation(string text, Action callback) {
			_label.text = "";
			for (int i = 0; i < text.Length; i++) {
				_label.text += text[i];
				yield return new WaitForSeconds(0.05f);
			}
			callback?.Invoke();
		}

	}
}