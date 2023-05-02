using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    public Transform EnemyGoal;
    [SerializeField] private Transform enemy;
    [SerializeField] private float durationToReachGoal;
    [SerializeField] private float speed = 2;
    [SerializeField] private float maxCharge;
    [SerializeField] private float timeToCharge;
    private float currentCharge;
    private bool Charged = false;
    public float Damage;

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            float startTimer;
         _playerController.CurrentTarget = transform;
         currentCharge += Time.deltaTime ;
         
            if (currentCharge >= maxCharge)
            {
                Charged = true;
                Debug.Log("max charge");
            }
            
        }
         
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 
            
            _playerController.ChargeCooldown += Time.deltaTime;
            Debug.Log("<color=red>Pressed on enemy</color>");
            _playerController.AttackEnemy(transform, Charged);
            Charged = false;
        }
        
    }
 

    private void Awake()
    {
        EnemyGoal = GameObject.FindWithTag("EnemyGoal").transform;
        Destroy(gameObject, 7);
    }

    public void Died()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, EnemyGoal.position.z), speed * Time.deltaTime);
        if (EnemyGoal.position.z >= enemy.position.z)
         {
             GameManager.Instance.Damaged(Damage);
             Died();
         }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            currentCharge = 0;
        }
         
    }
    public void Knockbacked(float knockbackForce)
    {
        float posZ = transform.position.z;
        transform.position = new Vector3(transform.position.x, transform.position.y, posZ +=  knockbackForce);
    }
}
