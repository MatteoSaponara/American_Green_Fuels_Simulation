using UnityEngine;

namespace game
{
    public class TabletUI : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Reference to the tablet UI.")]
        [SerializeField] private GameObject tabletUI;

        private PlayerControls controls;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            controls.Player.OpenTablet.performed += OpenTablet;
            controls.UI.CloseTablet.performed += CloseTablet;

            controls.Player.Enable();
        }

        private void OnDisable()
        {
            controls.Player.OpenTablet.performed -= OpenTablet;
            controls.UI.CloseTablet.performed -= CloseTablet;

            controls.Player.Disable();
            controls.UI.Disable();
        }

        private void Start()
        {
            tabletUI.SetActive(false);
        }

        private void OpenTablet(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            tabletUI.SetActive(true);

            controls.Player.Disable();
            controls.UI.Enable();
        }

        private void CloseTablet(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            CloseTablet();
        }

        private void CloseTablet()
        {
            tabletUI.SetActive(false);

            controls.UI.Disable();
            controls.Player.Enable();
        }

        public void CompleteTask()
        {
            SimulationManager.Instance.TryCompleteTask();

            CloseTablet();
        }
    }
}