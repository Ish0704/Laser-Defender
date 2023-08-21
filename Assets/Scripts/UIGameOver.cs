using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Start()
    {
        scoreText.text = "YOUR SCORE IS:\n"+scoreKeeper.GetScore();
    }
}
