using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance{ get; private set; }
  [SerializeField] private GameObject enemyGoal;
  [SerializeField] private GameObject enemyPrefab;
  public GameObject player;
  [SerializeField] private TextMeshProUGUI HPText;
  [SerializeField] private GameObject healthBar;

  private float HP;
  private float maxHP;
  private void Awake()
  {
    if (Instance != null && Instance != this) 
    { 
      Destroy(this);
    } 
    else 
    { 
      Instance = this; 
    }

    maxHP = player.GetComponent<PlayerController>().HP;
    HP = maxHP;
    HPText.text = "HP: " + maxHP;
    healthBar.gameObject.GetComponent<HealthBar>().HealthBarMethod(HP, maxHP);



  }

  public void Damaged(float damage)
  {
    HP-= damage;
    Debug.Log("damaged by " + damage + " HP is " + HP + "");
    HPText.text = "HP: " + HP;
    healthBar.gameObject.GetComponent<HealthBar>().HealthBarMethod(HP, maxHP);
    if (HP <= 0)
    {
      Debug.Log("Game Over");
      HPText.text = "HP: " + 0;
    }
  }
}
