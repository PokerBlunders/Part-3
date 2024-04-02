using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static int blueTeamKills = 0;
    public static int redTeamKills = 0;

    public TextMeshProUGUI blueTeamText;
    public TextMeshProUGUI redTeamText;

    public static void IncrementTeamKills(Team team)
    {
        if (team == Team.Blue)
        {
            redTeamKills++;
        }
        else if (team == Team.Red)
        {
            blueTeamKills++;
        }
    }

    private void Update()
    {
        blueTeamText.text = blueTeamKills.ToString();
        redTeamText.text = redTeamKills.ToString();
    }
}
