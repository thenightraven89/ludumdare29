using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public FPSControl control;

    private bool levelFinished = false;

    public GameObject menu;

    public MeshRenderer curtain;

    void Awake()
    {
        Application.targetFrameRate = 60;
        curtain.material.SetColor("_TintColor", new Color(0f, 0f, 0f, 0f));
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            control.enabled = true;
            menu.SetActive(false);
        }

        if (!levelFinished)
        {
            if (control.isSafe)
            {
                levelFinished = true;
                LeanTween.value(gameObject, "HandleCurtain", 0f, 1f, 1f);
                NarrationManager.instance.Narrate(null, "end");
            }
        }
    }

    private void HandleCurtain(float value)
    {
        curtain.material.SetColor("_TintColor", new Color(0f, 0f, 0f, value));
    }
}