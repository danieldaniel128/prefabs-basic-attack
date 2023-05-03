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
  [SerializeField] private GameObject powBrownEffect;
  [SerializeField] private GameObject powBlueEffect;
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

    public void ActivateRandomPowEffect()
    {
        int randPow= UnityEngine.Random.Range(1, 3);
        if(randPow == 1)
            powBrownEffect.SetActive(true);
        else
            powBlueEffect.SetActive(true);
    }


    public IEnumerator WaitASecPowEffect()
    {
        yield return new WaitForSeconds(1);
        if(powBrownEffect.activeSelf)
            powBrownEffect.SetActive(false);
        if (powBlueEffect.activeSelf)
            powBlueEffect.SetActive(false);
    }

}
