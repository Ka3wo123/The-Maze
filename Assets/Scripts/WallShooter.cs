using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShooter : MonoBehaviour
{

    public Rigidbody shooter;
    public float throwSpeed = 20.0f;
    public int boardSize_NxN = 10;


    void Start()
    {
        createRigibody();        
    }


    void createRigibody(){

        float bulletSize = shooter.transform.lossyScale.y;
        float sizeY = transform.lossyScale.y;
        float sizeX = transform.lossyScale.x;
        float sizeZ = transform.lossyScale.z;

        // wyskalowanie parametrów
        float maxCounter = (sizeX*2)/bulletSize;
        if(boardSize_NxN>maxCounter){
            boardSize_NxN = (int)maxCounter;
        }
        float space = ( (sizeX*2) - boardSize_NxN*(bulletSize) ) / (boardSize_NxN + 1)  +   bulletSize;
        //space = Mathf.Round(space * 100f) / 100f;

        Debug.Log("Bullet: " + bulletSize);
        Debug.Log("Size X & Y " + sizeX+" & "+sizeY);
        Debug.Log("N: " + boardSize_NxN +" & space: "+space);


        for (float k = 0; k < boardSize_NxN; k++)
        {
            for (float i = 0; i < boardSize_NxN; i++)
            {
                Rigidbody newCoconut = Instantiate(shooter, new Vector3((transform.position.x+sizeX-(bulletSize/2.0f))-(space*i), (transform.position.y+sizeY)-(bulletSize/2)-(space*k), transform.position.z+sizeZ+(bulletSize/2.0f)), transform.rotation) as Rigidbody;
                newCoconut.name = "bullet";
                newCoconut.velocity = throwSpeed * transform.forward; 
            }
        }

    }



    void Update()
    {
        
    }
}
