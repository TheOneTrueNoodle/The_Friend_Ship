using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    public CreatureFusions[] CreatureFusions;
    private Vector3 FusionLocation;
    private GameObject SpawnFusion;

    public void TriggerFusion()
    {
        FusionLocation = new Vector3(0, 0, 0);

        GameObject[] Fusables = GameObject.FindGameObjectsWithTag("Fusable");

        for (int i = 0; i < Fusables.Length; i++)
        {
            for(int j = 0; j < CreatureFusions.Length; j++)
            {
                for(int k = 0; k < CreatureFusions[j].Inputs.Length; k++)
                {
                    if (Fusables[i] == CreatureFusions[j].Inputs[k])
                    {
                        FusionLocation = Fusables[i].transform.position;
                        SpawnFusion = CreatureFusions[j].Output;

                        Destroy(Fusables[i]);
                        for(int l = 0; l < CreatureFusions[j].Inputs.Length; l++)
                        {
                            if(CreatureFusions[j].Inputs[l].tag == "Fusable")
                            {
                                Destroy(CreatureFusions[j].Inputs[l]);
                            }
                        }

                        StartFusion(CreatureFusions[j].Inputs);
                        return;
                    }
                }
            }
        }
    }

    private void StartFusion(GameObject[] Inputs)
    {
        GameObject NewCreature = Instantiate(SpawnFusion, FusionLocation, Quaternion.identity);
    }
}
