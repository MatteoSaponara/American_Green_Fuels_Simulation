using UnityEngine;
using UnityEngine.InputSystem;

namespace game
{
    public class DialogueManager : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Reference to UI dialogue box.")]
        [SerializeField] private GameObject dialogueBox;
        [Tooltip("Reference to dialogue script.")]
        [SerializeField] private Dialogue dialogue;

        // Player input setup
        private PlayerControls controls;
        // Is dialogue script active
        private bool dialogueActive;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            controls.Player.Enable();
        }

        private void OnDisable()
        {
            controls.Player.Disable();
        }

        // Dialogue box is not active by default. Also connects dialogue finishing to EndDialouge.
        private void Start()
        {
            dialogueBox.SetActive(false);

            dialogue.onDialogueFinished += EndDialogue;
        }

        private void Update()
        {
            if (controls.Player.Interact.WasPressedThisFrame())
            {
                if (dialogueActive)
                {
                    // Fully types out line if button was pressed while typing
                    if (dialogue.IsTyping)
                    {
                        dialogue.FinishLine();
                    }
                    // Goes to next line the current line is finished
                    else
                    {
                        dialogue.NextLine();
                    }
                }
            }   
        }

        // Initiates dialgoue
        private void StartDialogue(string[] newLines)
        {
            dialogue.SetLines(newLines);

            dialogueActive = true;
            dialogueBox.SetActive(true);
            dialogue.StartDialogue();
        }

        // Disable dialogue UI
        private void EndDialogue()
        {
            dialogueActive = false;
            dialogueBox.SetActive(false);
        }

        private void OnDestroy()
        {
            dialogue.onDialogueFinished -= EndDialogue;
        }
    }
}