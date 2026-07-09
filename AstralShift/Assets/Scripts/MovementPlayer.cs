using UnityEngine;

public class MovementPlayer : MonoBehaviour
{   
    [SerializeField] private JaugeAstrale jaugeAstrale;
    [SerializeField] private Transform pointSol;
    [SerializeField] private LayerMask layerSol;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private GameObject astralPrefab;
    
    private Rigidbody2D body;
    private bool isGrounded;
    private GameObject astralDouble;
    private bool astralActif = false;
    private float directionX = 1f;
    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(pointSol.position, 0.1f, layerSol);

        float horizontal = 0f;
        if (Input.GetKey(KeyCode.D)) { horizontal = 1f; directionX = 1f; }
        else if (Input.GetKey(KeyCode.A)) { horizontal = -1f; directionX = -1f; }

        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);

        // Retourne le sprite
        sr.flipX = directionX < 0;

        // Anime le joueur
        anim.SetFloat("vitesse", Mathf.Abs(horizontal));
        anim.SetBool("isGrounded", isGrounded);

        // Invoquer / rappeler le double astral
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!astralActif)
            {
                astralDouble = Instantiate(astralPrefab, transform.position, Quaternion.identity);

                Physics2D.IgnoreCollision(
                    GetComponent<Collider2D>(),
                    astralDouble.GetComponent<Collider2D>()
                );

                GameObject[] ennemis = GameObject.FindGameObjectsWithTag("Ennemi");
                foreach (GameObject ennemi in ennemis)
                {
                    Physics2D.IgnoreCollision(
                        astralDouble.GetComponent<Collider2D>(),
                        ennemi.GetComponent<Collider2D>()
                    );
                }
                astralActif = true;
                if (jaugeAstrale != null) jaugeAstrale.ActiverAstral();
            }
            else
            {
                RappelerDouble();
            }
        }
    }


    public void RappelerDouble()
    {
        if (astralDouble != null) Destroy(astralDouble);
        astralActif = false;
        if (jaugeAstrale != null) jaugeAstrale.DesactiverAstral();
    }
}