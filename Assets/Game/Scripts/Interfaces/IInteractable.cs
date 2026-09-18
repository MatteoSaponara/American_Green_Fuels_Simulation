using UnityEngine;

namespace game
{
    public interface IInteractable
    {
        // Prompt message for the UI
        string InteractionPrompt { get; }

        // Core execution logic
        void Interact();
    }
}
