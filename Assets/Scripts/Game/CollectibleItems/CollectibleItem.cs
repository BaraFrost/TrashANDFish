using System;
using UnityEngine;

namespace Game {

    public enum ItemType {
        Positive,
        Negative,
    }

    public enum Size {
        Small,
        Normall,
        Big,
    }

    [Serializable]
    public struct ColorPair {
        public Color firstColor;
        public Color secondColor;
    }

    public class CollectibleItem : MonoBehaviour {

        [SerializeField]
        private ItemType _type;
        public ItemType ItemType => _type;

        [SerializeField]
        private int _score;

        [SerializeField]
        private float _healthModifier;

        [SerializeField]
        private Vector2 _speedRange;

        [SerializeField]
        private DestroyEffect _destroyEffect;

        [SerializeField]
        private ColorPair _primaryColors;
        public ColorPair PrimaryColors => _primaryColors;

        private float _speed;

        public Action<CollectibleItem> onCompleted;

        private float _minYPosition;

        [SerializeField]
        private float _itemRadius;

        [SerializeField]
        private Size _size;
        public Size Size => _size;

        private Rigidbody _rigidbody;

        private float _startZPosition;

        private float _speedModifer;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public virtual void Init(float minYPosition, float startZPosition, float speedModifer) {
            _minYPosition = minYPosition;
            _startZPosition = startZPosition;
            _speedModifer = speedModifer;
            _speed = UnityEngine.Random.Range(_speedRange.x, _speedRange.y) * _speedModifer;
        }

        private void FixedUpdate() {
            Move();
        }

        private void Update() {
            if (gameObject.transform.position.y < _minYPosition - _itemRadius) {
                Complete();
            }
        }

        private void Move() {
            _rigidbody.AddForce(Vector3.down * _speed, ForceMode.Acceleration);
            _rigidbody.position.Set(_rigidbody.position.x, _rigidbody.position.y, _startZPosition);
        }

        public int GetScore() {
            return _score;
        }

        public float GetHealthModifier() {
            return _healthModifier;
        }

        public virtual void Collect() {
            showDestroyEffect();
            Complete();
        }

        private void showDestroyEffect() {
            if (_destroyEffect != null) {
                Instantiate(_destroyEffect, transform.position, Quaternion.identity);
            }
        }

        protected void Complete() {
            onCompleted?.Invoke(this);
        }
    }
}

