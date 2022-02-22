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


    private float normal_speed = 5f;
    private float normal_rotation_speed = 200.0f;
    
    public float speed = 5f;
    float rotationSpeed = 200.0f;  //旋转速度

    private int UP = 0;

    private int RIGHT = 1;

    private int DOWN = 2;

    private int LEFT = 3;

    private int oldState;
    private Animation ani;
    private int direction_state;

    private Animator animator;

    private Dictionary<string,AnimationClip> animation_map = new Dictionary<string, AnimationClip>();

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<Renderer>().material.color = Color.red;
        animator = this.GetComponent<Animator>();
        Debug.Log("start");
        
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (var animationClip in clips)
        {
            animation_map.Add(animationClip.name,animationClip);
        }
        
    }
    void battle()
    {
        if (Input.GetKey("j"))
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
    }
    
    void move_and_rotation()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed =10f;
            rotationSpeed = 300f;
        }
        else
        {
            speed = 5.0f;
            rotationSpeed = 200.0f;
        }

        if (Input.GetKeyDown("w"))
        {
            Debug.Log("key down w");
            this.transform.Translate(0,0,Input.GetAxis("Vertical")* Time.deltaTime * speed);
            animator.Play("WalkForwardBattle",0,0);
        }

        if (Input.GetKeyUp("w"))
        {
            Debug.Log("key up w");
        }
        if (Input.GetKey("w"))
        {
            // this.transform.Translate(0,0,Input.GetAxis("Vertical")* Time.deltaTime * speed);
            // animator.SetBool("to_walk",true);
            // animator.Play("WalkForwardBattle",0,0);
        }else if (Input.GetKey("s"))
        {
            this.transform.Translate(0,0,(Input.GetAxis("Vertical")* Time.deltaTime * speed));
        }else if (Input.GetKey("a"))
        {
            this.transform.Rotate(0,Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed,0);   
        }else if (Input.GetKey("d"))
        {
            this.transform.Rotate(0,Input.GetAxis("Horizontal")  * Time.deltaTime * rotationSpeed,0);
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        // receive_mouse();
        move_and_rotation();
        battle();
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}