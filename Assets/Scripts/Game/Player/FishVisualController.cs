using System.Collections;
using UnityEngine;

namespace Game {

    public class FishVisualController : MonoBehaviour {

        [SerializeField]
        private ParticleSystem _accelerationParticleSystem;

        [SerializeField]
        private ParticleSystem _eatParticleSystem;

        [SerializeField]
        private float _timeToPlayEatEffets;

        private PlayerAcceleration _palyerAcceleration;

        private FishItemsCollector _itemsCollector;

        private void Awake() {
            _palyerAcceleration = GetComponent<PlayerAcceleration>();
            _itemsCollector = GetComponent<FishItemsCollector>();
        }

        private void OnEnable() {
            if (_palyerAcceleration != null) {
                _palyerAcceleration.onAcceleratedChanged += ShowAccelerationEffects;
            }
            if (_itemsCollector != null) {
                _itemsCollector.onCollect += PlayCollectEffects;
            }
        }

        private void OnDisable() {
            if (_palyerAcceleration != null) {
                _palyerAcceleration.onAcceleratedChanged -= ShowAccelerationEffects;
            }
            if (_itemsCollector != null) {
                _itemsCollector.onCollect -= PlayCollectEffects;
            }
        }

        private void ShowAccelerationEffects() {
            if (_accelerationParticleSystem == null || _palyerAcceleration == null) {
                return;
            }
            if (_palyerAcceleration.Accelerated) {
                _accelerationParticleSystem.Play();
            } else {
                _accelerationParticleSystem.Stop();
            }
        }

        public void PlayCollectEffects(CollectibleItem collectibleItem) {
            var particleModule = _eatParticleSystem.main;
            particleModule.startColor = new ParticleSystem.MinMaxGradient(collectibleItem.PrimaryColors.firstColor, collectibleItem.PrimaryColors.secondColor);
            StartCoroutine(PlayCollectEffectsCoroutine());
        }

        public IEnumerator PlayCollectEffectsCoroutine() {
            _eatParticleSystem.Play();
            yield return new WaitForSeconds(_timeToPlayEatEffets);
            _eatParticleSystem.Stop();
        }
    }
}
