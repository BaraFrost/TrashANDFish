using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Scene shopScene;
    public Scene sampleScene;
    // Метод для загрузки сцены магазина
    public void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene"); // Замените "ShopScene" на имя вашей сцены магазина
    }

    // Метод для продолжения игры
    public void ContinueGame()
    {
        // В этом методе вы можете добавить код для продолжения игры, например, сохранение/загрузку состояния игры
        // После завершения необходимых действий загрузите сцену игры
        SceneManager.LoadScene("SampleScane"); // Замените "GameScene" на имя вашей сцены игры
    }

    // Метод для перезапуска игры
    public void ReloadGame()
    {
        SceneManager.LoadScene("SampleScene"); // Замените "GameScene" на имя вашей сцены игры
    }
}
