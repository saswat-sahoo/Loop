﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
   public void Play()
    {
        SceneManager.LoadScene("level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
