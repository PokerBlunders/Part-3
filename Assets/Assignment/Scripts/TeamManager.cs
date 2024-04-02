using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static int blueTeamCount = 0;
    public static int redTeamCount = 0;

    public TextMeshProUGUI blueTeamText;
    public TextMeshProUGUI redTeamText;

    public static void IncrementTeamCount(Team team)
    {
        if (team == Team.Blue)
        {
            blueTeamCount++;
        }
        else if (team == Team.Red)
        {
            redTeamCount++;
        }
    }

    private void Update()
    {
        blueTeamText.text = TeamManager.blueTeamCount.ToString();
        redTeamText.text = TeamManager.redTeamCount.ToString();
    }
}
