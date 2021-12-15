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
    [SerializeField] private GameObject OrangePrefab;
    [SerializeField] private GameObject GreyPrefab;
    [SerializeField] private GameObject GreenPrefab;
    [SerializeField] private GameObject WhitePrefab;



    [SerializeField] private GameObject RedButton;
    [SerializeField] private GameObject YellowButton;
    [SerializeField] private GameObject BlueButton;
    [SerializeField] private GameObject OrangeButton;
    [SerializeField] private GameObject GreyButton;
    [SerializeField] private GameObject GreenButton;
    [SerializeField] private GameObject WhiteButton;



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
  
    public void OrangeButtonToggle()
    {
        ARPlacement.placedPrefab = OrangePrefab;

    }

    public void GreyButtonToggle()
    {
        ARPlacement.placedPrefab = GreyPrefab;

    }

    public void GreenButtonToggle()
    {
        ARPlacement.placedPrefab = GreenPrefab;
    }

    public void WhiteButtonToggle()
    {
        ARPlacement.placedPrefab = WhitePrefab;

    }

}
