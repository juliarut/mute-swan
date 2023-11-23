using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class PetFrogCall : MonoBehaviour
{
    public Canvas petFrog;
    public PlayableDirector playableDirector;

    void Start()
    {
        // Inaktivera petFrog (Canvas) vid start
        petFrog.gameObject.SetActive(false);

        // Starta en koroutin för att aktivera petFrog (Canvas) efter 15 sekunder om PlayableDirector inte är aktiverad
        StartCoroutine(ActivatePetFrogAfterDelay());
    }

    IEnumerator ActivatePetFrogAfterDelay()
    {
        // Vänta i 15 sekunder vid spelets start
        yield return new WaitForSeconds(15f);

        // Kontrollera om PlayableDirector är inte aktiverad
        if (playableDirector != null && !playableDirector.isActiveAndEnabled)
        {
            // Aktivera petFrog (Canvas)
            petFrog.gameObject.SetActive(true);
        }
    }
}
