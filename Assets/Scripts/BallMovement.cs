using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    private bool direction = false; // false = x , true = z
    private bool start = false;
    [SerializeField] private float speed = 10f;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update() 
    {
        if(gameObject.transform.position.y < 0)
        {
            gameManager.GameOver();
            return;
        }
            
        if(start)
        {
            Move();
        }
        if(Input.GetKeyDown(KeyCode.Space))    
        {
            direction = !direction;
            start = true;
            if(direction)
            {
                MoveZ();
            }
            else
            {
                MoveX();
            }
        }
    }

    void Move()
    {
        if(direction)
        {
            MoveZ();
        }
        else
        {
            MoveX();
        }
    }

    void MoveX()
    {
        transform.Translate(new Vector3(1f,0f,0f) * Time.deltaTime * speed);
    }
    void MoveZ()
    {
        transform.Translate(new Vector3(0f,0f,1f) * Time.deltaTime * speed);
    }
}
