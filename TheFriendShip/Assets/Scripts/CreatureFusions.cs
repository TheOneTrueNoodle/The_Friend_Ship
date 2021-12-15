using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CreatureFusions
{
    [TextArea(1, 5)]
    public string FusionName;

    public int[] InputIDs;
    public int OutputID;
    public GameObject Output;

    public int Length { get; internal set; }
}
