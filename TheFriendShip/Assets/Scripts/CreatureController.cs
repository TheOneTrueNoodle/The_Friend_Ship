using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    public Creatures Creature;
    private GameObject[] Dislikes;
    private GameObject[] Likes;
    private GameObject[] Fusions;

    [HideInInspector]
    public bool IsFusable = false;

    private GameObject CreatureManager;

    public Rigidbody RB;

    public float range;
    public float speed;

    private void Awake()
    {
        Creature.DislikedCreatures = Dislikes;
        Creature.LikedCreatures = Likes;
        Creature.Fusions = Fusions;
    }

    private void Start()
    {
        CreatureManager = GameObject.Find("Creature Manager");
    }

    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < Dislikes.Length; i++)
        {
            if(other == Dislikes[i])
            {
                RunFromTargetWithRotation(Dislikes[i].transform, 6f);
                return;
            }
        }

        for (int i = 0; i < Likes.Length; i++)
        {
            if(other == Likes[i])
            {
                FollowTargetWithRotation(Likes[i].transform, 0f);
                return;
            }
        }
    }

    public void FollowTargetWithRotation(Transform target, float distanceToStop)
    {
        if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        {
            transform.LookAt(target);
            RB.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
        }
    }

    public void RunFromTargetWithRotation(Transform target, float distanceToStop)
    {
        if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        {
            transform.LookAt(target);
            RB.AddRelativeForce(Vector3.back * speed, ForceMode.Force);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        for (int i = 0; i < Fusions.Length; i++)
        {
            if (other.gameObject == Fusions[i])
            {
                this.tag = "Fusable";
                CreatureManager.GetComponent<CreatureManager>().TriggerFusion();
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        for (int i = 0; i < Fusions.Length; i++)
        {
            if (other.gameObject == Fusions[i])
            {
                IsFusable = true;
            }
        }
    }
}
