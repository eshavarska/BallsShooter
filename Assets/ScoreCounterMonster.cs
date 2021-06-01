using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class ScoreCounterMonster : MonoBehaviour
{
    private TextMeshProUGUI scoreCounterText;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounterText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounterText.text = Monster.EatenBalls.ToString();
    }
}
