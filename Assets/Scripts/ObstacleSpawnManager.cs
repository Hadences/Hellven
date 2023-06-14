using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    private GameLogic gameLogic;

    private int previousInt = -1;

    private void Start()
    {
        gameLogic = gameObject.GetComponent<GameLogic>();
    }

    public void spawnMonsters()
    {
        int randomInt = Random.Range(0,3);
        
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != randomInt && i != previousInt)
            {
                gameLogic.spawnMonster(spawnPoints[i].transform.position);
            }
        }
    }

    public void spawnObstacles()
    {
        int randomInt = getUniqueRandomNum();
        
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i == randomInt)
            {
                gameLogic.spawnObstacle(spawnPoints[i].transform.position);
            }
        }

        previousInt = randomInt;
    }

    private int getUniqueRandomNum()
    {
        int i = Random.Range(0, 3);
        while (i == previousInt)
        {
            i = Random.Range(0, 3);
        }

        return i;
    }
    
}


