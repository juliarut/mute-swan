using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody))]
public class FrogEvents : MonoBehaviour
{

    [SerializeField]
    private FMODUnity.EventReference frogSplashEvent;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            RuntimeManager.PlayOneShot(frogSplashEvent);
        }
    }
}
