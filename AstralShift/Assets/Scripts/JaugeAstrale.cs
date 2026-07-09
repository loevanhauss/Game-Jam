using UnityEngine;
using UnityEngine.UI;

public class JaugeAstrale : MonoBehaviour
{
    [SerializeField] private Image jaugeFill;
    [SerializeField] private float energieMax = 5f;
    [SerializeField] private float vitesseRegen = 1f;
    [SerializeField] private float vitesseDrain = 1f;

    private float energie;
    private bool enModeAstral = false;

    private void Awake()
    {
        energie = energieMax;
    }

    private void Update()
    {
        if (enModeAstral)
        {
            energie -= vitesseDrain * Time.deltaTime;
            energie = Mathf.Clamp(energie, 0, energieMax);

            if (energie <= 0f)
                RappelerDouble();
        }
        else
        {
            energie += vitesseRegen * Time.deltaTime;
            energie = Mathf.Clamp(energie, 0, energieMax);
        }

        jaugeFill.fillAmount = energie / energieMax;
    }

    public void ActiverAstral()
    {
        enModeAstral = true;
    }

    public void DesactiverAstral()
    {
        enModeAstral = false;
    }

    private void RappelerDouble()
    {
        enModeAstral = false;
        // Rappelle le double via le MovementPlayer
        FindFirstObjectByType<MovementPlayer>().RappelerDouble();
    }
}