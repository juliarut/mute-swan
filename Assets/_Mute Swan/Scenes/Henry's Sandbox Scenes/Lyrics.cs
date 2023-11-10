using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lyrics : MonoBehaviour
{
    [SerializeField] private List<string> descriptions;
    [SerializeField] private List<string> lyrics;


    public Dictionary<string, string> GetLyricDictionary()
    {
        Dictionary<string, string> lyricDict = new Dictionary<string, string>();

        for (int i = 0; i < descriptions.Count; i++)
        {
            lyricDict.Add(descriptions[i], lyrics[i]);
        }

        return lyricDict;
    }
}
