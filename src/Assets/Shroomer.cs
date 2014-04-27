using UnityEngine;
using System.Collections;

public class Shroomer : MonoBehaviour
{
    public GameObject[] shrooms;

    private const float shroomMinScale = 0.5f;
    private const float shroomMaxScale = 1f;

    void Start()
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();

        for (int i = 0; i < transforms.Length; i++)
        {
            if (!transforms[i].CompareTag("Important"))
            {
                GameObject newObject = Instantiate(shrooms[Random.Range(0, shrooms.Length)], transforms[i].position + transforms[i].localScale.y / 2f * Vector3.up, Quaternion.identity) as GameObject;
                newObject.transform.localScale = Random.Range(shroomMinScale, shroomMaxScale) * Vector3.one;
                newObject.transform.parent = transforms[i];
            }
        }
    }
}
