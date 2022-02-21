using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_mouse_listener : MonoBehaviour
{
    private enum State
    {
        Walk,
        Idle,
        Attack01,
        Attack02,
        Defend,
        Die,
        DieRecover,
        Run,
        Dizzy,
        GetHit
    }


    public float speed;

    private int UP = 0;

    private int RIGHT = 1;

    private int DOWN = 2;

    private int LEFT = 3;

    private int oldState;
    private Animation ani;
    private int direction_state;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<Renderer>().material.color = Color.red;
        animator = this.GetComponent<Animator>();
        speed = 5f;
        Debug.Log("start");
    }


    void setState(int currState)
    {
        Vector3 transformValue = new Vector3();
        int rotateValue = (currState - direction_state);
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
        transform.Translate(transformValue, Space.World);
        oldState = direction_state;
        direction_state = currState;
    }

    void receive_mouse()
    {
        if (Input.GetKey("w"))
        {
            setState(UP);
            play(State.Walk.ToString());
        }else if (Input.GetKey("s"))
        {
            setState(DOWN);
        }else if (Input.GetKey("a"))
        {
            setState(LEFT);
        }
        else if (Input.GetKey("d"))
        {
            setState(RIGHT);
        }
        else if (Input.GetKey("j"))
        {
            play(State.Attack01.ToString());
        }
        else if (Input.GetKey("k"))
        {
            play(State.Attack02.ToString());
        }else if (Input.GetKey("l"))
        {
            play(State.Defend.ToString());
        }
    }

    void play(string name)
    {
        animator.Play(name,0,0f);
        // animator.SetInteger(name, 0);
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