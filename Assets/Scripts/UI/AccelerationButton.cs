using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI {

    public class AccelerationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

        [SerializeField]
        private Image _filledImage;

        public float ButtonPercentage {
            get { return _filledImage.fillAmount; }
            set {
                if (value < 0) {
                    _filledImage.fillAmount = 0;
                } else if (value > 1) {
                    _filledImage.fillAmount = 1;
                } else {
                    _filledImage.fillAmount = value;
                }
            }
        }

        private bool _isPressed = false;
        public bool IsPressed => _isPressed;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _isPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.Space)) {
                _isPressed = false;
            }

        }

        public void OnPointerDown(PointerEventData eventData) {
            _isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData) {
            _isPressed = false;
        }
    }
}

