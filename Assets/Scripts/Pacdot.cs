using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour 
{
    public GameManager GameManager;

    void Start()
    {
        //GameManager = GameObject.Find("GameManager") as GameManager;
    }

    void OnTriggerEnter2D(Collider2D co) 
    {
        if (co.name == "pacman")
        {
            GameManager.points += 10;
            Destroy(gameObject);
        }
    }
}
