using UnityEngine;
using TMPro;
using System.Collections;

namespace game
{
    public class Dialogue : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Text component of the dialogue.")]
        [SerializeField] private TextMeshProUGUI textComponent;
        [Header("Text")]
        [Tooltip("Each line of text.")]
        [SerializeField] private string[] lines;
        [Tooltip("Speed at which the text is typed out.")]
        [SerializeField] private float textSpeed;

        // Index of the current string that is being typed
        private int index;
        // Gives if dialogue is being currently typed
        private bool isTyping;

        public System.Action onDialogueFinished;

        // Clears text
        private void Start()
        {
            textComponent.text = string.Empty;
        }

        // Sets the lines of dialogue
        public void SetLines(string[] newLines)
        {
            lines = newLines;
        }

        public void StartDialogue()
        {
            index = 0;
            StartCoroutine(TypeLine());
        }

        // Types line
        IEnumerator TypeLine()
        {
            isTyping = true;

            // Clears textbox
            textComponent.text = string.Empty;

            //Pauses the coroutine for 1 frame
            yield return null;

            // Type each character 1 by 1
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;

                yield return new WaitForSeconds(textSpeed);
            }

            isTyping = false;
        }

        // Returns whether dialogue is being typed
        public bool IsTyping
        {
            get { return isTyping; }
        }

        // Immediatly types out full line
        public void FinishLine()
        {
            StopAllCoroutines();

            textComponent.text = lines[index];

            isTyping = false;
        }

        // Goes to the next line
        public void NextLine()
        {
            index++;

            if (index < lines.Length)
            {
                StartCoroutine(TypeLine());
            }
            else // Ends dialogue if there are no lines left
            {
                onDialogueFinished?.Invoke();
            }
        }

        
    }
}
