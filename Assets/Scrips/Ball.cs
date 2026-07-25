using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BallColor
{ White,
    Rad,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black
}
public class Ball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int point;

    [SerializeField]
    private BallColor color;

    [SerializeField]
    private MeshRenderer rd;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);
        GameManager.instance.PlayerScore+ point
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd= GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetColorAndPoint(BallColor col)
    {
        switch (col)
        {
            case BallColor.White:
                Point = 0;
                rd.material.color = Color.white;
                break;

            case BallColor.Yellow:
                Point = 1;
                rd.material.color = Color.yellow;
                break;

            case BallColor.Green:
                Point = 2;
                rd.material.color = Color.green;
                break;

            case BallColor.Brown:
                Point = 3;
                rd.material.color = Color.brown;
                break;

            case BallColor.Blue:
                Point = 4;
                rd.material.color = Color.blue;
                break;

            case BallColor.Pink:
                Point = 5;
                rd.material.color = Color.pink;
                break;

            case BallColor.Black:
                Point = 6;
                rd.material.color = Color.black;
                break;
        }
    }
