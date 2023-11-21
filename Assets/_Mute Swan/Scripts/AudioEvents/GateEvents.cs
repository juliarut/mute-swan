using FMODUnity;
using UnityEngine;

namespace AudioEvents
{
    public class GateEvents : MonoBehaviour
    {
        // Ref to gate open FMOD event
        [SerializeField]
        private FMODUnity.EventReference gateOpenEvent;

        // Ref to gate close FMOD event
        [SerializeField]
        private FMODUnity.EventReference gateCloseEvent;

        /// <summary>
        /// Play open gate sound
        /// </summary>
        public void PlayOpenGateSound()
        {
            FMODUnity.RuntimeManager.PlayOneShot(gateOpenEvent);
        }

        /// <summary>
        /// Play gate close sound
        /// </summary>
        public void PlayCloseGateSound()
        {
            RuntimeManager.PlayOneShot(gateCloseEvent);
        }
    }
}


