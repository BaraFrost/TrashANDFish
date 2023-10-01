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

        [SerializeField]
        private GameScreenSettings _gameScreenSettings;

        private Vector3 _screenEdgePosition;
        public Vector3 ScreenEdgePosition => _screenEdgePosition;

        private void Awake() {
            _rightWall.transform.position = new Vector3(_gameScreenSettings.LowerRightPoint.x, 0, _gameScreenSettings.LowerRightPoint.z);
            _leftWall.transform.position = new Vector3(_gameScreenSettings.UpperLeftPoint.x, 0, _gameScreenSettings.UpperLeftPoint.z);
            _topWall.transform.position = new Vector3(0, _gameScreenSettings.UpperLeftPoint.y, _gameScreenSettings.UpperLeftPoint.z);
            _lowerWall.transform.position = new Vector3(0, _gameScreenSettings.LowerRightPoint.y, _gameScreenSettings.UpperLeftPoint.z);
        }
    }
}

