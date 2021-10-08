using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    public GameObject explosion;
    public float scareDistance = 5.0f;
    public Image jumpScareImage;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if(distance < scareDistance)
        {
            playerTransform.GetComponent<Player>().TakeDamage();
            jumpScareImage.enabled = true;
        }
        else
        {
            jumpScareImage.enabled = false;
        }
        agent.SetDestination(playerTransform.position);
    }

    void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
