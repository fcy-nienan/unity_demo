using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_mouse_listener : MonoBehaviour
{
    public float speed;

    private int UP = 0; 

    private int RIGHT = 1;

    private int DOWN = 2;

    private int LEFT = 3;

    private int oldState;

    private int State;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
        speed = 5f;
        Debug.Log("start");
    }

    void setState(int currState)
    {
        Vector3 transformValue = new Vector3();
        int rotateValue = (currState - State);
        // transform.animation.Play("walk");
        switch (currState)
        {
            case 0:
                transformValue = Vector3.forward * Time.deltaTime * speed;
                break;
            case 1:
                transformValue = Vector3.right * Time.deltaTime * speed;
                break;
            case 2:
                transformValue = Vector3.back * Time.deltaTime * speed;
                break;
            case 3:
                transformValue = Vector3.left * Time.deltaTime * speed;
                break;
        }

        transform.Rotate(Vector3.up, rotateValue);
        transform.Translate(transformValue,Space.World);
        oldState = State;
        State = currState;
    }

    void receive_mouse()
    {
        
        if (Input.GetKey("w"))
        {
            setState(UP);
        }
        else if (Input.GetKey("s"))
        {
            setState(DOWN);
        }
  
        if (Input.GetKey("a"))
        {
            setState(LEFT);
        }
        else if (Input.GetKey("d"))
        {
            setState(RIGHT);
        }

    }

    // Update is called once per frame
    void Update()
    {
        receive_mouse();
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }  
    }
}
