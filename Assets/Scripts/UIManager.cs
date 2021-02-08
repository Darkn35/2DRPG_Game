using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Slider sanityBar;
    public Text sanityText;
    public PlayerSanityManager playerSanity;
    private static bool UIExists;
    // Start is called before the first frame update
    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        sanityBar.maxValue = playerSanity.playerMaxSanity;
        sanityBar.value = playerSanity.playerCurrentSanity;
        sanityText.text = "Sanity : " + playerSanity.playerCurrentSanity + "%";
    }
}
