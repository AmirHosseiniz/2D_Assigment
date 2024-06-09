using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this game resource helps us to store and track of the highest coin amount collected 

[CreateAssetMenu(menuName = "GameResources/PlayerCoin_HighScore")]
public class PlayerCoin_HighScore : SimpleGameResource<PlayerCoin_HighScore, float>
{
    protected override string PrefsKey => "PlayerCoin_HighScore";

    protected override float LoadValue() => PlayerPrefs.GetFloat(PrefsKey, defaultValue);

    protected override void SaveValue() => PlayerPrefs.SetFloat(PrefsKey, value);
}
public partial class GameResourceManager : MonoBehaviour
{
    public PlayerCoin_HighScore coin_HighScore;
}