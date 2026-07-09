using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Intro : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texteDialogue;
    [SerializeField] private string[] dialogues;
    private int index = 0;

    private void Awake()
    {
        texteDialogue.text = dialogues[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            index++;

            if (index >= dialogues.Length)
            {
                // Tous les dialogues sont passés, lance le jeu
                SceneManager.LoadScene("Game"); // nom de ta scène de jeu
            }
            else
            {
                texteDialogue.text = dialogues[index];
            }
        }
    }
}