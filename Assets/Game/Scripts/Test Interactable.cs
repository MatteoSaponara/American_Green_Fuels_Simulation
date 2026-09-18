using UnityEngine;

namespace game
{
    public class TestInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string prompt = "Interact with me";
        public string interactionPrompt => prompt;

        public void Interact()
        {
            Debug.Log("This has been interacted with.");
            transform.Rotate(0f, 45f, 0f);
        }
    }
}
