using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy reached goal");
            GameManager.Instance.Damaged(other.gameObject.GetComponent<EnemyController>().Damage);
            other.gameObject.GetComponent<EnemyController>().Died();
        }
    }

}
