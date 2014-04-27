using UnityEngine;
using System.Collections;

public class RandomTinting : MonoBehaviour
{
    public Color[] tints;

    // Use this for initialization
    void Start()
    {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.SetColor("_Color", tints[Random.Range(0, tints.Length)]);
            renderers[i].transform.localEulerAngles += Vector3.forward * 90 * Random.Range(0, 4);
        }
    }
}
