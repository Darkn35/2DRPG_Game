using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSanityManager : MonoBehaviour
{
    public int playerMaxSanity;
    public int playerCurrentSanity;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentSanity = playerMaxSanity;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentSanity <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void hurtPlayer(int damageToGive)
    {
        playerCurrentSanity -= damageToGive;
        Debug.Log("Health : " + playerCurrentSanity);
    }

    public void healPlayer(int healToGive)
    {
        if (playerCurrentSanity >= playerMaxSanity)
        {
            Debug.Log("Sanity is currently full");
        }
        else
        {
            playerCurrentSanity += healToGive;
            Debug.Log("Sanity : " + playerCurrentSanity);
        }
    }

    public void setMaxSanity()
    {
        playerCurrentSanity = playerMaxSanity;
    }
}
