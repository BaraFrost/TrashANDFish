using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class CollectibleItem : MonoBehaviour {

        [SerializeField]
        private int _score;

        [SerializeField]
        private float _healthModifier; 

        public int GetScore() {
            return _score;
        }

        public float GetHealthModifier() {
            return _healthModifier;
        }

        public void Collect() {

        }
    }
}

