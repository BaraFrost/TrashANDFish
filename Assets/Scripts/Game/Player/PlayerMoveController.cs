using UnityEngine;

namespace Game {

    public class PlayerMoveController : MonoBehaviour {

        private Rigidbody rb;
        public float speed = 0.5f;
        private Vector3 _moveVector;

        [SerializeField]
        private float _breakAcceleration;

        [SerializeField]
        private float _minVelocity;

        void Awake() {
            rb = GetComponent<Rigidbody>();
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
            rb.rotation = Quaternion.Euler(-180, 0, rotZ);
            rb.velocity = _moveVector * speed;
        }

        private void Break() {
            rb.velocity = new Vector3(CalculateFloatBreakVelocity(rb.velocity.x),
                CalculateFloatBreakVelocity(rb.velocity.y), 0);
        }

        private float CalculateFloatBreakVelocity(float value) {
            if (Mathf.Abs(value) <= _minVelocity) {
                return 0;
            }
            return value * _breakAcceleration;
        }
    }
}
