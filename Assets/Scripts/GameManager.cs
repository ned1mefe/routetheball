using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Player player;
    private List<Checkpoint> checkpoints;
    private static Ball ball = null;

    [SerializeField]
    private GameObject ballPrefab;

    private readonly short ballReleaseVelocity = 2;
    private readonly short ballLaunchVelocity = 5;

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

        #region Preparing Checkpoints

        GameObject[] checkpointObjects = GameObject.FindGameObjectsWithTag("Checkpoint");
        checkpoints = new List<Checkpoint>();
        foreach (GameObject checkpointObject in checkpointObjects)
        {
            checkpoints.Add(checkpointObject.GetComponent<Checkpoint>());
        }
        #endregion

        player = new Player();
        player.Instantiate();

        ball = null;
    }

    public void PlayerDie()
    {
        player.loseHealth();

        foreach (var checkpoint in checkpoints)
        {
            checkpoint.Reset();
        }

        Destroy(ball.gameObject);
    }

    public void CheckPlayerWin()
    {
        if (checkpoints.All(checkpoint => checkpoint.achieved)) Win();
    }
    private void Win() => ball.WinEffect();
    public void ReleaseBall()
    {
        if (ball != null) return;

        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        short multiplier = (spawner.name == "Releaser") ? ballReleaseVelocity : ballLaunchVelocity;
        Vector2 direction = spawner.transform.up;
        Vector2 ballVelocity = direction * multiplier;
        
        
        Vector3 ballReleasePosition = spawner.transform.position;

        GameObject newBallObject = Instantiate(ballPrefab, ballReleasePosition, Quaternion.identity);
        ball = newBallObject.GetComponent<Ball>();


        ball.GetComponent<Rigidbody2D>().velocity = ballVelocity;
    }

}
