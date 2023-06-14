using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private static int hearts = 3;
    [SerializeField] private GameObject[] heart_list = new GameObject[hearts];

    public void updateHealth(int health)
    {
        for (int i = 0; i < 3; i++)
        {
            heart_list[i].SetActive(false);
        }
        
        for (int i = 0; i < 3; i++)
        {
            if (i < health)
            {
                heart_list[i].SetActive(true);
            }
        }
    }
    
}
