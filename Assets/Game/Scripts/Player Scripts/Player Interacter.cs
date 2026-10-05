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

        private void OnEnable()
        {
            SimulationManager.Instance.Controls.Player.Interact.started += OnInteract;
        }

        private void OnDisable()
        {
            SimulationManager.Instance.Controls.Player.Interact.started -= OnInteract;
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            Debug.Log("INTERACT WORKS!");

            Ray ray = new Ray(interactorSource.position, interactorSource.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange/*, interactableLayer*/))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }

        // Gizmo of the interaction raycast
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(interactorSource.position, interactorSource.forward.normalized * interactRange);
        }
    }
}