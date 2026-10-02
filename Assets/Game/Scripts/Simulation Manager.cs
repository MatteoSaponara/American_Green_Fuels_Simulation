using Unity.VisualScripting;
using UnityEngine;

namespace game
{
    public class SimulationManager : MonoBehaviour
    {
        public static SimulationManager Instance;

        // Later pause functionality
        public bool IsPaused;
        public DialogueManager DialogueManager => dialogueManager;

        [Header("References")]
        [Tooltip("Reference to the dialogue manager.")]
        [SerializeField] private DialogueManager dialogueManager;


        [Tooltip("Starting lines of dialouge when the simulation first starts.")]
        [SerializeField] private string[] initialDialogue;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogError("Two instances of Simulation Manager");
            }
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            dialogueManager.StartDialogue(initialDialogue);
        }

    }
}
