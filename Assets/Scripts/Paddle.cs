using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits = 16f; //Screen hight = 6*2 = 12 unity --> aspect ratio 4:3 --> screen width = 16 units
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    float MousePosInUnitsX;
    //bool shrinkPaddle;!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MousePosInUnitsX = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(MousePosInUnitsX, minX, maxX);
        transform.position = paddlePos;
    }
}
