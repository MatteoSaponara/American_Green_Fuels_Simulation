using UnityEngine;

namespace game
{
    public interface IInteractable
    {
        // Prompt message for the UI
        public string interactionPrompt { get; }

        // Core execution logic
        public void Interact();
    }
}
