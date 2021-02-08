using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpeakerUI : MonoBehaviour
{
    public TMP_Text speakerName;
    public Image speakerLeftUI;
    public Image speakerRightUI;

    void transparentImages(float color)
    {
        var transparentColorLeft = speakerLeftUI.color;
        transparentColorLeft.a = color;
        speakerLeftUI.color = transparentColorLeft;

        var transparentColorRight = speakerRightUI.color;
        transparentColorRight.a = color;
        speakerRightUI.color = transparentColorRight;
    }

    public void displayPortraits(Sprite speakerLeft, Sprite speakerRight)
    {
        speakerLeftUI.sprite = speakerLeft;
        speakerRightUI.sprite = speakerRight;
    
        if (speakerName.text == "Narrator") 
        {
            transparentImages(0f);
        }
        else 
        {
            transparentImages(255f);
        }
    }
}
