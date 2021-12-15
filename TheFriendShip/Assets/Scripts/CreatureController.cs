using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    public int ID;

    public int[] LikedIDs;
    public int[] DislikedIDs;
    public int[] FusionIDs;

    public bool IsFusable = false;

    private GameObject FusionsManager;

    private Rigidbody RB;

    public float range;
    public float speed;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();

        FusionsManager = GameObject.Find("Fusions Manager");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<CreatureController>() == null)
        {
            return;
        }
        else
        {
            foreach (int Dislike in DislikedIDs)
            {
                if (other.gameObject.GetComponent<CreatureController>().ID != Dislike)
                {
                    continue;
                }
                RunFromTargetWithRotation(other.transform, 6f);
            }

            foreach (int Like in LikedIDs)
            {
                if (other.gameObject.GetComponent<CreatureController>().ID != Like)
                {
                    continue;
                }
                FollowTargetWithRotation(other.transform, 0f);
                
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<CreatureController>() == null)
        {
            return;
        }
        else
        {
            if (Vector3.Distance(other.transform.position, transform.position) < range)
            {
                Debug.Log("Okay so this far is working!!!!");

                foreach (int Fusion in FusionIDs)
                {
                    foreach (int OtherFusion in other.gameObject.GetComponent<CreatureController>().FusionIDs)
                    {
                        if (OtherFusion == Fusion)
                        {
                            List<GameObject> InputCreatures = new List<GameObject>();
                            InputCreatures.Add(other.gameObject);
                            InputCreatures.Add(gameObject);

                            tag = "Fusable";
                            other.gameObject.tag = "Fusable";
                            IsFusable = true;
                            FusionsManager.GetComponent<FusionsManager>().TriggerFusion(InputCreatures, Fusion, other.transform.position);
                        }
                    }
                }
            }
        }
    }

    public void FollowTargetWithRotation(Transform target, float distanceToStop)
    {
        transform.LookAt(target);
        RB.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
    }

    public void RunFromTargetWithRotation(Transform target, float distanceToStop)
    {
        transform.LookAt(target);
        RB.AddRelativeForce(Vector3.back * speed, ForceMode.Force);
    }
}
