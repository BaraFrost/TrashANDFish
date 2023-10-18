using System;
using UI;
using UnityEngine;

namespace Game {

    public class PlayerAcceleration : MonoBehaviour {

        [SerializeField]
        private AccelerationButton _accelerationButton;

        [SerializeField]
        private float _recoveryStep;

        [SerializeField]
        private float _reductionStep;

        private float _accelerationAmount;

        [SerializeField]
        private float _maxAccelertaionAmount;

        private float AccelerationAmount {
            get { return _accelerationAmount; }
            set {
                if (value < 0) {
                    _accelerationAmount = 0;
                } else if (value > _maxAccelertaionAmount) {
                    _accelerationAmount = _maxAccelertaionAmount;
                } else {
                    _accelerationAmount = value;
                }
            }
        }

        public bool Accelerated => AccelerationAmount > 0 && _accelerationButton.IsPressed;

        private bool _wasAcceleratedOnPreviousFrame;

        public Action onAcceleratedChanged;

        private void Start() {
            AccelerationAmount = _maxAccelertaionAmount;
        }

        private void Update() {
            if (_accelerationButton.IsPressed) {
                AccelerationAmount -= _reductionStep * Time.deltaTime;
            } else {
                AccelerationAmount += _recoveryStep * Time.deltaTime;
            }
            _accelerationButton.ButtonPercentage = AccelerationAmount / _maxAccelertaionAmount;
            if(_wasAcceleratedOnPreviousFrame != Accelerated) {
                onAcceleratedChanged?.Invoke();
            }
            _wasAcceleratedOnPreviousFrame = Accelerated;
        }
    }

}
