using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Scene shopScene;
    public Scene sampleScene;
    // ����� ��� �������� ����� ��������
    public void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene"); // �������� "ShopScene" �� ��� ����� ����� ��������
    }

    // ����� ��� ����������� ����
    public void ContinueGame()
    {
        // � ���� ������ �� ������ �������� ��� ��� ����������� ����, ��������, ����������/�������� ��������� ����
        // ����� ���������� ����������� �������� ��������� ����� ����
        SceneManager.LoadScene("SampleScane"); // �������� "GameScene" �� ��� ����� ����� ����
    }

    // ����� ��� ����������� ����
    public void ReloadGame()
    {
        SceneManager.LoadScene("SampleScene"); // �������� "GameScene" �� ��� ����� ����� ����
    }
}
