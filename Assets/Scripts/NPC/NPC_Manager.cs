using UnityEngine;
using UnityEngine.UI;

public class NPC_Manager : MonoBehaviour
{
    public Sprite[] dialogues;
    public RawImage dialogueBox;
    public InputManager inputManager;

    private bool isTriggered = false;
    public bool dialogueStart = false;
    private bool isHavingDialogue = true;

    private int dialogueIndex = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }

    private void Update()
    {
        if (isTriggered && isHavingDialogue && inputManager.isMouseClicked())
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        if (!dialogueStart)
        {
            dialogueStart = true;
            dialogueIndex = 0;


            dialogueBox.gameObject.SetActive(true);
            dialogueBox.texture = dialogues[dialogueIndex].texture;
            Time.timeScale = 0f;


            return;
        }

        dialogueIndex++;

        if (dialogueIndex >= dialogues.Length)
        {
            EndDialogue();
            return;
        }

        dialogueBox.texture = dialogues[dialogueIndex].texture;
    }

    private void EndDialogue()
    {
        dialogueStart = false;
        Time.timeScale = 1f;
        dialogueIndex = 0;

        dialogueBox.gameObject.SetActive(false);

        // Bu NPC-nin dialogue-u artıq bitib
        isHavingDialogue = false;
    }
}