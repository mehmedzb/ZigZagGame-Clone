using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    GameManager gameManager;
    void OnEnable()
    {
        CubeGenerator.lastCube = this;
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.transform.tag == "Player")
        {
            gameManager.IncreaseScore();
            Destroy(gameObject , 4f); 
        }    
    }
}
