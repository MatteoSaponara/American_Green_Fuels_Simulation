using System;
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
        public PlayerControls Controls => controls;

        [Header("References")]
        [Tooltip("Reference to the dialogue manager.")]
        [SerializeField] private DialogueManager dialogueManager;

        [Tooltip("The task currently being completed.")]
        [SerializeField] private SimulationTask currentTask;


        [Tooltip("Starting lines of dialouge when the simulation first starts.")]
        [SerializeField] private string[] initialDialogue;
        
        // 
        private PlayerControls controls;

        private bool currentTaskCompleted;

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

            controls = new PlayerControls();

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            currentTaskCompleted = false;
            controls.Player.Enable(); // Emables the Player Controls
            dialogueManager.StartDialogue(initialDialogue);
        }

        // Returns if the current task has been completed
        public bool isTaskCompleted()
        {
            return currentTaskCompleted;
        }

        // Checks if the current task has been completed sets dialogue
        public void TryCompleteTask()
        {
            if (currentTask.IsComplete())
            {
                currentTaskCompleted = true;

                dialogueManager.StartDialogue(new string[] { "Good job!"});
            }
            else
            {
                dialogueManager.StartDialogue(new string[] { "Try that again." });
            }
        }

        // Checks if the current task has been completed sets dialogue
        public void TryCompleteTask(string[] completeDialogue, string[] incompleteDialogue)
        {
            if (currentTask.IsComplete())
            {
                currentTaskCompleted = true;

                dialogueManager.StartDialogue(completeDialogue);
            }
            else
            {
                dialogueManager.StartDialogue(incompleteDialogue);
            }
        }

    }
}
