using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeddleMove : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits = 16f;
    float MousePosInUnitsX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MousePosInUnitsX = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        Vector2 paddlePos = new Vector2(MousePosInUnitsX, transform.position.y);
        transform.position = paddlePos;
    }
}
