﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineRiggere : MonoBehaviour
{
	public PlayableDirector playableDirector;
    

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
			playableDirector.Play();
		}
	}
}
