using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game {

    public class FishHealth : MonoBehaviour {

        [Serializable]
        private class FishSize {

            [SerializeField]
            public Size size;
            [SerializeField]
            public float scale;
        }

        [SerializeField]
        private FishSize[] _fishSizes;

        [SerializeField]
        private float _startHealth;

        [SerializeField]
        private float _maxHealth;

        [SerializeField]
        private float _minHealth;

        private float _currentHealth;

        [SerializeField]
        private Slider _healthBar;

        [SerializeField]
        private float _descentRate;

        private Dictionary<Size, float> _sizes = new Dictionary<Size, float>();

        public float CurrentHealth {
            get { return _currentHealth; }
            set {
                if (value < 0) {
                    _currentHealth = 0;
                } else if (value > _maxHealth) {
                    _currentHealth = _maxHealth;
                } else {
                    _currentHealth = value;
                }
            }
        }

        private void Awake() {
            CurrentHealth = _startHealth;
            foreach (var fishSize in _fishSizes) {
                _sizes.Add(fishSize.size, fishSize.scale);
            }
        }

        public Size GetCurrentSize() {
            if (CurrentHealth > _maxHealth * 0.7f) {
                return Size.Big;
            }

            if (CurrentHealth > _maxHealth * 0.3f) {
                return Size.Normall;
            }

            return Size.Small;
        }

        public void Update() {
            if (CurrentHealth > 0) {
                CurrentHealth -= _descentRate * Time.deltaTime;
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            gameObject.transform.localScale = GetSizeVector();
            /*
            var currentSize = GetCurrentSize();
            if (_sizes[currentSize] != gameObject.transform.localScale.x) {
                gameObject.transform.localScale = new Vector3(_sizes[currentSize], _sizes[currentSize], _sizes[currentSize]);
            }*/
            _healthBar.value = CurrentHealth / _maxHealth;
        }

        private Vector3 GetSizeVector() {
            var size = (_sizes[Size.Big] - _sizes[Size.Small]) * CurrentHealth / _maxHealth + _sizes[Size.Small];
            return new Vector3(size, size, size);
        }

        public void ChangeHealth(float healthModifer) {
            if (CurrentHealth > _minHealth && CurrentHealth + healthModifer < _minHealth) {
                CurrentHealth = _minHealth;
                return;
            }
            CurrentHealth += healthModifer;
        }
    }
}
