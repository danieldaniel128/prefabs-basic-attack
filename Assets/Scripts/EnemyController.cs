using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;

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
    
}
