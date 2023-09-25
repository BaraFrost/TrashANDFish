using UnityEngine;

namespace Game {

    [RequireComponent(typeof(PlayerMoveController))]
    public class AbstractInputController : MonoBehaviour {

        protected PlayerMoveController _playerMoveController;

        private void Start() {
            _playerMoveController = GetComponent<PlayerMoveController>();
        }

        private void Update() {
            TrackInput();
        }

        protected virtual void TrackInput() { }
    }
}

