using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform Target;
    public Animator CharacterAnimator;
    public float Speed;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, Target.position);
        if (distance > 0.1f)
        {
            transform.LookAt(Target.position);
            transform.Translate(Vector3.forward * Speed);
            CharacterAnimator.SetBool("IsWalking", true);
        }
        else
        {
            CharacterAnimator.SetBool("IsWalking", false);
        }
        
    }
}
