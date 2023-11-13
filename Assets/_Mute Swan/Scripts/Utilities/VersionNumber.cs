using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Utilities
{
    [RequireComponent(typeof(TextMeshPro), typeof(ContentSizeFitter))]
    public class VersionNumber : MonoBehaviour
    {
        private TextMeshPro textMeshPro;
        [SerializeField] private Vector3 offset;
        string versionText;
        ContentSizeFitter contentSizeFitter;
        private GameObject cameraRef;

        // Start is called before the first frame update
        void Start()
        {
            cameraRef = GameObject.Find("Main Camera");
            transform.position = cameraRef.transform.position + offset;
            textMeshPro = GetComponent<TextMeshPro>();
            textMeshPro.fontSize = 28;
            textMeshPro.alignment = TextAlignmentOptions.TopLeft;
            versionText = string.Format("Ver. {0}", Application.version);
            textMeshPro.text = versionText;
            contentSizeFitter = GetComponent<ContentSizeFitter>();
            contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }

    }
}

