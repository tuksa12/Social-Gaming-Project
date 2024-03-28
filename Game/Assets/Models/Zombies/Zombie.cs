using System.Collections;
using System.Collections.Generic;
// using UnityEditor.UI;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    //moving toward player configuration
    public Transform player;
    private Rigidbody rb;
    private float distance;
    
    //moving animation configuration
    public GameObject TargetChar;
    public AnimationClip Attack03Anim;
    public AnimationClip Idle;

    [SerializeField] private float spawnRate = 0.5f;
    [SerializeField] private int attack = 0;
    [SerializeField] private int defense = 0;
    [SerializeField] private int hp = 10;
    [SerializeField] private int speed = 5;

    public float SpawnRate {
        get {return spawnRate;}
    }

    public int Attack {
        get {return attack;}
    }

    public int Defense {
        get {return defense;}
    }

    public int Hp {
        get {return hp;}
    }

    private void FollowPlayer() {

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.position);

        //Make the enemy move
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
        if(distance < 15) {
            bool isMoving;
            isMoving = transform.position != player.position;
            if(distance > 0.1f) {
                TargetChar.GetComponent<Animation>().Play(Attack03Anim.name);
                rb.MovePosition(pos);
            }else 
            {
                TargetChar.GetComponent<Animation>().Play(Idle.name);
            }
            
            
            transform.LookAt(player);
        }
    }
}
