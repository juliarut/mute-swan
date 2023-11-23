using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using TMPro.Examples;

namespace TMPro.Examples
{
    public class TypeWriterEffect : MonoBehaviour
    {
        private TMP_Text m_textMeshPro;
        private string fullText;
        private StringBuilder currentText;
        private int index;
        private WaitForSeconds delay = new WaitForSeconds(0.05f);

        void Start()
        {
            m_textMeshPro = GetComponent<TMP_Text>();
        }

        public void StartTypewriter()
        {
            fullText = m_textMeshPro.text;
            currentText = new StringBuilder();
            index = 0;

            StartCoroutine(TypeText());
        }

        IEnumerator TypeText()
        {
            while (index < fullText.Length)
            {
                currentText.Append(fullText[index]);
                m_textMeshPro.text = currentText.ToString();
                index++;

                yield return delay;
            }
        }
    }
}

