using System.Drawing;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;

    [SerializeField]
    private GameObject ballPosition;

    [SerializeField]
    private GameObject ballPrefab;
    public int PlayerScore {  get { return playerScore; }set { playerScore = value; } }


    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       SetBall(BallColor.Rad )
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void SetBall(BallColor col,int i)
    {
        Instantiate(ballPrefab,
            ballPosition[i].tranform.position,
            Quaternion.identity);
    }
}
