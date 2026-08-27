using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore 
    { 
        get { return playerScore; } 
        set { playerScore = value; } 
    }

    [SerializeField]
    private GameObject[] ballPosition;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private float xInput = 0f;

  

    public static GameManager instance;

   void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"ballPosition length: {ballPosition?.Length ?? -1}");
        SetBall(BallColor.Black, 1);
        SetBall(BallColor.Blue, 2);
        SetBall(BallColor.Brown, 3);
        SetBall(BallColor.Green, 4);
        SetBall(BallColor.Pink, 5);
        SetBall(BallColor.Red, 6);
        SetBall(BallColor.Black, 7);
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.1f;

        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 0.1f;

        else
            xInput = 0f;

    }

    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab,
                                      ballPosition[i].transform.position,
                                      Quaternion.identity);

        Ball ballScript = obj.GetComponent<Ball>();
        if (ballScript != null)
        {
            ballScript.SetColorAndPoint(col);
        }
    }

    private void ShootBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddForce(Vector3.forward * 50, ForceMode.Impulse);

    }

    private void RotateBall()
    {
        if (cueBall != null) 
            cueBall.transform.Rotate(new Vector3(0f, xInput, 0f));
    }

    private void StopBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.linearVelocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }


}