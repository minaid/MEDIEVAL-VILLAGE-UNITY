using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1 : MonoBehaviour {

	private GameObject triggeringNpc;
	private bool triggering;
	public GameObject npcText;
	public Text my_text = null;
	public Text obj_text = null;

	
	private int text_flag=0;

    public Guide guide;

    public AudioClip hmmClip;                                          // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Start(){
		
	}
	
	void Update(){
		if(triggering){
			npcText.SetActive(true);
			if(Input.GetKeyDown(KeyCode.E)){
				if (text_flag==0){
                    playerAudio.clip = hmmClip;
                    playerAudio.Play();
                    my_text.text = "Woah, you actually killed the monster!...";
					obj_text.text = "";

					text_flag = text_flag+1;
				}
				else if (text_flag==1){
					my_text.text = "You just saved our village from a lot of trouble...";
					text_flag = text_flag+1;
				}
				else if (text_flag==2){
					my_text.text = "Here is your reward, 100 coins...";
					text_flag = text_flag+1;
					obj_text.text = "100 coins added to your inventory";

				}
				else if (text_flag==3){
					my_text.text = "Use it wisely...";
					text_flag = text_flag+1;
				}
                else if (text_flag == 4)
                {
                    my_text.text = "We just heard, that another monster appeared,";
                    text_flag = text_flag + 1;
                }
                else if (text_flag == 5)
                {
                    my_text.text = "just outside the castle!";
                    text_flag = text_flag + 1;
                }
                else {
					
                    my_text.text = "Please save us...";
                    obj_text.text = " Follow the knight and slay the monster.";
                    guide.Objective_flag = 1;
                }
			}
		}
		else{
			npcText.SetActive(false);
		}
		
		
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag=="NPC"){
			triggering = true;
			triggeringNpc = other.gameObject;
			
		}
		
	}
	
	void OnTriggerExit(Collider other){
		if(other.tag=="NPC"){
			triggering = false;
			triggeringNpc = null;
			my_text.text = "[E] Talk to guard";

			
		}
		
	}
}
