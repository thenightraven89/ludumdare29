using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    public GameObject plant;
    public ParticleSystem water;

    public void GrowPlant()
    {
        LeanTween.scale(plant, Vector3.one * 7.9f, 3f, new object[] { "ease", LeanTweenType.easeInOutQuad });
        water.emissionRate = 100;
        StartCoroutine(TurnOffWater());
    }

    private IEnumerator TurnOffWater()
    {
        yield return new WaitForSeconds(5f);
        water.emissionRate = 0;
    }
}