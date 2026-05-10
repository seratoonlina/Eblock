using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pluginSystem : MonoBehaviour
{

    public GameObject GUIWarningRed;
    public GameObject GUIWarningBlue;
    public GameObject GUIButtonStart;
    public GameObject GUIButtonStartB;
    public GameObject check1;
    public GameObject check2;
    public int gamepadPlugin;
    InputMenu PlayTheGame;
    
    public static Gamepad player1;
    public static Gamepad player2;

    void OnEnable()
    {
        PlayTheGame.Enable();
    }

    void Awake()
    {
        PlayTheGame = new InputMenu();
    }

    void Update()
    {
        foreach (var gamepad in Gamepad.all)
        {
            if (gamepad.buttonNorth.wasPressedThisFrame)
            {
                // Kalau belum ada Player 1
                if (player1 == null)
                {
                    player1 = gamepad;
                    Debug.Log("Player 1 join!");
                    check1.GetComponent<Image>().color = Color.green;
                }
                // Kalau Player 1 sudah ada, isi Player 2
                else if (player2 == null && gamepad != player1)
                {
                    player2 = gamepad;
                    Debug.Log("Player 2 join!");
                    check2.GetComponent<Image>().color = Color.green;
                }
            }
        }

        OnDeviceChange();
    }


    void OnDeviceChange()
    {
         gamepadPlugin = Gamepad.all.Count;
         if (gamepadPlugin >= 2)
         {
            GUIButtonStartB.GetComponent<Image>().color = Color.white;
            Debug.Log("gamepad Sudah 2!");
            GUIWarningBlue.GetComponent<TextMeshProUGUI>().text = "READY";
            GUIWarningRed.GetComponent<TextMeshProUGUI>().text = "READY";
            GUIButtonStart.GetComponent<TextMeshProUGUI>().text = "READY";
         }
         else if (gamepadPlugin == 1)
         {
            GUIButtonStartB.GetComponent<Image>().color = Color.blue;
            Debug.Log("gamepad masih 1...");
            GUIWarningBlue.GetComponent<TextMeshProUGUI>().text = "OFF";
            GUIWarningRed.GetComponent<TextMeshProUGUI>().text = "READY";
            GUIButtonStart.GetComponent<TextMeshProUGUI>().text = "NEED 1 PLUGIN BEFORE PLAYING";
         }
         else if(gamepadPlugin < 1)
         {
            GUIButtonStartB.GetComponent<Image>().color = Color.red;
            Debug.Log("Belum Terpasang");
            GUIWarningBlue.GetComponent<TextMeshProUGUI>().text = "OFF";
            GUIWarningRed.GetComponent<TextMeshProUGUI>().text = "OFF";
            GUIButtonStart.GetComponent<TextMeshProUGUI>().text = "NEED 2 PLUGIN BEFORE PLAYING";
         }
           
    }

    public void PlayNow()
    {
        if (gamepadPlugin >= 2)
        {
            StartLoading();
        }
        else if (gamepadPlugin < 2)
        {
            NotStarting();
        }
    }

    void StartLoading()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void NotStarting()
    {
        Debug.Log("need 2 gamepad");
    }
}
