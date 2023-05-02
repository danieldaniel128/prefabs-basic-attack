using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float ChargeCooldown;
    [SerializeField] private float _damage;

    [SerializeField] private float knockbackForce;

    
    //[SerializeField] private Transform[] _enemiesPositions;
    public Transform CurrentTarget;
    public int HP;


    private void Update()
    {
        
    }


    


    public void AttackEnemy(Transform target, bool charged)
    {
        if (charged)
        {
            target.gameObject.GetComponent<EnemyController>().Knockbacked(knockbackForce * 15);
        }
        else
        {
            target.gameObject.GetComponent<EnemyController>().Knockbacked(knockbackForce);
        }
    }

    
}
