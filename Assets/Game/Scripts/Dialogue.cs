using UnityEngine;
using TMPro;
using System.Collections;

namespace game
{
    public class Dialogue : MonoBehaviour
    {
        [Tooltip("Text component of the dialogue.")]
        [SerializeField] private TextMeshProUGUI textComponent;
        [Tooltip("Each line of text.")]
        [SerializeField] private string[] lines;
        [Tooltip("How fast the text scrolls.")]
        [SerializeField] private float textSpeed;

        private int index;
        private bool isTyping;

        private void Start()
        {
            textComponent.text = string.Empty;
            //StartDialogue();
        }

        public void StartDialogue()
        {
            index = 0;
            StartCoroutine(TypeLine());
        }

        // Types line
        IEnumerator TypeLine()
        {
            // Type each character 1 by 1
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }
}
