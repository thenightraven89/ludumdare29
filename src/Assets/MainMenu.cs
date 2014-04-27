using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public FPSControl control;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            control.enabled = true;
            gameObject.SetActive(false);
        }

    }
}