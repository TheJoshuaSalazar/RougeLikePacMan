using UnityEngine;
using System.Collections;

public class SectionMaze  
{
    public int[][] sectionMazeArray = new int[17][];


	// Use this for initialization
	public void Start () 
    {
        for (int i = 0; i < sectionMazeArray.Length; i++)
        {
            sectionMazeArray[i] = new int[30];
        }
	}
	
    public void Create()
    {
        for (int i = 0; i < sectionMazeArray.Length; i++)
        {
            for (int j = 0; j < sectionMazeArray[i].Length; j++)
			{
                sectionMazeArray[i][j] = 1;
			}
        }
    }

}