using UnityEngine;

namespace Game {

    public class PlayerMoveController : MonoBehaviour {

        private Rigidbody _rigidbody;

        [SerializeField]
        private float _defaultSpeed = 0.5f;

        [SerializeField]
        private float _jerkSpeed = 0.5f;

        private float Speed {
            get {
                if (_playerAcceleration != null && _playerAcceleration.Accelerated) {
                    return _jerkSpeed;
                }
                return _defaultSpeed;
            }
        }

        private Vector3 _moveVector;

        [SerializeField]
        private float _breakAcceleration;

        [SerializeField]
        private float _minVelocity;

        private PlayerAcceleration _playerAcceleration;

        void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
            _playerAcceleration = GetComponent<PlayerAcceleration>();
        }

        private void FixedUpdate() {
            Move();
        }

        public void SetMoveVector(Vector3 moveVector) {
            _moveVector = moveVector;
        }

        private void Move() {
            if (_moveVector.magnitude == 0) {
                Break();
                return;
            }
            float rotZ = Mathf.Atan2(_moveVector.x, _moveVector.y) * Mathf.Rad2Deg;
            _rigidbody.rotation = Quaternion.Euler(-180, 0, rotZ);
            _rigidbody.velocity = _moveVector * Speed;
        }

        private void Break() {
            _rigidbody.velocity = new Vector3(CalculateFloatBreakVelocity(_rigidbody.velocity.x),
                CalculateFloatBreakVelocity(_rigidbody.velocity.y), 0);
        }

        private float CalculateFloatBreakVelocity(float value) {
            if (Mathf.Abs(value) <= _minVelocity) {
                return 0;
            }
            return value * _breakAcceleration;
        }
    }
}
