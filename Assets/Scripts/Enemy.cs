using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyState enemyState;
    public int healthPoint;
    public string enemyName;
    public int baseAttack;
    public float enemySpeedMove;

}
