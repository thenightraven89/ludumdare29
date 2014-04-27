using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    public GameObject plant;

    public void GrowPlant()
    {
        LeanTween.scale(plant, Vector3.one * 7.9f, 3f, new object[] { "ease", LeanTweenType.easeInOutQuad });
    }
}