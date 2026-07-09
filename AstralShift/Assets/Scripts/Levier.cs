using UnityEngine;

public class Levier : MonoBehaviour
{
    [SerializeField] private GameObject[] portes;
    [SerializeField] private bool ouvertDeDepart = false;
    private bool estActive;
    private bool joueurAstralPresent = false;
    private SpriteRenderer sr;
    [SerializeField] private Sprite spriteOff;
    [SerializeField] private Sprite spriteOn;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        estActive = ouvertDeDepart;
        
        // Synchronise l'état visuel du levier
        sr.sprite = estActive ? spriteOn : spriteOff;

        // Synchronise l'état des portes
        foreach (GameObject porteObj in portes)
        {
            Porte porte = porteObj.GetComponent<Porte>();
            if (porte != null)
            {
                if (estActive) porte.Ouvrir();
                else porte.Fermer();
            }
        }
    }

    private void Update()
    {
        if (joueurAstralPresent && Input.GetKeyDown(KeyCode.F))
        {
            estActive = !estActive;
            sr.sprite = estActive ? spriteOn : spriteOff;

            foreach (GameObject porteObj in portes)
            {
                Porte porte = porteObj.GetComponent<Porte>();
                if (porte != null)
                {
                    if (estActive) porte.Ouvrir();
                    else porte.Fermer();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Astral"))
            joueurAstralPresent = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Astral"))
            joueurAstralPresent = false;
    }
}