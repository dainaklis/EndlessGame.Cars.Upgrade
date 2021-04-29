using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   

    [SerializeField] private float speedVertical;
    [SerializeField] private float speedHorizontal;
    private float moveHorizontal;
    private float moveVertical;



    //TOUCH FROM CHARGER GAMES
    [SerializeField] private float speedTouch;




    private Rigidbody2D playerRb;
    



    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //MoveDirection();
    }

    private void FixedUpdate() 
    {
        //MoveVertical();
        //MoveHorizontal();

        TouchInput();
    }

    //-------------------------------METODAI-----------------------------------------------

    private void MoveDirection()
    {
        //PC versija
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");
    }
    private void MoveVertical()
    {   
        //PC versija
        playerRb.velocity = new Vector2(playerRb.velocity.x, speedVertical * moveVertical);
    }

    private void MoveHorizontal()
    {
        //PC versija
        playerRb.velocity = new Vector2(moveHorizontal * speedHorizontal, playerRb.velocity.y);
    }

    private void TouchInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x > 1)
            {
                //playerRb.velocity = new Vector2(mousePos.x * speedTouch, playerRb.velocity.y);
                transform.Translate(speedTouch, 0, 0);
            }
            else if (mousePos.x < -1)
            {
                //playerRb.velocity = new Vector2(-mousePos.x * speedTouch, playerRb.velocity.y);
                transform.Translate(-speedTouch, 0, 0);
            }
        }


    }




}
