using UnityEngine;
using System.Collections;

enum StageTypes
{
    Start,
    Normal,
    Store,
    Boss,
    Empty,
}

public class LevelMaze : MonoBehaviour 
{
    public int[][] MainMaze = new int[6][];
    private int seedRow;
    private int seedColumn;

	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < MainMaze.Length; i++)
        {
            MainMaze[i] = new int[6];
        }
        seedRow = Random.Range(0, MainMaze.Length);
        seedColumn = Random.Range(0, MainMaze[0].Length);

        MainMaze[seedRow][seedColumn] = (int)StageTypes.Start;

        AssignMaze(seedRow, seedColumn);
	}

    private void AssignMaze(int row, int column)
    {
        int s;
        if (MainMaze[row][row] != null)
            s = 4;
    }
}