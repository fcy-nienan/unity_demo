using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreate : MonoBehaviour
{
    float CreatTime = 5f; //设计创造狼的时间
    public GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
    }

    public void create_enemy()
    {
        Instantiate(enemy, new Vector3(3, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
