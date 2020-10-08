﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash(){
        animator.SetBool("isSmashed",true);
        StartCoroutine(breakCoroutine());
    }

    private IEnumerator breakCoroutine(){
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}
