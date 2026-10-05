using UnityEngine;
using UnityEngine.InputSystem;

namespace game
{
    public class TabletUI : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Reference to the tablet UI.")]
        [SerializeField] private GameObject tabletUI;

        private void Start()
        {
            tabletUI.SetActive(false);

            SimulationManager.Instance.Controls.Player.OpenTablet.performed += OpenTablet;
            SimulationManager.Instance.Controls.UI.CloseTablet.performed += CloseTablet;
        }

        private void OnDestroy()
        {
            SimulationManager.Instance.Controls.Player.OpenTablet.performed -= OpenTablet;
            SimulationManager.Instance.Controls.UI.CloseTablet.performed -= CloseTablet;
        }

        private void OpenTablet(InputAction.CallbackContext context)
        {
            Debug.Log("OPEN TABLET INPUT DETECTED");

            tabletUI.SetActive(true);

            SimulationManager.Instance.Controls.Player.Disable();
            SimulationManager.Instance.Controls.UI.Enable();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void CloseTablet(InputAction.CallbackContext context)
        {
            Debug.Log("CLOSE TABLET INPUT DETECTED");

            tabletUI.SetActive(false);

            SimulationManager.Instance.Controls.UI.Disable();
            SimulationManager.Instance.Controls.Player.Enable();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void CompleteTask()
        {
            SimulationManager.Instance.TryCompleteTask();

            tabletUI.SetActive(false);

            SimulationManager.Instance.Controls.UI.Disable();
            SimulationManager.Instance.Controls.Player.Enable();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}