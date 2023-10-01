using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data {

    [CreateAssetMenu(fileName = "ScenesContainer", menuName = "SO/ScenesContainer")]
    public class ScenesContainer : ScriptableObject {

        [Serializable]
        public class SceneContainer {

            [SerializeField]
            private string _scenePath;
            public string SceneName => Path.GetFileNameWithoutExtension(_scenePath);

            public void LoadScene() {
                SceneManager.LoadScene(SceneName);
            }

#if UNITY_EDITOR
            public void EditorOpenScene() {
                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                EditorSceneManager.OpenScene(_scenePath);
            }
#endif
        }

        [SerializeField]
        private SceneContainer _gameScene;
        public SceneContainer GameScene => _gameScene;

        [SerializeField]
        private SceneContainer _menuScene;
        public SceneContainer MenuScene => _menuScene;

        [SerializeField]
        private SceneContainer _shopScene;
        public SceneContainer ShopScene => _shopScene;

    }
}

