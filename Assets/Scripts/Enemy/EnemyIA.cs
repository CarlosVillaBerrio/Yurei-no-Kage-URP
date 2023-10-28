using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyIA : MonoBehaviour
{
    public GameObject target;

    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    bool reachedEndOfPath = false;

    Path path;
    int currentWayPoint = 0;

    Seeker seeker;
    Rigidbody rb;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("UpdatePath", 0f, .2f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        CheckForPlayerLayer();

        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector3 direction = ((Vector3)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector3 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector3.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }

    }

    void CheckForPlayerLayer()
    {
        if (target.layer == LayerMask.NameToLayer("Hidden"))
        {
            rb.velocity = new Vector3(0, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Player")
        //{
        //   vcam =  vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile.name = "6DWobble";
        //}
    }

}
