using UnityEngine;
using UnityEngine.UI;

public class UIVie : MonoBehaviour
{
    [SerializeField] private Image[] coeurs;
    [SerializeField] private Sprite coeurPlein;
    [SerializeField] private Sprite coeurVide;

    public void MettreAJour(float vieActuelle, float vieMax)
    {
        for (int i = 0; i < coeurs.Length; i++)
        {
            if (i < vieActuelle)
                coeurs[i].sprite = coeurPlein;
            else
                coeurs[i].sprite = coeurVide;
        }
    }
}