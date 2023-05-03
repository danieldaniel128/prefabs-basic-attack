using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    //[SerializeField] float _movementSpeed;
    public Transform EnemyGoal;
    [SerializeField] private Transform enemy;
    [SerializeField] private float durationToReachGoal;
    [SerializeField] private float speed = 2;
    [SerializeField] private float maxCharge;
    [SerializeField] private float timeToCharge;
    private bool Charged = false;
    public float Damage;

    private void Start()
    {
        _playerController = GameManager.Instance.player.GetComponent<PlayerController>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            float startTimer;
            _playerController.CurrentTarget = transform;
        }
        //_playerController.AttackEnemy(transform, Charged);

        if (Input.GetMouseButtonUp(0))
        { 
            Debug.Log("<color=red>Pressed on enemy</color>");
            _playerController.AttackEnemy(transform, Charged);
            foreach (var lane in _playerController.Lanes) 
            {
                if(lane.position.x == _playerController.CurrentTarget.position.x)
                {
                    _playerController.transform.position = new Vector3(lane.position.x, _playerController.transform.position.y, _playerController.transform.position.z);
                    _playerController.Animator.SetTrigger("IsAttacking");
                    GameManager.Instance.ActivateRandomPowEffect();
                    StartCoroutine(GameManager.Instance.WaitASecPowEffect());
                }

            }


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
        transform.position += new Vector3(0,0,Time.deltaTime* -speed);
        if (EnemyGoal.position.z >= enemy.position.z)
         {
             GameManager.Instance.Damaged(Damage);
             Died();
         }
         
    }
    public void Knockbacked(float knockbackForce)
    {
        float posZ = transform.position.z;
        transform.position = new Vector3(transform.position.x, transform.position.y, posZ +  knockbackForce);
    }
}
