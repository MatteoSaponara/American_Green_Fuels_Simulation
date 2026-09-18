using UnityEngine;
using UnityEngine.InputSystem;

namespace game
{
    public class PlayerInteracter : MonoBehaviour
    {
        [Tooltip("Position from where the interact ray will be casted.")]
        [SerializeField] private Transform interactorSource;
        [Header("Settings")]
        [Tooltip("How far from the player an object can be interacted with.")]
        [SerializeField] private float interactRange;
        //[Tooltip("Layer of interactables.")]
        //[SerializeField] private LayerMask interactableLayer; Optional: Optimize by filtering layers

        private bool interacting = false;
        public void OnInteract(InputAction.CallbackContext context)
        {
            // Only trigger the interaction on the initial button press (started/performed)
            if (context.performed)
            {
                interacting = true;
            }
            else
            {
                interacting = false;
            }
        }

        void Update()
        {
            if (interacting) // Checks if the player presses the interact button
            {
                Ray ray = new Ray(interactorSource.position, interactorSource.forward);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange/*, interactableLayer*/))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
                    {
                        interactable.Interact();
                    }
                }
            }
        }

        // Gizmo of the interaction raycast
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(interactorSource.position,interactorSource.forward.normalized * interactRange);
        }
    }
}
