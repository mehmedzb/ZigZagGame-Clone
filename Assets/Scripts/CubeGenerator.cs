using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] GameObject cube;
    Vector3 firstCubePos = new Vector3(3.5f , 0f , 2.5f);
    public static Cube lastCube;
    GameManager gameManager;

    int numberOfCubeNeeded = 50;
    int score = 30;


    private int direction = 0;

    private void Start() 
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        if(lastCube == null)
        {
            // lastCube = Instantiate(cube , firstCubePos , Quaternion.identity );
            GameObject cubee = Instantiate(cube , firstCubePos , Quaternion.identity );
            lastCube = cubee.GetComponent<Cube>();
        }
    }

    void Update()
    {
        if(gameManager.getCubeNumber() < numberOfCubeNeeded)
        {
            direction = RandomDirection();
            CubeSpawn(direction);
        }
        if(gameManager.getScore() > score)
        {
            score += 30;
            numberOfCubeNeeded += 50;
        }
    }

    int RandomDirection()
    {
        return Random.Range(0,100);
    }

    void CubeSpawn(int direction)
    {
        if(direction < 50)
            CubeSpawnX();
        else
            CubeSpawnZ();
    }

    void CubeSpawnX()
    {
        Vector3 newPos = new Vector3(lastCube.transform.position.x + 0.5f , 0f , lastCube.transform.position.z);
        Instantiate(cube , newPos, Quaternion.identity);
        gameManager.IncreaseCubeNumber();
    }
    void CubeSpawnZ()
    {
        Vector3 newPos = new Vector3(lastCube.transform.position.x  , 0f , lastCube.transform.position.z + 0.5f);
        Instantiate(cube , newPos, Quaternion.identity);
        gameManager.IncreaseCubeNumber();
    }

}
