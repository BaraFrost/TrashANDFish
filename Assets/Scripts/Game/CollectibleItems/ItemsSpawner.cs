using Data;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Game {

    public class ItemsSpawner : MonoBehaviour {

        [SerializeField]
        private ItemsContainer _itemsContainer;

        [SerializeField]
        private AnimationCurve _difficultyCurve;

        [SerializeField]
        private float _timeToMaxDifficulty;

        [SerializeField]
        private float _timeBetweenSpawn;

        [SerializeField]
        private Vector2 _spawnOffset;

        [SerializeField]
        private GameScreenSettings _screenSettings;

        [SerializeField]
        private float _currentTime;

        private CollectibleItemsPool _collectibleItemsPool;

        private float DifficultyModifer => _difficultyCurve.Evaluate(_currentTime / _timeToMaxDifficulty);

        private void Start() {
            _collectibleItemsPool = new CollectibleItemsPool(_itemsContainer.Items);
            StartCoroutine(ItemSpawnCoroutine());
        }

        private IEnumerator ItemSpawnCoroutine() {
            while (true) {
                SpawnItem();
                var currentTimeBetweenSpawn = _timeBetweenSpawn;
                yield return new WaitForSeconds(currentTimeBetweenSpawn);
                _currentTime += currentTimeBetweenSpawn;
            }
        }

        private void SpawnItem() {
            var item = _collectibleItemsPool.GetItem(DifficultyModifer);
            if (item == null) {
                return;
            }
            var positionToSpawn = Random.Range(_screenSettings.UpperLeftPoint.x + _spawnOffset.x, _screenSettings.LowerRightPoint.x - _spawnOffset.x);
            item.gameObject.transform.position = new Vector3(positionToSpawn, _screenSettings.UpperLeftPoint.y + _spawnOffset.y, _screenSettings.UpperLeftPoint.z);
            item.gameObject.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            item.Init(_screenSettings.LowerRightPoint.y - _spawnOffset.y, _screenSettings.UpperLeftPoint.z, DifficultyModifer > 0.5f ? DifficultyModifer / 0.5f : 1);
        }
    }
}

