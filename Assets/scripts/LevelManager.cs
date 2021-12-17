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


    private AudioSource audioSource;
    [SerializeField] AudioClip bookCollectionSound;

    /*
     * unused due to enemy not working
    static private int maxHearts = 3; // number of hits
    private int currHearts; // current hearts
    [SerializeField] Image[] lives = new Image[maxHearts]; // heart icons
    [SerializeField] Sprite emptyHeart;
    */

    private void Update()
    {
        // pause menu
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
        // currHearts = maxHearts;
        instance = this;
        audioSource = GetComponent<AudioSource>();
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

        // play sound here because book get destroyed before audio finishes
        audioSource.PlayOneShot(bookCollectionSound);

        if (currBooks > 9) // avoid weird formatting when at 2 digits
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
            // todo
            _WinGame();
        }
    }

    // display a message to the winner about their score
    private void _WinGame()
    {
        player.GetComponent<CharacterMotor>().canControl = false;
        winPanel.SetActive(true);
        MouseLook.paused = true;
        scoreText.color = Color.white;
    }

    private void _TogglePause(bool pausing)
    {
        this.pausing = pausing;
        pausePanel.SetActive(pausing);
        if (pausing)
        {
            player.GetComponent<CharacterMotor>().canControl = false;
            MouseLook.paused = true;
            scoreText.color = Color.white;
        } else {
            player.GetComponent<CharacterMotor>().canControl = true;
            MouseLook.paused = false;
            scoreText.color = Color.black;
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


    // player takes damage
    /*
    public static void Damaged()
    {
        instance._Damaged();
    }
    
    // remove heart icons from UI for each hit taken
        // unused due to enemy
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
