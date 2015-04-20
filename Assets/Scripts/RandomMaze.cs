using UnityEngine;
using System.Collections;

public class RandomMaze : MonoBehaviour 
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
        float currentPlacementX = startPosition.x;
        float currentPlacementY = startPosition.y;

        while(currentPlacementX <= (-maxX) && currentPlacementY >= (-minY))
        {
            if (currentPlacementX > (-startPosition.x - cubeHeightOffset) || currentPlacementX == startPosition.x ||
                currentPlacementY == -startPosition.y || currentPlacementY == startPosition.y)
                Instantiate(Cube, new Vector3(currentPlacementX, currentPlacementY, Cube.transform.position.z), Quaternion.identity);
            else if(Random.Range(0, 5) == 0)
                Instantiate(Cube, new Vector3(currentPlacementX, currentPlacementY, Cube.transform.position.z), Quaternion.identity);
            else
                Instantiate(pacDot, new Vector3(currentPlacementX, currentPlacementY, Cube.transform.position.z), Quaternion.identity);

            currentPlacementX += cubeWidthOffset;

            if(currentPlacementX >= -maxX)
            {
                currentPlacementY -= cubeHeightOffset;
                currentPlacementX = startPosition.x;
            }
        }
    }
}