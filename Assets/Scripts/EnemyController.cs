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
    public int Damage;

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            _playerController.CurrentTarget = transform;
        

        if (Input.GetKey(KeyCode.Mouse0))
        { 
            
            _playerController.ChargeCooldown += Time.deltaTime;
            Debug.Log("<color=red>Pressed on enemy</color>");
            _playerController.AttackEnemy(transform);
        }
    }

    private void Awake()
    {
        EnemyGoal = GameObject.FindWithTag("EnemyGoal").transform;
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
         
    }
}
