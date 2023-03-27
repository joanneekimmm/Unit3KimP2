using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //store our score value and reference our player
    public float score;
    private PlayerController playerControllerScript;

    public Transform startingPoint;
    public float lerpSpeed;
    
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;

        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerControllerScript.gameOver)
        {
            if (playerControllerScript.doubleSpeed)
            {
                score += 2;
            }
            else
            {
                score++;
            }
            Debug.Log("Score: " + score);
        }
    }

    IEnumerator PlayerIntro()
    {
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;
        float journerLength = Vector3.Distance(startPos, endPos);
        float startTime = startTime.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journerLength;

        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time = startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journerLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }

        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        playerControllerScript.gameOver = false;
    }
}
