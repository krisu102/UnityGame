using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour {

    public float timeLeft;
    public GameObject timeLeftUI;
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft); 

        if(timeLeft < 0.1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
