using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float MaxCharge;
    public float ChargeTimer;

    [SerializeField] private float _damage;

    [SerializeField] private float knockbackForce;

    public Transform[] Lanes;
    
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
            Debug.Log("charged attack: " + knockbackForce);
            target.gameObject.GetComponent<EnemyController>().Knockbacked(knockbackForce * 15);
        }
        else
        {
            Debug.Log("attack: " + knockbackForce);
            target.gameObject.GetComponent<EnemyController>().Knockbacked(knockbackForce);
        }
    }

    
}
