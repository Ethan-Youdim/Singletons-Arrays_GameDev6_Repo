using UnityEngine;
using UnityEngine.InputSystem;

public class ClickScript : MonoBehaviour
{
    // Vairables:
    private Camera mainCam;

    //Awake is called pre frame 1 (before void start)

    private void Awake()
    {
        mainCam = Camera.main;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      // check if for left mouse click. call the ray cast function if it is clicked
      // Ray cast is a sensor - in this case it detects for a left mouse click 
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            RayCastHit();
        }  
    }

                // sense until it detects something 
    private void RayCastHit()
    {
        // get current mouse position
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // Conver screen position (mouse location) into a ray
        Ray ray = mainCam.ScreenPointToRay(mousePos);
    
    // cast a ray. if i hits something do something
    RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

    // if we dont hit nothing (we hit something)
    if (hit2D.collider != null)
        {
            //set the currentfood to the next number in the array:

            if(GameManagerS.instance.currentfoodnumber < GameManagerS.instance.shoppingArray.Length - 1) 
            // if currentfood number is less than the length (in bounds)
            {
                GameManagerS.instance.currentfoodnumber++; 
                // increment the currentfoodnumber by 1

                GameManagerS.instance.currentfood = GameManagerS.instance.shoppingArray[GameManagerS.instance.currentfoodnumber];  
                // the current food is set to the currentfoodnumber in the shopping array
             
             // then have a left mouse click make it go up in the array
            } else
            {
                GameManagerS.instance.currentfoodnumber = 0;
                // set number to zero
                GameManagerS.instance.currentfood = GameManagerS.instance.shoppingArray[0];
                // et array to zero 

            }
            // Debug.Log("Clicked on: " + hit2D.collider.name);
           // Debug.Log("Current food: " + GameManagerS.instance.currentfood);
        }

       
    }
}