using UnityEngine;

public class HitboxVisu : MonoBehaviour
{
    [SerializeField] private float portee = 0.5f;
    [SerializeField] private float dureeAffichage = 0.1f;
    private float timer = 0f;
    private bool afficher = false;

    public void AfficherHitbox()
    {
        afficher = true;
        timer = dureeAffichage;
    }

    private void Update()
    {
        if (afficher)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
                afficher = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (afficher)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, portee);
        }
        else
        {
            Gizmos.color = new Color(1, 0, 0, 0.2f);
            Gizmos.DrawWireSphere(transform.position, portee);
        }
    }
}