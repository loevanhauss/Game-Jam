using UnityEngine;

public class Attaque : MonoBehaviour
{
    [SerializeField] private float degats = 1f;
    [SerializeField] private float portee = 0.5f;
    [SerializeField] private Transform pointAttaque;
    [SerializeField] private LayerMask layerEnnemi;
    [SerializeField] private KeyCode toucheAttaque;
    private Animator anim;
    private HitboxVisu visu;
    private SpriteRenderer sr;
    private float directionX = 1f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        visu = pointAttaque.GetComponent<HitboxVisu>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Suit la direction du sprite
        if (sr != null)
            directionX = sr.flipX ? -1f : 1f;

        // Met à jour la position du point d'attaque
        if (pointAttaque != null)
        {
            Vector3 pos = pointAttaque.localPosition;
            pos.x = Mathf.Abs(pos.x) * directionX;
            pointAttaque.localPosition = pos;
        }

        if (Input.GetKeyDown(toucheAttaque))
            Frapper();
    }

    private void Frapper()
    {
        if (anim != null) anim.SetTrigger("attaque");
        if (visu != null) visu.AfficherHitbox();

        Collider2D[] ennemis = Physics2D.OverlapCircleAll(pointAttaque.position, portee, layerEnnemi);

        foreach (Collider2D ennemi in ennemis)
        {
            Debug.Log("Touché : " + ennemi.name);
            ennemi.GetComponent<Ennemi>().PrendreDegats(degats);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (pointAttaque == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pointAttaque.position, portee);
    }
}