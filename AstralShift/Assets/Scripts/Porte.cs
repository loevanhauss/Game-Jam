using UnityEngine;

public class Porte : MonoBehaviour
{
    private Color couleurOriginale;
    [SerializeField] private bool ouverteDépart = false;

    private void Start()
    {
        if (ouverteDépart)
            Ouvrir();
    }
    private void Awake()
    {
        couleurOriginale = GetComponent<SpriteRenderer>().color;
    }

    public void Ouvrir()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
    }

    public void Fermer()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = couleurOriginale;
    }
}