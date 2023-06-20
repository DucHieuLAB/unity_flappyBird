using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Sprite[] digitSprites;

    public static ScoreDisplay instance;

    private void Awake()
    {
        instance = this;
    }
    public void UpdateScore(int score)
    {
        string scoreString = score.ToString();

        foreach (Transform child in transform)
        {
            {
                Destroy(child.gameObject);
            }
        }
        for (int i = 0; i < scoreString.Length; i++)
        {
            int digit = int.Parse(scoreString[i].ToString());
            GameObject digitObject = new GameObject("Digit");
            digitObject.transform.SetParent(transform);
            digitObject.transform.localPosition = new Vector3(-10, 450, 0);
            Image digitImage = digitObject.AddComponent<Image>();
            digitImage.sprite = digitSprites[digit]; 
        }
    }
}
