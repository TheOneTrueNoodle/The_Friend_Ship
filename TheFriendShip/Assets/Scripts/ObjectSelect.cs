using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ObjectSelect : MonoBehaviour
{
    [SerializeField] private GameObject RedPrefab;
    [SerializeField] private GameObject YellowPrefab;
    [SerializeField] private GameObject BluePrefab;
    [SerializeField] private GameObject RedButton;
    [SerializeField] private GameObject YellowButton;
    [SerializeField] private GameObject BlueButton;
    private AR_placement_with_block_UI ARPlacement;

    private void Awake()
    {
        ARPlacement = FindObjectOfType<ARSessionOrigin>().GetComponent<AR_placement_with_block_UI>();
    }

    public void RedButtonToggle()
    {
        ARPlacement.placedPrefab = RedPrefab;
    }
    public void YellowButtonToggle()
    {
        ARPlacement.placedPrefab = YellowPrefab;
    }
    public void BlueButtonToggle()
    {
        ARPlacement.placedPrefab = BluePrefab;
    }
  
}
