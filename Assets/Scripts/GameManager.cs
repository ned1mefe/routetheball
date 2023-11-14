using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Player player;
    private List<Checkpoint> checkpoints;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        GameObject[] checkpointObjects = GameObject.FindGameObjectsWithTag("Checkpoint");
        checkpoints = new List<Checkpoint>();
        foreach (GameObject checkpointObject in checkpointObjects)
        {
            checkpoints.Add(checkpointObject.GetComponent<Checkpoint>());
        }

        player = new Player();
        player.Instantiate();
    }

    public void PlayerDie()
    {
        player.loseHealth();

        foreach (var checkpoint in checkpoints)
        {
            checkpoint.Reset();
        }
    }

    public void CheckPlayerWin()
    {
        if (checkpoints.All(checkpoint => checkpoint.achieved)) Win();
    }
    private void Win()
    {
        var ball = FindAnyObjectByType<Ball>();

        ball.WinEffect();
    }
    
}
