using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform joueur;
    [SerializeField] private float vitesseSuivi = 5f;
    private Transform cible;

    private void Awake()
    {
        cible = joueur;
    }

    private void Update()
    {
        // Bascule la cible avec C
        if (Input.GetKeyDown(KeyCode.C))
        {
            AstralDouble double_ = FindFirstObjectByType<AstralDouble>();
            if (double_ != null)
                cible = double_.transform;
            else
                cible = joueur; // revient au joueur si pas de double
        }

        // Revient au joueur si le double disparaît
        if (cible == null)
            cible = joueur;
    }

    private void LateUpdate()
    {
        if (cible == null) return;

        Vector3 nouvellePos = new Vector3(cible.position.x, cible.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, nouvellePos, vitesseSuivi * Time.deltaTime);
    }
}