using UnityEngine;

namespace Game {

    public class MouseInputController : AbstractInputController {

        [SerializeField]
        private float _mouseInputDeadZoneRadius;

        protected override void TrackInput() {
            base.TrackInput();
            Vector3 resultVector;
            var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                  Camera.main.WorldToScreenPoint(gameObject.transform.position).z));
            var input = mousePosition - transform.position;
            input.z = 0;
            if (input.magnitude <= _mouseInputDeadZoneRadius) {
                resultVector = Vector3.zero;
            } else {
                resultVector = input.normalized;
            }
            _playerMoveController.SetMoveVector(resultVector);
        }
    }
}

