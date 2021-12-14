using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CreatureFusions
{
    [TextArea(1, 5)]
    public string FusionName;

    public GameObject[] Inputs;
    public GameObject Output;

    public Event Event;
}
