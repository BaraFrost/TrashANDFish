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

        private float _speed;

        public Action<CollectibleItem> onCompleted;

        private float _minYPosition;

        /* [SerializeField]
         private float _pushingForce;
         public float PushingForce => _pushingForce;*/

        [SerializeField]
        private float _itemRadius;

        [SerializeField]
        private Size _size;
        public Size Size => _size;

        private Rigidbody _rigidbody;

        private float _startZPosition;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(float minYPosition, float startZPosition) {
            _minYPosition = minYPosition;
            _startZPosition = startZPosition;
        }

        /*  private void OnCollisionEnter(Collision collision) {
              if (collision.gameObject.TryGetComponent<CollectibleItem>(out var collisionItem)) {
                  _rigidbody.AddForce((-collisionItem.gameObject.transform.position + gameObject.transform.position).normalized * collisionItem.PushingForce, ForceMode.Impulse);
              }
          }*/

        private void OnEnable() {
            _speed = UnityEngine.Random.Range(_speedRange.x, _speedRange.y);
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
            Complete();
        }

        private void Complete() {
            onCompleted?.Invoke(this);
        }
    }
}

