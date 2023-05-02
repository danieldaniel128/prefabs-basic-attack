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
  [SerializeField] private GameObject player;
  [SerializeField] private TextMeshProUGUI HPText;
  
  private int HP;
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

    HP = player.GetComponent<PlayerController>().HP;
    HPText.text = "HP: " + HP;
  }
  
  public void Damaged(int damage)
  {
    HP-= damage;
    Debug.Log("damaged by " + damage + " HP is " + HP + "");
    HPText.text = "HP: " + HP;
    if (HP <= 0)
    {
      Debug.Log("Game Over");
      HPText.text = "HP: " + 0;
    }
  }
}
