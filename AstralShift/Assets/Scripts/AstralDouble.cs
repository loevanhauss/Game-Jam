using UnityEngine;

public class AstralDouble : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1f;

        if (Input.GetKey(KeyCode.UpArrow)) vertical = 1f;
        else if (Input.GetKey(KeyCode.DownArrow)) vertical = -1f;

        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(horizontal * speed, vertical * speed);

        // Idle quand immobile, Run quand il bouge
        anim.SetFloat("vitesse", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }
}