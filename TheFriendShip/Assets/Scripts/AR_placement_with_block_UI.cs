using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class AR_placement_with_block_UI : MonoBehaviour
{
    public GameObject placedPrefab;

    [SerializeField]
    private GameObject uiPanel;

    [SerializeField]
    private GameObject ToggleButton;

    private ARRaycastManager arRaycastManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    public void Toggle()
    {
        uiPanel.SetActive(!uiPanel.activeSelf);
        var toggleButtonText = ToggleButton.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        toggleButtonText.text = uiPanel.activeSelf ? "UI OFF" : "UI ON";
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;

                bool isOverUi = touchPosition.IsPointOverUIObject();

                if(!isOverUi && arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    
                    var hitPose = hits[0].pose;
                    hitPose.rotation.Set(0, 180f, 0, 0);
                    Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
}
