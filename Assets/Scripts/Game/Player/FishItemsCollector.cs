using System;
using UnityEngine;

namespace Game {

    public class FishItemsCollector : MonoBehaviour {

        [SerializeField]
        private FishHealth _health;

        [SerializeField]
        private FishScore _score;

        public Action onCollect;

        private void OnCollisionEnter(Collision collision) {
            if(collision.gameObject.TryGetComponent<CollectibleItem>(out var collectibleItem)) {
                CollectItem(collectibleItem);
            }
        }

        private void CollectItem(CollectibleItem collectibleItem) {
            if(_health.GetCurrentSize() < collectibleItem.Size) {
                return;
            }
            _health.ChangeHealth(collectibleItem.GetHealthModifier());
            collectibleItem.Collect();
            onCollect?.Invoke();
        }

    }
}
