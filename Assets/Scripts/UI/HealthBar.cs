using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

namespace UI {

    public class HealthBar : MonoBehaviour {

        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private Image[] _imagesToColor;

        [SerializeField]
        private Image _numberImage;

        [Serializable]
        private class SizeHealthBarVisual {
            public Size size;
            public Color backColor;
            public Sprite numberImage;
        }

        [SerializeField]
        private SizeHealthBarVisual[] _healthBarVisuals;

        private Dictionary<Size, SizeHealthBarVisual> _cashedHealthBarVisuals;
        private Dictionary<Size, SizeHealthBarVisual> CashedHealthBarVisuals {
            get {
                if (_cashedHealthBarVisuals == null) {
                    _cashedHealthBarVisuals = new Dictionary<Size, SizeHealthBarVisual>();
                    foreach (var visual in _healthBarVisuals) {
                        _cashedHealthBarVisuals.Add(visual.size, visual);
                    }
                }
                return _cashedHealthBarVisuals;
            }
        }

        public void SetValue(float value) {
            _slider.value = value;
        }

        public void ChangeSize(Size size) {
            if (!CashedHealthBarVisuals.ContainsKey(size)) {
                return;
            }
            var visual = CashedHealthBarVisuals[size];
            if (visual == null) {
                return;
            }
            foreach (var image in _imagesToColor) {
                image.color = visual.backColor;
            }
            _numberImage.sprite = visual.numberImage;
        }

    }
}

