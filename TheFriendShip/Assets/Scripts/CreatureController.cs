using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    public Creatures Creature;
    private GameObject[] Dislikes;
    private GameObject[] Likes;

    public Rigidbody RB;

    public float range;
    public float speed;

    private void Awake()
    {
        Creature.DislikedCreatures = Dislikes;
        Creature.LikedCreatures = Likes;
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < Dislikes.Length; i++)
        {
            if(other == Dislikes[i])
            {
                RunFromTargetWithRotation(Likes[i].transform, 0.5f);
                return;
            }
        }

        for (int i = 0; i < Likes.Length; i++)
        {
            if(other == Likes[i])
            {
                FollowTargetWithRotation(Likes[i].transform, 0.5f);
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
}
