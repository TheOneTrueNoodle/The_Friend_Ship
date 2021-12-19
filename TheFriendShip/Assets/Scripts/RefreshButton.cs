using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshButton : MonoBehaviour
{
    public List<GameObject> Creatures;
    public void Refresh()
    {
        GameObject[] FusableCreatures = GameObject.FindGameObjectsWithTag("Fusable");
        GameObject[] NotFusableCreatures = GameObject.FindGameObjectsWithTag("NotFusable");

        foreach(GameObject creature in FusableCreatures)
        {
            Creatures.Add(creature);
        }
        foreach(GameObject creature in NotFusableCreatures)
        {
            Creatures.Add(creature);
        }

        foreach(GameObject creature in Creatures)
        {
            Creatures.Remove(creature);
            Destroy(creature);
        }
    }
}
