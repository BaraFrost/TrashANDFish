using UnityEngine;

namespace Game {

    public class DestroyEffect : MonoBehaviour {

        [SerializeField]
        private float _timeToDestroy;

        void Start() {
            Destroy(gameObject, _timeToDestroy);
        }
    }
}
