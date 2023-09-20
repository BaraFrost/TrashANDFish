using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button _shopButton;
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _settingsButton;

    private void OnEnable()
    {
        _shopButton.onClick.AddListener(OpenShopScene);
        _playButton.onClick.AddListener(OpenPlayScene);
        _settingsButton.onClick.AddListener(OpenSettingsScene);
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(OpenShopScene);
        _playButton.onClick.RemoveListener(OpenPlayScene);
        _settingsButton.onClick.RemoveListener(OpenSettingsScene);
    }

    private void OpenShopScene()
    {
        SceneManager.LoadScene(2);
    }
    private void OpenPlayScene()
    {
        SceneManager.LoadScene(1);
    }
    private void OpenSettingsScene()
    {
        SceneManager.LoadScene(3);
    }
}
