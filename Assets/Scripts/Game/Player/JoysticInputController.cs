using UnityEngine;

namespace Game {

    public class JoysticInputController : AbstractInputController {

        [SerializeField]
        private VariableJoystick _joystick;

        [SerializeField]
        private AnimationCurve _joysticSpeedCurve;

        protected override void TrackInput() {
            base.TrackInput();
            float moveX = _joystick.Horizontal;
            float moveY = _joystick.Vertical;
            _playerMoveController.SetMoveVector(EvaluateJoysticVector(new Vector3(moveX, moveY, 0)));
        }

        private Vector3 EvaluateJoysticVector(Vector3 value) {
            return _joysticSpeedCurve.Evaluate(value.magnitude) * value;
        }

        private void OnEnable() {
            if (_joystick != null) {
                _joystick.gameObject.SetActive(true);
            }
        }

        private void OnDisable() {
            if (_joystick != null) {
                _joystick.gameObject.SetActive(false);
            }
        }
    }
}
