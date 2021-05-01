using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits = 16f; //Screen hight = 6*2 = 12 unity --> aspect ratio 4:3 --> screen width = 16 units
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    
    
    //Cached References
    GameSession gameSession;
    Ball ball;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        }
    }
}
