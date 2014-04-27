using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    public GameObject plant;
    public GameObject waterCube;
    public ParticleSystem water;

    private Color ambientColor;
    private Color alertColor = Color.red;
    private Vector3 targetWaterLocation;
    
    void Awake()
    {
        ambientColor = RenderSettings.ambientLight;
        ambientVector = new Vector3(ambientColor.r, ambientColor.g, ambientColor.b);
        alertVector = new Vector3(alertColor.r, alertColor.g, alertColor.b);
        targetWaterLocation = waterCube.transform.position + Vector3.up * 100f;
    }

    private Vector3 ambientVector;
    private Vector3 alertVector;

    public void GrowPlant()
    {
        LeanTween.scale(plant, Vector3.one * 7.9f, 3f, new object[] { "ease", LeanTweenType.easeInOutQuad });
        water.emissionRate = 100;
        StartCoroutine(Alert());
    }

    private IEnumerator Alert()
    {
        yield return new WaitForSeconds(2f);

        LeanTween.move(waterCube, targetWaterLocation, 15f);

        while (true)
        {            
            LeanTween.value(gameObject, "AlertUpdate", ambientVector , alertVector, 1f, new Hashtable());
            yield return new WaitForSeconds(1f);
            LeanTween.value(gameObject, "AlertUpdate", alertVector, ambientVector, 1f, new Hashtable());
            yield return new WaitForSeconds(1f);
        }
    }

    private void AlertUpdate(Vector3 value)
    {
        RenderSettings.ambientLight = new Color(value.x, value.y, value.z);
    }
}