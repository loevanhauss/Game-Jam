using UnityEngine;
using TMPro;

public class ZoneTuto : MonoBehaviour
{
    [SerializeField] private GameObject texteTuto;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            texteTuto.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            texteTuto.SetActive(false);
    }
}