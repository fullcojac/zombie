using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    public class Count
    {
        public int minimum;
        public int maximum;
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }
    public GameObject outterWallsTile;
    public GameObject innerWallsTile;
    public GameObject floorTile;
    public GameObject door;
    public GameObject player;
    public GameObject gun;
    Count wallCount = new Count(10, 20);
    int columns = 14;
    int rows = 8;
    Transform boardHolder;
    List<Vector3> gridPositions = new List<Vector3>();
    Vector3 randomDoorPosition;
    Vector3 startingPosition = new Vector3(0f, 0f, 0f);
    // Use this for initialization
    void InitialiseList()
    {
        //creation of the grid
        gridPositions.Clear();
        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }
    void BoardSetup()
    {
        //placing the tiles
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)//part de moin 1 jusqu'a 8 pour créé un mur alentour de la zone de jeu
            {
                GameObject toInstantiate = floorTile;
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outterWallsTile;
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }
    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);//choose a random tile in the grid
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }
    void LayoutObjectAtRandom(GameObject tile, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);
        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tile;
            Instantiate(tile, randomPosition, Quaternion.identity);
        }
    }
    private void Start()
    {
        InitialiseList();
        BoardSetup();
        LayoutObjectAtRandom(innerWallsTile, wallCount.minimum, wallCount.maximum);
        LayoutObjectAtRandom(gun, 1, 2);
        player.transform.position = startingPosition;
    }
}