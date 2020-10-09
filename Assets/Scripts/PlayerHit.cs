using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.CompareTag("breakable")){
            target.GetComponent<PotBehaviour>().Smash();
        }
    }
}
