using Data;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pause;

    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private Button _resumeButton;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _menuButton;

    [SerializeField]
    private ScenesContainer _scenes;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(ActivatePause);
        _resumeButton.onClick.AddListener(DeactivatePause);
        _restartButton.onClick.AddListener(Restart);
        _menuButton.onClick.AddListener(OpenMenuScene);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(ActivatePause);
        _resumeButton.onClick.RemoveListener(DeactivatePause);
        _restartButton.onClick.RemoveListener(Restart);
        _menuButton.onClick.RemoveListener(OpenMenuScene);
    }

    private void ActivatePause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
    }

    private void DeactivatePause()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Restart()
    {
        Time.timeScale = 1f;
        _scenes.GameScene.LoadScene();
    }

    private void OpenMenuScene()
    {
        Time.timeScale = 1f;
        _scenes.MenuScene.LoadScene();
    }
}
