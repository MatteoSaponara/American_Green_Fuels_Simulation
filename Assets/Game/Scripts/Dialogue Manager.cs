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

        // Dialogue box is not active by default
        private void Start()
        {
            Debug.Log("DialogueManager Start");

            dialogueBox.SetActive(false);
        }

        private void Update()
        {
            if (controls.Player.Interact.WasPressedThisFrame())
            {
                Debug.Log("INTERACT DETECTED");
                StartDialogue();
            }
        }

        private void StartDialogue()
        {
            Debug.Log("START DIALOGUE");

            dialogueBox.SetActive(true);
            dialogue.StartDialogue();
        }
    }
}