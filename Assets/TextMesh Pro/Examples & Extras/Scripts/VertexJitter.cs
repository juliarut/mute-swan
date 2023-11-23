using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveText : MonoBehaviour
{

    public TMP_Text yourtext;

    void Start() { }

    void Update()
    {

        yourtext.ForceMeshUpdate();

        var textInfo = yourtext.textInfo;

        //get text count
        int charcount = textInfo.characterCount;

        for (int i = 0; i < charcount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            // get verts
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                var orig = verts[charInfo.vertexIndex + j];
                // new verts for text
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Cos(Time.time * 2f + orig.x * 0.01f) * 20f, 0);
            }
        }

        //creates text 
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            yourtext.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}