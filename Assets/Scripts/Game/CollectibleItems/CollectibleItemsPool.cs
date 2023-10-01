using Data;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class CollectibleItemsPool {

        public class IdenticalItemsPool {

            private ItemSpawnData _spawnData;

            private int _temporaryWeightLoss = 1;

            private List<CollectibleItem> _inactiveItems = new List<CollectibleItem>();
            private List<CollectibleItem> _activeItems = new List<CollectibleItem>();

            public IdenticalItemsPool(ItemSpawnData itemSpawnData) {
                _spawnData = itemSpawnData;
                for (int i = 0; i < itemSpawnData.MaxItemsAtOnce; i++) {
                    var item = Object.Instantiate(itemSpawnData.ItemPrefab);
                    item.gameObject.SetActive(false);
                    _inactiveItems.Add(item);
                }
            }

            public CollectibleItem GetFromPool() {
                if (_inactiveItems == null || _inactiveItems.Count == 0) {
                    return null;
                }
                var item = _inactiveItems[0];
                _activeItems.Add(item);
                item.onCompleted += ReleaseToPool;
                _inactiveItems.RemoveAt(0);
                item.gameObject.SetActive(true);
                _temporaryWeightLoss = 5;
                return item;
            }

            public void ReleaseToPool(CollectibleItem collectibleItem) {
                collectibleItem.gameObject.SetActive(false);
                collectibleItem.onCompleted -= ReleaseToPool;
                _inactiveItems.Add(collectibleItem);
                _activeItems.Remove(collectibleItem);
            }

            public float GetCurrentWeight(float difficultyModifier) {
                var modifier = (_spawnData.ItemPrefab.ItemType == ItemType.Positive ? 1 - difficultyModifier : difficultyModifier) * 2;
                return _spawnData.SpawnWeight * _inactiveItems.Count / _spawnData.MaxItemsAtOnce * modifier / _temporaryWeightLoss;
            }

            public void Update() {
                if (_temporaryWeightLoss > 1) {
                    _temporaryWeightLoss--;
                }
            }
        }

        private IdenticalItemsPool[] _itemsPools;

        public CollectibleItemsPool(ItemSpawnData[] itemSpawnDatas) {
            _itemsPools = new IdenticalItemsPool[itemSpawnDatas.Length];
            for (int i = 0; i < _itemsPools.Length; i++) {
                _itemsPools[i] = new IdenticalItemsPool(itemSpawnDatas[i]);
            }
        }

        public CollectibleItem GetItem(float difficultyLevel) {
            float weightSum = 0;
            foreach (var item in _itemsPools) {
                weightSum += item.GetCurrentWeight(difficultyLevel);
                item.Update();
            }
            if (weightSum == 0) {
                return null;
            }
            var randomWeigt = Random.Range(0, weightSum);

            weightSum = 0;
            foreach (var item in _itemsPools) {
                if (randomWeigt <= weightSum + item.GetCurrentWeight(difficultyLevel)) {
                    return item.GetFromPool();
                }
                weightSum += item.GetCurrentWeight(difficultyLevel);
            }
            return null;
        }
    }
}

