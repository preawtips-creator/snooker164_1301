using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private int n = 1;
    private float timer = 0f;

    private void Awake()
    {
        Debug.Log("Awake");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        n++;

        if(timer >= 1f)
        {
            Debug.Log(n);
            n= 0;
        }
    }
}
