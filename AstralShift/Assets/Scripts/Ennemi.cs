using UnityEngine;

public class Ennemi : MonoBehaviour
{
    [SerializeField] private float vitesse = 10f;
    [SerializeField] private float porteeDetection = 5f;
    [SerializeField] private float porteeDegats = 1.2f;
    [SerializeField] private float degats = 1f;
    [SerializeField] private float vie = 3f;
    [SerializeField] private float tempEntreDegats = 1f;
    [SerializeField] private float forceKnockback = 5f;
    [SerializeField] private float dureeKnockback = 0.2f;

    private bool estKnockback = false;
    private float timerKnockback = 0f;
    private Transform joueur;
    private float timerDegats = 0f;
    private Rigidbody2D body;
    private SpriteRenderer sr;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        joueur = GameObject.FindWithTag("Player").transform;

        Physics2D.IgnoreCollision(
            GetComponent<Collider2D>(),
            joueur.GetComponent<Collider2D>()
        );
    }

    private void Update()
    {
        if (estKnockback)
        {
            timerKnockback -= Time.deltaTime;
            if (timerKnockback <= 0f)
                estKnockback = false;
            return;
        }

        if (joueur == null) return;

        float distance = Vector2.Distance(transform.position, joueur.position);
        timerDegats -= Time.deltaTime;

        if (distance < porteeDetection)
        {
            float directionX = (joueur.position.x - transform.position.x);
            directionX = Mathf.Clamp(directionX, -1f, 1f);

            body.linearVelocity = new Vector2(directionX * vitesse, body.linearVelocity.y);
            sr.flipX = directionX > 0;

            if (distance < porteeDegats && timerDegats <= 0f)
            {
                AttaquerJoueur();
                timerDegats = tempEntreDegats;
            }
        }
        else
        {
            body.linearVelocity = new Vector2(0, body.linearVelocity.y);
        }
    }

    public void PrendreDegats(float montant)
    {
        vie -= montant;
        Debug.Log("Ennemi touché ! Vie restante : " + vie);

        float direction = (transform.position.x - joueur.position.x);
        direction = direction > 0 ? 1f : -1f;
        body.linearVelocity = new Vector2(direction * forceKnockback, forceKnockback * 0.5f);
        estKnockback = true;
        timerKnockback = dureeKnockback;

        if (vie <= 0f)
            Mourir();
    }

    private void AttaquerJoueur()
    {
        VieJoueur vj = joueur.GetComponent<VieJoueur>();
        if (vj != null) vj.PrendreDegats(degats);
    }

    private void Mourir()
    {
        Debug.Log("Ennemi mort !");
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, porteeDetection);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, porteeDegats);
    }
}