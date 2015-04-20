using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour
{
    public GameManager GameManager;
    public Transform[] waypoints;
    public float speed = 0.3f;

    private int cur = 0;

    void FixedUpdate () 
    {
        // Waypoint not reached yet? then move closer
        if (transform.position != waypoints[cur].position) 
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else cur = (cur + 1) % waypoints.Length;

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.name == "pacman")
        {
            Destroy(collision.gameObject);
        }
    }
}
