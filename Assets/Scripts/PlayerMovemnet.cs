using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState{
    walk,
    attack,
    interact
}

public class PlayerMovemnet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed_player = 2f;

    private Vector3 change;

    private Animator animator;

    public PlayerState currentState;

    private Rigidbody2D rigidbody;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("move_x",0);
        animator.SetFloat("move_y",-1);
        currentState = PlayerState.walk;
    }

    
    // Update is called once per frame
    void Update()
    {

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack){
          Debug.Log("Attack");
          StartCoroutine(AttackCoroutine());
        }

        if(currentState == PlayerState.walk){
            UpdateAnimationMove();
        }
    
    }
    void UpdateAnimationMove(){
        if(change != Vector3.zero){
            MoveCharacter();
            animator.SetFloat("move_x",change.x);
            animator.SetFloat("move_y",change.y);
            animator.SetBool("isWalking",true);
        }else{
            animator.SetBool("isWalking",false);
        }
    }


    private IEnumerator AttackCoroutine(){
         animator.SetBool("isAttacking", true);
         currentState = PlayerState.attack;
         yield return null;
         animator.SetBool("isAttacking",false);
         yield return new WaitForSeconds(.3f);
         currentState = PlayerState.walk;   
    }


    void MoveCharacter(){
          change.Normalize();
        //   transform.Translate(new Vector3(change.x,change.y,0) * speed_player * Time.deltaTime);
        rigidbody.MovePosition(
            transform.position + change * speed_player * Time.deltaTime
        );
    }

}
