using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    static public LevelManager instance;
    [SerializeField] GameObject player; // reference to the player

    static private int maxHearts = 3; // number of hits
    private int currHearts; // current hearts
    [SerializeField] Image[] lives = new Image[maxHearts]; // heart icons
    [SerializeField] Sprite emptyHeart;

    static public int roomCount;  // number of rooms with books
    private int currBooks; // current hearts
    [SerializeField] Text scoreText; // visible score


    [SerializeField] GameObject winPanel;

    private void Awake()
    {
        // init vars
        currHearts = maxHearts;
        instance = this;
    }

    // increment room count
    public static void AddRoom()
    {
        instance._AddRoom();
    }

    private void _AddRoom()
    {
        roomCount++;
    }
    
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

    // Book color corresponds to the idx in the keys list
    public static void IncreaseScore()
    {

        instance._IncreaseScore();
    }

    // private method to increase score
    private void _IncreaseScore()
    {
        currBooks += 1;
        if(currBooks > 9) // avoid weird formatting when at 2 digits
        {
            scoreText.text = "x  " + currBooks.ToString();
        }
        else
        {
            scoreText.text = "x " + currBooks.ToString();
        }
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
    public void checkWin()
    {
        // open the door if score is enough
        if (currBooks == roomCount)
        {
            // todo
            _WinGame();
        }
    }

    // TODO REMOVE - temp for video
    public void QuickWin()
    {
        while(currBooks <= roomCount)
        {
            IncreaseScore();
        }
    }

    // display a message to the winner about their score
    private void _WinGame()
    {
        //todo
        player.GetComponent<CharacterMotor>().canControl = false;
        winPanel.SetActive(true);
        scoreText.color = Color.white;
    }

    // reset for when replay button is clicked
    public static void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // load main menu when button is clicked
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
