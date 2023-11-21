using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioEvents
{
    public class GateEvents : MonoBehaviour
    {
        [SerializeField]
        private FMODUnity.EventReference gateOpenEvent;

        [SerializeField]
        private FMODUnity.EventReference gateCloseEvent;



        // Start is called before the first frame update
        void Start()
        {
        }

        public void PlayOpenGateSound()
        {
            FMODUnity.RuntimeManager.PlayOneShot(gateOpenEvent);
        }

        public void PlayCloseGateSound()
        {
            RuntimeManager.PlayOneShot(gateCloseEvent);
        }
    }
}


