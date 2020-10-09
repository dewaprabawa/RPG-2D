using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBehaviour : Enemy
{
    // Start is called before the first frame update
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    private Rigidbody2D rb;

    private EnemyState currentState;

    private Animator animator;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentState = EnemyState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }


    void CheckDistance(){
        if(Vector3.Distance(target.position,transform.position) <= chaseRadius && Vector3.Distance(target.position,transform.position) > attackRadius){
            
            if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger){
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, enemySpeedMove * Time.deltaTime); 
                rb.MovePosition(temp);
                ChangeEnemyState(EnemyState.walk);
            }
        }
    }

    private void ChangeEnemyState(EnemyState newState){
        if(currentState != newState){
            currentState = newState;
        }
    }
}
