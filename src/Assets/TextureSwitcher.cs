using UnityEngine;
using System.Collections;

public class TextureSwitcher : MonoBehaviour
{
    private static float minTransition = 1f;
    private static float maxTransition = 3f;
    private float currentTime = 0;

    public Texture[] textures;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > Random.Range(minTransition, maxTransition))
        {
            currentTime = 0;
            renderer.material.SetTexture("_MainTex", textures[Random.Range(0, textures.Length)]);
        }
    }
}