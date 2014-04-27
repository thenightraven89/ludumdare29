using UnityEngine;
using System.Collections;

public class LevelDoor : MonoBehaviour
{
    bool used = false;

    public GameObject door1;
    public GameObject door2;

    void OnTriggerEnter(Collider other)
    {
        LeanTween.moveLocalZ(door1, 1.5f, 0.2f);
        LeanTween.moveLocalZ(door2, -1.5f, 0.2f);
    }

    void OnTriggerExit(Collider other)
    {
        LeanTween.moveLocalX(door1, 0f, 0.2f);
        LeanTween.moveLocalX(door2, 0f, 0.2f);
    }

    void OnTriggerStay(Collider other)
    {
        if (!used)
        {
            if (FPSControl.instance.isInteracting)
            {
                used = true;
                Debug.Log("Finished");
            }
        }
    }
}