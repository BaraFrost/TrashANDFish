using Data;
using UnityEngine;
using UnityToolbarExtender;

namespace UnityEditor {

    public static class ToolbarStyles {

        public static readonly GUIStyle commandButtonStyle;

        static ToolbarStyles() {
            commandButtonStyle = new GUIStyle("Command") {
                fontSize = 16,
                alignment = TextAnchor.MiddleCenter,
                imagePosition = ImagePosition.ImageAbove,
                fontStyle = FontStyle.Bold
            };
        }
    }

    public static class EditorSceneLoader {

        [InitializeOnLoad]
        public class LaunchParamsPlayButtons {

            private static ScenesContainer _scenesContainer;

            static LaunchParamsPlayButtons() {
                ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
                _scenesContainer = AssetDatabase.LoadAssetAtPath<ScenesContainer>("Assets/Resources/ScenesContainer.asset");
            }

            static void OnToolbarGUI() {
                GUILayout.FlexibleSpace();
                ButtonsGUI();
            }

            private static void ButtonsGUI() {
                if (EditorApplication.isPlaying || EditorApplication.isPaused ||
                    EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode) {
                    return;
                }

                LoadSceneButtonGUI("G", _scenesContainer.GameScene);
                LoadSceneButtonGUI("M", _scenesContainer.MenuScene);
                LoadSceneButtonGUI("S", _scenesContainer.ShopScene);
            }

            private static void LoadSceneButtonGUI(string name, ScenesContainer.SceneContainer scene) {
                if (GUILayout.Button(new GUIContent(name, $"Load {scene.SceneName}"), ToolbarStyles.commandButtonStyle)) {
                    scene.EditorOpenScene();
                }
            }

        }
    }
}

