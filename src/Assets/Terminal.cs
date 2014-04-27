using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour
{
    public string textid;

    public bool inUse = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character") && !inUse)
        {
            inUse = true;
            NarrationManager.instance.Narrate(this, textid);
        }
    }
}