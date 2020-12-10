using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject otherObject;
	private GameObject triggeringNpc;
	private bool triggering;
	public GameObject npcText;
	public Text my_text = null;
	public Text objective_text = null;
    private int text_flag = 0;

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
					my_text.text = "Welcome to our small village traveller...";
					objective_text.text = "";
					text_flag = text_flag+1;
                    playerAudio.clip = hmmClip;
                    playerAudio.Play();
                }
				else if (text_flag==1){
					my_text.text = "You may go in, but be careful not to cause us any trouble...";
					text_flag = text_flag+1;
				}
				else if (text_flag==2){
					my_text.text = "Oh and if you are brave enough,i may have a job for you...";
					text_flag = text_flag+1;
				}
				else if (text_flag==3){
					my_text.text = "Just come and talk to me when you are ready!";
					objective_text.text = "Objective: Explore the village, and talk to the guard when you are ready";
					text_flag = text_flag+1;
				}
				else if (text_flag==4){
                    playerAudio.clip = hmmClip;
                    playerAudio.Play();
                    my_text.text = "Hello again, so about that job i was talking about...";
					objective_text.text = "";
					text_flag = text_flag+1;
				}
				else if (text_flag==5){
					my_text.text = "So there is a monster in our tavern's cellar...";
					text_flag = text_flag+1;
				}
				else if (text_flag==6){
					my_text.text = "And we have not been able to defeat it...";
					text_flag = text_flag+1;
				}
				else if (text_flag==7){
					my_text.text = "The tavern should be on your right once you enter the village...";
					text_flag = text_flag+1;
				}
				else if (text_flag==8){
					my_text.text = "If you defeat it we will reward you generously,here is the key!";
					text_flag = text_flag+1;
				}
				else if (text_flag==9){
					my_text.text = "Here is the key to the cellar!";
					objective_text.text = "You now have the cellar key";

					text_flag = text_flag+1;
				}
				else{
					my_text.text = "Come back for your reward once you defeat the monster!";
					objective_text.text = "Objective: Slay the monster in the tavern's cellar";
					otherObject.GetComponent<flag>();
					otherObject.GetComponent<flag>().enabled = false;

                    guide.Objective_flag = 1;
                }
			}
		}
		else{
			npcText.SetActive(false);
		}}
	void OnTriggerEnter(Collider other){
		if(other.tag=="NPC"){
			triggering = true;
			triggeringNpc = other.gameObject;
			
		}	}
	void OnTriggerExit(Collider other){
		if(other.tag=="NPC"){
			triggering = false;
			triggeringNpc = null;
			my_text.text = "[E] Talk to guard";

			
		}}}
