using UnityEngine;

namespace Game {

    [CreateAssetMenu(fileName = "GameScreenSettings", menuName = "SO/GameScreenSettings")]
    public class GameScreenSettings : ScriptableObject {

        private Vector3 _upperLeftPoint = Vector3.zero;
        public Vector3 UpperLeftPoint {
            get {
#if UNITY_EDITOR
                Clear();
#endif
                if (_upperLeftPoint == Vector3.zero) {
                    CalculatePoints();
                }
                return _upperLeftPoint;
            }
        }

        private Vector3 _lowerRightPoint = Vector3.zero;
        public Vector3 LowerRightPoint {
            get {
#if UNITY_EDITOR
                Clear();
#endif
                if (_lowerRightPoint == Vector3.zero) {
                    CalculatePoints();
                }
                return _lowerRightPoint;
            }
        }

        [SerializeField]
        private float _zPosition;

        private void CalculatePoints() {
            var screenEdgePosition = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight,
                Camera.main.WorldToScreenPoint(new Vector3(0, 0, _zPosition)).z));
            _upperLeftPoint = new Vector3(screenEdgePosition.x, screenEdgePosition.y, _zPosition);
            _lowerRightPoint = new Vector3(-screenEdgePosition.x, -screenEdgePosition.y, _zPosition);
        }

        private void Clear() {
            _upperLeftPoint = Vector3.zero;
            _lowerRightPoint = Vector3.zero;
        }

    }
}

