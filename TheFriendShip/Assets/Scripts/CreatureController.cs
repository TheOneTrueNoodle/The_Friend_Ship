using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    private CreatureDetails Details;
    private GameObject[] Dislikes;
    private Transform Transform;

    private void Awake()
    {
        Details.Creature.DislikedCreatures = Dislikes;

        for (int i = 0; i < Dislikes.Length; i++)
        {
            /*
            float mobInQuestion = closestMob.transform.position;
            float thisOne = this.transform.position;
 
            float distCheck = Mathf.Min(mobInQuestion, thisOne);
            */
            Debug.Log("Magnitude: " + Vector3.Distance(Dislikes.transform.position, Transform.position)); ;

            //The above and below currently feed out the same information.

            float distCheck = Vector3.Distance(Dislikes.transform.position, Transform.position);
            Debug.Log("Distance Check: " + (Mathf.Min(distCheck)));
        }
    }

    private void Update()
    {
        
    }
}
