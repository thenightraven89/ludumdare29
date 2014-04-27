using UnityEngine;
using System.Collections;

public class Shroomer : MonoBehaviour
{
    public GameObject[] shrooms;

    void Start()
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();

        for (int i = 0; i < transforms.Length; i++)
        {
            if (!transforms[i].CompareTag("Important"))
            {
                GameObject newObject = Instantiate(shrooms[Random.Range(0, shrooms.Length)], transforms[i].position + transforms[i].localScale.y / 2f * Vector3.up, Quaternion.identity) as GameObject;
                newObject.transform.parent = transforms[i];
            }
        }
    }
}
