using UnityEngine;

public class Hole : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball == null) return;

        GameManager.instance.PlayerScore += ball.Point;
        Destroy(ball.gameObject);
    }
}