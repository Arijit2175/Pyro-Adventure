using UnityEngine;

public class LanternGlow : MonoBehaviour
{
    public Renderer lanternRenderer;
    public Light sun;

    public int lightMaterialIndex = 1;
    public Color emissionColor = Color.white;
    public float emissionIntensity = 2f;

    private Material lightMat;

    void Start()
    {
        lightMat = lanternRenderer.materials[lightMaterialIndex];
    }

    void Update()
    {
        if (sun.transform.eulerAngles.x > 180f)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    void TurnOn()
    {
        lightMat.EnableKeyword("_EMISSION");
        lightMat.SetColor("_EmissionColor", emissionColor * emissionIntensity);
    }

    void TurnOff()
    {
        lightMat.SetColor("_EmissionColor", Color.black);
    }
}