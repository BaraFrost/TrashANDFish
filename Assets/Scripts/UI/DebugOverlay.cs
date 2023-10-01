using UnityEngine;
using UnityEngine.UI;

public class DebugOverlay : MonoBehaviour
{
    [SerializeField]
    private Button _changeFPSButton;

    [SerializeField]
    private Text _fpsText;

    private bool _fpsChanged = false;

    public float updateInterval = 0.5f;

    float accum = 0.0f;
    int frames = 0;
    float timeleft;
    float fps;

    void Start()
    {
        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            fps = (accum / frames);
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
            _fpsText.text = fps.ToString();
        }
    }

    private void OnEnable()
    {
        _changeFPSButton.onClick.AddListener(ChangeFPS);
    }

    private void OnDisable()
    {
        _changeFPSButton.onClick.RemoveListener(ChangeFPS);
    }

    private void ChangeFPS()
    {
        if (_fpsChanged)
        {
            Application.targetFrameRate = 30;
        }
        else
        {
            Application.targetFrameRate = 60;
        }
        _fpsChanged = !_fpsChanged;
    }

}
