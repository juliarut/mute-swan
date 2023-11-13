using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Utilities
{
    [RequireComponent(typeof(TextMeshPro))]
    public class FPSCounter : MonoBehaviour
    {
        private string fpsText;
        private float fpsValue;
        private float deltaTime = 0.0f;
        private TextMeshPro textMeshPro;
        private float repeatRate = 0.25f;
        private GameObject cameraRef;
        [SerializeField] private Vector3 offset;

        // Start is called before the first frame update
        void Start()
        {
            cameraRef = GameObject.Find("Main Camera");
            textMeshPro = GetComponent<TextMeshPro>();
            textMeshPro.alignment = TextAlignmentOptions.Center;
            textMeshPro.horizontalAlignment = HorizontalAlignmentOptions.Center;
            textMeshPro.verticalAlignment = VerticalAlignmentOptions.Middle;
            textMeshPro.fontSize = 28;
            fpsText = "";
            InvokeRepeating(nameof(UpdateFPS), repeatRate, repeatRate);
        }

        // Update is called once per frame
        void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            float msec = deltaTime * 1000f;
            fpsValue = 1.0f / deltaTime;
            fpsText = string.Format("FPS: {0:0} ({1:0.0} ms)", Mathf.RoundToInt(fpsValue), msec);
            transform.position = cameraRef.transform.position + offset;
        }

        private void UpdateFPS()
        {
            textMeshPro.text = fpsText;
        }
    }
}

