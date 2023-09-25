using UnityEngine;

namespace Game {

    public class WallExtender : MonoBehaviour {

        [SerializeField]
        private GameObject _rightWall;
        [SerializeField]
        private GameObject _leftWall;
        [SerializeField]
        private GameObject _topWall;
        [SerializeField]
        private GameObject _lowerWall;

        private Vector3 _screenEdgePosition;
        public Vector3 ScreenEdgePosition => _screenEdgePosition;

        private void Awake() {
            var screenEdgePosition = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight,
                Camera.main.WorldToScreenPoint(_rightWall.transform.position).z));
            _rightWall.transform.position = new Vector3(screenEdgePosition.x, 0, _rightWall.transform.position.z);
            _leftWall.transform.position = new Vector3(-screenEdgePosition.x, 0, _leftWall.transform.position.z);
            _topWall.transform.position = new Vector3(0, screenEdgePosition.y, _topWall.transform.position.z);
            _lowerWall.transform.position = new Vector3(0, -screenEdgePosition.y, _lowerWall.transform.position.z);
        }
    }
}

