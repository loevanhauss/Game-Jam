using UnityEngine;

public class Orbe : MonoBehaviour
{
    [SerializeField] private float soins = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            VieJoueur vj = other.GetComponent<VieJoueur>();
            if (vj != null)
            {
                vj.Soigner(soins);
                Destroy(gameObject);
            }
        }
    }
}