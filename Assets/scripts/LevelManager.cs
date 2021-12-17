using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    static public LevelManager instance;
    [SerializeField] GameObject player; // reference to the player

    static public int roomCount;  // number of rooms with books
    private int currBooks; // current hearts
    [SerializeField] Text scoreText; // visible score
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] bool pausing = false; // is the pause menu up

    // for playing the score sound
    private AudioSource audioSource;
    [SerializeField] AudioClip bookCollectionSound;

    /*
     * unused due to enemy not working
     * 
    static private int maxHearts = 3; // number of hits
    private int currHearts; // current hearts
    [SerializeField] Image[] lives = new Image[maxHearts]; // heart icons
    [SerializeField] Sprite emptyHeart;
    */

    private void Update()
    {
        // pause menu if pressed escape and the winpanel is not active
        if(Input.GetKeyDown("escape") && !winPanel.activeInHierarchy)
        {
            if(!pausing)
            {
                // turn on
                _TogglePause(true);
            } else {
                // turn off
                _TogglePause(false);
            }
        }
        
    }

    private void Awake()
    {
        // init vars
        // currHearts = maxHearts; // unsure due to no enemy
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // for when a room is spawned
    public static void AddRoom()
    {
        instance._AddRoom();
    }

    // increment private var room count
    private void _AddRoom()
    {
        roomCount++;
    }

    // display win screen
    public static void WinGame()
    {
        instance._WinGame();
    }

    // method that can be called by the collected book to increase the score
    public static void IncreaseScore()
    {
        instance._IncreaseScore();
    }

    // private method to increase score
    private void _IncreaseScore()
    {
        // increment score
        currBooks += 1;

        // play sound here because book get destroyed before audio finishes
        audioSource.PlayOneShot(bookCollectionSound);

        // avoid weird formatting when at 2 digits
        if (currBooks > 9) 
        {
            scoreText.text = "x  " + currBooks.ToString();
        }
        else
        {
            scoreText.text = "x " + currBooks.ToString();
        }
        checkWin();
    }

    // check that the minimum score to win has been achieved
    public void checkWin()
    {
        // open the door if score is enough
        if (currBooks == roomCount)
        {
            _WinGame();
        }
    }

    // display a message to the winner
    private void _WinGame()
    {
        // turn on the panel and prevent further movement
        winPanel.SetActive(true);
        player.GetComponent<CharacterMotor>().canControl = false;
        MouseLook.paused = true; // so the player cannot pause during winscreen
        scoreText.color = Color.white; // make score visible over black screen
    }

    // turn on/off the pause menu
        // pausing = true if player is pausing the game, false if not
    private void _TogglePause(bool pausing)
    {
        // update pausing bool and set panel active as needed
        this.pausing = pausing;
        pausePanel.SetActive(pausing);
        if (pausing) // game is being paused
        {
            // prevent player/camera motion
            player.GetComponent<CharacterMotor>().canControl = false;
            MouseLook.paused = true;
            scoreText.color = Color.white; // make score clearer over the black screen
        } else { // done pausing

            // enable player/camera motion
            player.GetComponent<CharacterMotor>().canControl = true;
            MouseLook.paused = false;
            scoreText.color = Color.black; // retun to score to orignal
        }
        
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

    /*
     * unused due to enemy, but was developed for when enemy attacked the player
     * 
    // player takes damage
    public static void Damaged()
    {
        instance._Damaged();
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

    }*/
}
