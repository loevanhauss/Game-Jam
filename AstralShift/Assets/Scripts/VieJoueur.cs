using UnityEngine;

public class VieJoueur : MonoBehaviour
{
    [SerializeField] private float vieMax = 5f;
    [SerializeField] private UIVie uiVie;
    private float vie;
    private Animator anim;

    private void Awake()
    {
        vie = vieMax;
        anim = GetComponent<Animator>();
        uiVie.MettreAJour(vie, vieMax);
    }

    public void PrendreDegats(float montant)
    {
        vie -= montant;
        anim.SetBool("estBlessé", true);
        Invoke("ResetBlessé", 0.5f);
        uiVie.MettreAJour(vie, vieMax);

        if (vie <= 0f)
            Mourir();
    }

    private void ResetBlessé()
    {
        anim.SetBool("estBlessé", false);
    }

    private void Mourir()
    {
        anim.SetBool("estMort", true);
        Invoke("RechargerScene", 1f);
    }

    private void RechargerScene()
    {
        transform.position = CheckpointManager.instance.GetCheckpoint();
        vie = vieMax;
        anim.SetBool("estMort", false);
        FindFirstObjectByType<JaugeAstrale>()?.DesactiverAstral();
        FindFirstObjectByType<UIVie>()?.MettreAJour(vie, vieMax);
    }
    public void Soigner(float montant)
    {
        vie = Mathf.Clamp(vie + montant, 0, vieMax);
        uiVie.MettreAJour(vie, vieMax);
        Debug.Log("Soigné ! Vie : " + vie + "/" + vieMax);
    }
}