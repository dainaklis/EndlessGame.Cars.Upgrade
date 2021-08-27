using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMovement : MonoBehaviour
{
    public static CarsMovement Instance;
	private Rigidbody2D carRb;

	//[SerializeField] private float accelerationPower = 5f;
	//[SerializeField] private float steeringPower = 5f;
	//private float steeringAmount, speed, direction;


    //TOUCH FROM CHARGER GAMES kitas is RICKY DEV
    [SerializeField] private float speedTouch;
    [SerializeField] private float xMargin;
    [SerializeField] private float yMarginForInput;


    private bool canMove;
	

    private void Awake() 
    {
        Instance = this;
    }
	void Start () 
    {
		carRb = GetComponent<Rigidbody2D> ();
        
	}

    private void Update() 
    {
        //TouchInput();
        
    }
	
	
	void FixedUpdate () 
    {

        //KeysVazineja();
        TouchInput();
			
	}
    
    // -----------------------------------------------------------------


    // private void KeysVazineja()
    // {
    //     steeringAmount = - Input.GetAxis ("Horizontal");
	// 	speed = Input.GetAxis ("Vertical") * accelerationPower;
	// 	direction = Mathf.Sign(Vector2.Dot (carRb.velocity, carRb.GetRelativeVector(Vector2.up)));
	// 	carRb.rotation += steeringAmount * steeringPower * carRb.velocity.magnitude * direction;

	// 	carRb.AddRelativeForce (Vector2.up * speed);

	// 	carRb.AddRelativeForce ( - Vector2.right * carRb.velocity.magnitude * steeringAmount / 2);
    // }



    private void TouchInput()
    {

        //---1 BUDAS------------------
        // if (Input.GetMouseButton(0))
        // {
        //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //     if (mousePos.x > 1)
        //     {
        //         //playerRb.velocity = new Vector2(mousePos.x * speedTouch, playerRb.velocity.y);
        //         transform.Translate(speedTouch * Time.deltaTime, 0, 0);
                
        //     }
        //     else if (mousePos.x < -1)
        //     {
        //         //playerRb.velocity = new Vector2(-mousePos.x * speedTouch, playerRb.velocity.y);
        //         transform.Translate(-speedTouch * Time.deltaTime, 0, 0);
        //     }
        // }

        
        // ---- 2 BUDAS----------------

        if (!canMove)
        {
            return;
        }

        int dirX = 0;
        transform.rotation = Quaternion.Euler(0,0,0);



        if (Input.touches.Length > 0)
        {
            Vector3 touchPosition = Input.touches[0].position;
            touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            if (touchPosition.y < yMarginForInput)
            {
                if (touchPosition.x > 0)
                {
                    dirX = 1; 
                    //PASISUKA MASINA 30 LAIPSNIU
                    //transform.rotation = Quaternion.Euler(0,0,-30);
                }
                else
                {
                    dirX = -1;
                    //transform.rotation = Quaternion.Euler(0,0,30);
                }
            }


        }

        //carRb.velocity = new Vector2(dirX * speedTouch * Time.deltaTime, 0);
        //NES FIXUPDATE tai TIME.fixedDeltatime  
        carRb.velocity = new Vector2(dirX * speedTouch * Time.fixedDeltaTime, 0); 

        float posX = transform.position.x;
        posX = Mathf.Clamp(posX, -xMargin, xMargin);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);    


    }

    public void StartMoveScript()
    {
        canMove = true;

        //KAI PERKI UPDATE PADIDEJA SPEDD SUKIMO
        int strongersOarsLevel = PlayerPrefs.GetInt(ShopItems.ShopItem.strongersOars.ToString());

        if (strongersOarsLevel > 0)
        {
            speedTouch += strongersOarsLevel *50;
        }
    }
}
