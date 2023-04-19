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
    //[SerializeField] private Transform[] _enemiesPositions;
    public Transform CurrentTarget;
    public float HP;
    [SerializeField] GameObject FuckYouText;


    private void Update()
    {
        
    }


    


    public void AttackEnemy(Transform target) 
    {
       target.gameObject.SetActive(false);
        FuckYouText.SetActive(true);
    }




}
