using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;

    [SerializeField]
    private GameObject[] ballPosition;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private float xInput = 0f;

    [SerializeField]
    private GameObject cam;

    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    public static GameManager instance;

    private void Awake()
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
        cameraBehindCueball();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            shootBall();
        }

        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.isPressed)
        {
            xInput = -.1f;
        }
        else if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.isPressed)
        {
            xInput = .1f;
        }
        else
        {
            xInput = 0f;
        }
        rotateBall();

        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            stopBall();
        }
    }

    private void SetBall(BallColor col, int i)
    {
        GameObject newBall = Instantiate(ballPrefab,ballPosition[i].transform.position,Quaternion.identity);

        Ball ballScript = newBall.GetComponent<Ball>();
        if (ballScript != null)
        {
            ballScript.SetColorAndPoint(col);
        }
    }

    private void shootBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddForce(Vector3.forward * 50, ForceMode.Impulse);
        cam.transform.parent = null;
        cam.transform.position = new Vector3(0f, 52f, 0f);
        cam.transform.eulerAngles = new Vector3(90f, 0f, 0f);
    }

    private void rotateBall()
    {
        if (cueBall != null) cueBall.transform.Rotate(new Vector3(0f, xInput, 0f));
    }

    private void stopBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.linearVelocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    private void cameraBehindCueball()
    {
        cam.transform.parent = cueBall.transform;
        cam.transform.position = cueBall.transform.position + new Vector3(0f, 7f, -15f);
        cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);
    }
}