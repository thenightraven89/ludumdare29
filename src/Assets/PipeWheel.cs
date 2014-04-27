using UnityEngine;
using System.Collections;

public class PipeWheel : MonoBehaviour
{
    bool used = false;

    // Use this for initialization
    void Start()
    {

    }
    
    void OnTriggerStay(Collider other)
    {
        if (!used)
        {
            if (FPSControl.instance.isInteracting)
            {
                used = true;
                FPSControl.instance.GrowPlant();
                LeanTween.rotateLocal(gameObject, Vector3.forward * 270, 2f);
            }
        }
    }
}