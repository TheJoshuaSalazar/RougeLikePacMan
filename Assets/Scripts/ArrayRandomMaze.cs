using UnityEngine;
using System.Collections;

public class ArrayRandomMaze : MonoBehaviour 
{
    public GameObject Cube;
    public GameObject pacDot;

    private float minY;
    private float maxX;
    private float cubeHeightOffset;
    private float cubeWidthOffset;
    private Vector2 startPosition;

    private int[,] mazeArray = new int[17, 30];

	// Use this for initialization
	void Start () 
    {
        Vector2 topLeft = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
        Vector3 topLeftWorldPos = Camera.main.ScreenToWorldPoint(topLeft);

        minY = topLeftWorldPos.y;
        maxX = -topLeftWorldPos.x;

        cubeHeightOffset = Cube.transform.localScale.y;
        cubeWidthOffset = Cube.transform.localScale.x;

        startPosition = new Vector2(maxX + cubeWidthOffset / 2, minY - cubeHeightOffset / 2);

        CreateMaze();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CreateMaze()
    {
        SectionMaze level = new SectionMaze();
        level.Start();
        level.Create();

        float currentPlacementX = startPosition.x;
        float currentPlacementY = startPosition.y;

        for (int i = 0; i < level.sectionMazeArray.Length; i++)
        {
            for (int j = 0; j < level.sectionMazeArray[i].Length; j++)
            {
                if (level.sectionMazeArray[i][j] == 1)
                    Instantiate(Cube, new Vector3(currentPlacementX, currentPlacementY, Cube.transform.position.z), Quaternion.identity);

                currentPlacementX += cubeWidthOffset;
            }
            currentPlacementY -= cubeHeightOffset;
            currentPlacementX = startPosition.x;
        }
    }
}