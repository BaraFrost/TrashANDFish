using Data;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button _shopButton;
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _settingsButton;

    [SerializeField]
    private ScenesContainer _scenesContainer;

    private void OnEnable()
    {
        _shopButton.onClick.AddListener(OpenShopScene);
        _playButton.onClick.AddListener(OpenPlayScene);
      //  _settingsButton.onClick.AddListener(OpenSettingsScene);
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(OpenShopScene);
        _playButton.onClick.RemoveListener(OpenPlayScene);
      //  _settingsButton.onClick.RemoveListener(OpenSettingsScene);
    }

    private void OpenShopScene()
    {
        _scenesContainer.ShopScene.LoadScene();
    }

    private void OpenPlayScene()
    {
        _scenesContainer.GameScene.LoadScene();
    }
}
