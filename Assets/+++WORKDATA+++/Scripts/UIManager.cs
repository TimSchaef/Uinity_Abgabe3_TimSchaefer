using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCounterCoin;

    [SerializeField] private GameObject panelLost;
    
    [SerializeField] Button buttonreloadLevel;
    [SerializeField] Button buttonreloadLevel1;
    
    [SerializeField] public GameObject winPanel;
    
    public TextMeshProUGUI timerText;         // Laufender Timer im HUD
    public TextMeshProUGUI finalTimeTextWin;  // Finale Zeit im Win-Panel
    public TextMeshProUGUI finalTimeTextLose; // Finale Zeit im Lose-Panel

    private float elapsedTime = 0f;
    private bool isRunning = false;

//--------------------------START OF TIMER---------------------------------------------------

    
    void Start()
    {
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Zeit: " + elapsedTime.ToString("F2") + "s";
        }
    }

    public void StopAndShowFinalTime(bool didWin)
    {
        isRunning = false;
        string finalTime = "Deine Zeit: " + elapsedTime.ToString("F2") + "s";

        if (didWin && finalTimeTextWin != null)
        {
            finalTimeTextWin.text = finalTime;
        }
        else if (!didWin && finalTimeTextLose != null)
        {
            finalTimeTextLose.text = finalTime;
        }
    }
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
    
   

    
    
    //-----------------------------------End of Timer------------------------------------------

    private void start()
    {
        winPanel.SetActive(false);
        UpdateCoinText(0);
    }
    public void UpdateCoinText(int newCoinCount)
    {
        textCounterCoin.text = newCoinCount.ToString();

        textCounterCoin.text = "Value: " + newCoinCount;
    }

    public void ShowPanelLost()
    {
        panelLost.SetActive(true);
        buttonreloadLevel.onClick.AddListener(ReloadLevel);
        StopAndShowFinalTime(false);

    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        buttonreloadLevel1.onClick.AddListener(ReloadLevel);
        StopAndShowFinalTime(true);
    }
    
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    
    public void OnStartClick()
    {
        SceneManager.LoadScene("GameScene");
        
    }
   
    public void OnStartClick1()
    {
        SceneManager.LoadScene("StartScene");
    }
    
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
            
}







