using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Script : MonoBehaviour
{
   public dailougeScript Hell;
	public DailougeDisplayer Devil;  
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other)
   {
		if(other.gameObject.tag.Equals("player")) 
		{
			
			other.SendMessage("ActivateCue",true);
			Debug.Log("Player Has enterd");
			
			
		}
   }

   private void OnTriggerExit2D(Collider2D other)
   {
		if(other.gameObject.tag.Equals("player")) 
		{
			
			other.SendMessage("ActivateCue",false);
			Debug.Log("Player Has exit");
			
		}
   }

   private void Interact()
	{
		Devil.StartDailougeScript(Hell);
	}
}
