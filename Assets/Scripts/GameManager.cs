using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Player player;
    private List<Checkpoint> checkpoints;
    private Ball ball;

    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private Vector3 ballReleasePosition;
    [SerializeField]
    private Vector2 ballReleaseVelocity;

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
    }

    public void PlayerDie()
    {
        player.loseHealth();

        foreach (var checkpoint in checkpoints)
        {
            checkpoint.Reset();
        }

        Destroy(ball);
        ball = null;
    }

    public void CheckPlayerWin()
    {
        if (checkpoints.All(checkpoint => checkpoint.achieved)) Win();
    }
    private void Win() => ball.WinEffect();
    public void ReleaseBall()
    {
        if (ball != null) return;

        Instantiate(ballPrefab, ballReleasePosition, Quaternion.identity);

        ball = FindObjectOfType<Ball>();

        ball.GetComponent<Rigidbody2D>().velocity = ballReleaseVelocity;
    }

}
