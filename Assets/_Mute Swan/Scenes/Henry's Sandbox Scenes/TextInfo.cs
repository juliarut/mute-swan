using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInfo : MonoBehaviour
{
    [SerializeField] private List<char> charList;

    public void UpdateCharList(List<char> newCharList)
    {
        charList = newCharList;
    }

    public void ClearCharList()
    {
        charList.Clear();
    }
}
