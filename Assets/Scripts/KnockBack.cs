using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    // Start is called before the first frame update
    public float thrust;
    public float knowTime;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.CompareTag("Enemy")){

            Rigidbody2D enemy = target.GetComponent<Rigidbody2D>();
            
            if(enemy != null){
                enemy.GetComponent<Enemy>().enemyState = EnemyState.stagger;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference,ForceMode2D.Impulse);
                StartCoroutine(KnockBackCoroutine(enemy));

            }
        }
    }

    private IEnumerator KnockBackCoroutine(Rigidbody2D enemy){
        if(enemy != null){
            yield return new WaitForSeconds(knowTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().enemyState = EnemyState.idle;
        }
    }
}
// 