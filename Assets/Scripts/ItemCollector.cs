using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int coinCount = 0;
    [SerializeField] TMP_Text coinsText;
    [SerializeField] AudioSource collectSound;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            collectSound.Play();
            coinCount++;
            coinsText.text = "Coins: " + coinCount;
        }    
    }
}
