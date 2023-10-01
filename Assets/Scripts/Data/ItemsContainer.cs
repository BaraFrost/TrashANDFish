using Game;
using System;
using UnityEngine;

namespace Data {

    [Serializable]
    public class ItemSpawnData
    {
        [SerializeField]
        private CollectibleItem _item;
        public CollectibleItem ItemPrefab => _item;

        [SerializeField]
        private float _spawnWeight;
        public float SpawnWeight => _spawnWeight;

        [SerializeField]
        private int _maxItemsAtOnce;
        public int MaxItemsAtOnce => _maxItemsAtOnce;
    }

    [CreateAssetMenu(fileName = "ItemsContainer",menuName = "SO/ItemsContainer")]
    public class ItemsContainer : ScriptableObject {

        [SerializeField]
        private ItemSpawnData[] _items;
        public ItemSpawnData[] Items => _items;
    }
}
