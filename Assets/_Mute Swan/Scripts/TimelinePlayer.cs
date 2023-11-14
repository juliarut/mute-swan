using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    private PlayableDirector director;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void StartTimeLine() 
    {
        director.Play(); 
    }
}
