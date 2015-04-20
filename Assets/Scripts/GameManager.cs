using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    public GameObject Pacman;
    public List<GameObject> Ghosts;

    [HideInInspector]
    public uint points;

    // Use this for initialization
	void Start () {
        points = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
