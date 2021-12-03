using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    static public LevelManager instance;
    [SerializeField] GameObject player; // reference to the player

    static private int maxRooms = 4;
    [SerializeField] GameObject[] itemRooms = new GameObject[maxRooms]; // list of possible item spawn locations
    private int roomsIdx; // next free spot in the rooms list

    static private int maxHearts = 3; // number of hits
    private int currHearts; // current hearts
    [SerializeField] Image[] lives = new Image[maxHearts]; // heart icons
    [SerializeField] Sprite emptyHeart;

    static public int winCondition = 3; // number of keys needed
    private int currKeys; // current hearts
    [SerializeField] Image[] keys = new Image[winCondition]; // key icons


    private void Awake()
    {
        // init vars
        currHearts = maxHearts;
        instance = this;
        roomsIdx = 0;
    }

    // add a room to the list of rooms
    public static void AddRoom(GameObject room)
    {
        instance._AddRoom(room);
    }

    private void _AddRoom(GameObject room)
    {
        itemRooms[roomsIdx] = room;
        roomsIdx += 1; 

        // on the last room the idx will be increased and match maxRooms
            // when the last room is added spawn the items
        if (roomsIdx == maxRooms)
        {
            // spawn some items in the last few item rooms
                // took long to add to more rooms away from the center
            for(int i = winCondition; i >= 1; i--)
            {
                itemRooms[i].GetComponent<ItemRoom>().SpawnItem();
            }
        }
    }

    //TODO: keys collected UI
    
    // player takes damage
    public static void Damaged()
    {
        instance._Damaged();
    }

    // display win screen
    public static void WinGame()
    {
        instance._WinGame();
    }

    // private method to increase score
    private void _IncreaseScore()
    {
        currKeys += 1;
        //scoreText.text = "Croissants: " + currKeys.ToString() + "/" + winCondition.ToString();
        checkWin();
    }

    // remove heart icons from UI for each hit taken
    private void _Damaged()
    {
        currHearts--;

        // make heart an empty heart sprite after taking damage
        lives[currHearts].sprite = emptyHeart;

        // reload the game if at zero hearts
        // TODO - pop up lost screen?
            // return at hallway or new run options
        if (currHearts == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    // check that the minimum score to win has been achieved
    private void checkWin()
    {
        // open the door if score is enough
        if (currKeys == winCondition)
        {
            // todo

        }
    }

    // display a message to the winner about their score
    private void _WinGame()
    {
        //todo
    }
}
