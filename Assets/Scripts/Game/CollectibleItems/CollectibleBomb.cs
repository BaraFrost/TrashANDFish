using System.Collections;
using UnityEngine;

namespace Game {

    public class CollectibleBomb : CollectibleItem {

        [SerializeField]
        private Vector2 _randomTimeToDestroy;
        [SerializeField]
        private MeshRenderer _bigBomb;
        [SerializeField]
        private Color _destroyColor;
        [SerializeField]
        private DestroyEffect _explodableEffect;

        [SerializeField]
        private  float _startTimeBetweenFlash;

        [SerializeField]
        private AnimationCurve _flashCurve;

        private float _timeToDestroy;

        private IEnumerator _coroutine;

        private Color _defaultColor;

        public override void Init(float minYPosition, float startZPosition, float speedModifer) {
            base.Init(minYPosition, startZPosition, speedModifer);
            _timeToDestroy = Random.Range(_randomTimeToDestroy.x, _randomTimeToDestroy.y);
            _coroutine = FlashingBombCoroutine();
            StartCoroutine(_coroutine);
        }

        private IEnumerator FlashingBombCoroutine() {
            var timeSum = 0f;
            while (true) {
                var currentTimeBetweenFlash = _startTimeBetweenFlash * _flashCurve.Evaluate(timeSum / _timeToDestroy);
                timeSum += currentTimeBetweenFlash;
                yield return new WaitForSeconds(currentTimeBetweenFlash);
                _bigBomb.enabled = true;
                currentTimeBetweenFlash = _startTimeBetweenFlash * _flashCurve.Evaluate(timeSum / _timeToDestroy);
                timeSum += currentTimeBetweenFlash;
                yield return new WaitForSeconds(currentTimeBetweenFlash);
                _bigBomb.enabled = false;
                if (timeSum >= _timeToDestroy) {
                    Explode();
                }
            }
        }

        private void Explode() {
            if (_explodableEffect != null) {
                Instantiate(_explodableEffect, transform.position, Quaternion.identity);
            }
            Complete();
        }

        private void OnDisable() {
            _bigBomb.enabled = false;
            if (_coroutine != null) {
                StopCoroutine(_coroutine);
            }
        }
    }
}

