using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceManager : MonoBehaviour
{
    // Private instance
    private static AmbianceManager instance;

    // Ref to ambiance
    [SerializeField]
    private FMODUnity.EventReference ambianceEvent;

    // Public instance property
    public static AmbianceManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // Create singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Play ambiance
        RuntimeManager.PlayOneShot(ambianceEvent);
    }
}
