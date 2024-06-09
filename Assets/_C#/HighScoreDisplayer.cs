using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        PlayerCoin_HighScore.Register(Display);

        Display(PlayerCoin_HighScore.Value);
    }

    private void OnDestroy()
    {
        PlayerCoin_HighScore.UnRegister(Display);
    }

    void Display(float value)
    {
        text.text = value.ToString();
    }
}
