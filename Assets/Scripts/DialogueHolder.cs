using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lastmilegames.DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        public GameObject notificationSquare;
        public GameObject thePlayer;
        [SerializeField] private DialoguePlayer dialoguePlayer;
        private bool canInteract;
        public SpeakerUI imagePortraits;
        public Sprite speakerLeft;
        public Sprite speakerRight;
        public GameObject speakerUIHolder;
        public DialogueContainer conversationDialogue;
        
        void Start()
        {
            notificationSquare.SetActive(false);
            canInteract = false;
            speakerUIHolder.SetActive(false);
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                canInteract = true;
                notificationSquare.SetActive(true);
                if (canInteract = true && Input.GetKey(KeyCode.Space))
                {
                    thePlayer.GetComponent<PlayerController>().canMove = false;
                    dialoguePlayer.PlayDialogue(conversationDialogue);
                    speakerUIHolder.SetActive(true);
                    speakerPortraits();
                }
            }
        }

        public void speakerPortraits()
        {
            imagePortraits.displayPortraits(speakerLeft, speakerRight);
        }

        void OnTriggerExit2D(Collider2D other)
        {
            canInteract = false;
            notificationSquare.SetActive(false);
        }
    }
}
