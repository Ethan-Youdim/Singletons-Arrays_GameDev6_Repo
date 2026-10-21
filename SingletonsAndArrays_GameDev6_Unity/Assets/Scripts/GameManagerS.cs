using UnityEngine;
using TMPro;

public class GameManagerS : MonoBehaviour
{
    // Vairables:

    public TextMeshProUGUI foodtext;

    public string currentfood;

    // the number we are are on in the array
    public int currentfoodnumber = 0;

    // make an array that will hold strings *in Unity an array is called a list
    public string[] shoppingArray = new string[10] // defining an array
    {"Saffron","Milk","Bread","Eggs","Cheese","Oil","Ham","Noodles","Bacon","KinderBeuno"}; // < WHAT????
    
    // Singleton:

    public static GameManagerS instance;

    // Awake is called when the scripts iniates pre frame 1 before void start

    private void Awake()
    {
        // if there is not an instanse of this script in the game, make this the main instanse
        if(instance == null)
        {
            instance = this;
            // do NOT destory(get rid of) this object when i load up a new/different scene (gets put in folder as well)
            DontDestroyOnLoad(gameObject);
        }else // if there are duplicates
        {
            // Destroy all duplicates except the main instance
            Destroy(gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        currentfood = shoppingArray[currentfoodnumber];
    }

    // Update is called once per frame
    void Update()
    {
        foodtext.text = currentfood;
    }
}