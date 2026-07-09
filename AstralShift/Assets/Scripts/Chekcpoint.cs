using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool actif = false;
    [SerializeField] private Sprite spriteInactif;
    [SerializeField] private Sprite spriteActif;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Objet entré : " + other.gameObject.name + " tag : " + other.gameObject.tag);
        
        if (other.CompareTag("Player") && !actif)
        {
            actif = true;
            sr.sprite = spriteActif;
            CheckpointManager.instance.SetCheckpoint(transform.position);
            Debug.Log("Checkpoint activé !");
        }
    }
}