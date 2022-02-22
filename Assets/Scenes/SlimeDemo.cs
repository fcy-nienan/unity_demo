using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDemo : MonoBehaviour
{
    private int life = 100;
    //主角
    private GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        character = GameObject.FindGameObjectWithTag("person");
    }
    private Animator animator;
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        //被剑攻击
        if (other.gameObject.name == "Sword")
        {
            Debug.Log("发现主角");
            die();
            getHit();
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "Sword")
        {
            Debug.Log("持续碰撞");
            die();
            getHit();
        }
    }

    public float Distnace(Collider a, Collider b)
    {
        return Vector3.Distance(a.ClosestPointOnBounds(b.transform.position),
            b.ClosestPointOnBounds(a.transform.position));
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Sword")
        {
            Debug.Log("离开碰撞");
            Debug.Log("血量剩余:" + life);
            play("IdleNormal");
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance_check_and_attack();
    }

    void distance_check_and_attack()
    {
        if (character)
        {
            float dist = (character.transform.position - this.transform.position).magnitude;
            int dist_int = (int) dist;
            // Debug.Log("相距"+dist_int+"个单位");
            if (dist_int < 2)
            {
                attack();
            }
        }
    }
    void play(string name)
    {
        animator.Play(name,0,0f);
    }
    void die()
    {
        if (life <= 0)
        {
            play("Die");
            Destroy(this.gameObject);
            create_other_enemy();
        }
    }

    void create_other_enemy()
    {
        GameObject.Find("enemyTemplate").GetComponent<RandomCreate>().create_enemy();
    }

    void getHit()
    {
        life = life - 1;
        play("GetHit");
        die();
    }

    void attack()
    {
        play("Attack01");
    }

    void run()
    {
        play("run");
    }
}
