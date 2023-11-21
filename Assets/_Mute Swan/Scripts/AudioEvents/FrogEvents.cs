using FMODUnity;
using UnityEngine;

namespace AudioEvents
{
    [RequireComponent(typeof(Rigidbody))]
    public class FrogEvents : MonoBehaviour
    {
        // Reference to FMOD unity event to trigger when frow collides with water
        [SerializeField]
        private FMODUnity.EventReference frogSplashEvent;

        // Play one shot frog splash event when frog collides with object with Water tag
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Water"))
            {
                RuntimeManager.PlayOneShot(frogSplashEvent);
            }
        }
    }
}


