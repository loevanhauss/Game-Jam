using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject panelCredits;

    public void Jouer()
    {
        SceneManager.LoadScene("Intro"); // nom de ta scène d'intro
    }

    public void Quitter()
    {
        Application.Quit();
        Debug.Log("Quitter !"); // visible uniquement dans l'éditeur
    }

    public void OuvrirCredits()
    {
        panelCredits.SetActive(true);
    }

    public void FermerCredits()
    {
        panelCredits.SetActive(false);
    }
}