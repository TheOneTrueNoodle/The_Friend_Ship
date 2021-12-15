using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionsManager : MonoBehaviour
{
    public List<CreatureFusions> CreatureFusions;
    private Vector3 FusionLocation;
    private GameObject SpawnFusion;

    [Range(0.0f, 10.0f)]
    public float FusionTimer;

    private bool IsFusing;

    public void TriggerFusion(List<GameObject> Inputs, int FusionID, Vector3 FusionLocation)
    {
        if(IsFusing != true)
        {
            IsFusing = true;
            _ = StartCoroutine(WaitToFuse(Inputs, FusionID, FusionLocation));
        }
    }

    public void StartFusion(List<GameObject> Inputs, int FusionID, Vector3 FusionLocation)
    {
        foreach(CreatureFusions Fusion in CreatureFusions)
        {
            if(Fusion.OutputID == FusionID)
            {
                foreach (GameObject obj in Inputs)
                {
                    Destroy(obj);
                }
                GameObject NewCreature = Instantiate(Fusion.Output, FusionLocation, Quaternion.identity);
                IsFusing = false;
            }
        }
    }

    IEnumerator WaitToFuse(List<GameObject> Inputs, int FusionID, Vector3 FusionLocation)
    {
        foreach (GameObject obj in Inputs)
        {
            Destroy(obj);
        }

        yield return new WaitForSeconds(FusionTimer);

        foreach (CreatureFusions Fusion in CreatureFusions)
        {
            if (Fusion.OutputID == FusionID)
            {
                GameObject NewCreature = Instantiate(Fusion.Output, FusionLocation, Quaternion.identity);
            }
        }

        yield return new WaitForSeconds(FusionTimer);


        IsFusing = false;
    }
}
