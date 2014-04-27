using UnityEngine;
using System.Collections;

public class Shroom : MonoBehaviour
{
    public Color[] colors;
    private const float minPuffTime = 3f;
    private const float maxPuffTime = 12f;
    private float puffTime;
    private float initialScaleZ;

    // Use this for initialization
    void Start()
    {
        Color randomColor = colors[Random.Range(0, colors.Length)];
        renderer.material.SetColor("_Color", randomColor);
        particleSystem.startColor = randomColor;// .particleEmitter.renderer.material.SetColor("_TintColor", randomColor);

        puffTime = Random.Range(minPuffTime, maxPuffTime);
        initialScaleZ = transform.localScale.z;
    }
    
    // Update is called once per frame
    void Update()
    {
        puffTime -= Time.deltaTime;

        if (puffTime <= 0)
        {
            puffTime = Random.Range(minPuffTime, maxPuffTime);
            particleSystem.Emit(20);
            LeanTween.scaleZ(gameObject, initialScaleZ * 0.5f, 0.25f, new object[] { "ease", LeanTweenType.easeInQuad, "onComplete", "ScaleBack" });
        }
    }

    void ScaleBack()
    {
        LeanTween.scaleZ(gameObject, initialScaleZ, 0.25f, new object[] { "ease", LeanTweenType.easeOutQuad });
    }
}
