using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class CoinManager : MonoBehaviour
{
    [SerializeField] private int counterCoins = 0; 
    [SerializeField] private UIManager uIManager;

    public int coinCount = 0;
    public UIManager uiManeger;


    private void Start()
    {
        counterCoins = 0;
        uIManager.UpdateCoinText(counterCoins);
    }
    public void AddCoin()
    {
        counterCoins++;
        uIManager.UpdateCoinText(counterCoins);

        if (counterCoins >= 1)
        {
            uiManeger.ShowWinPanel();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible")) // Überprüfen, ob das Objekt ein Sammelobjekt ist
        {
            counterCoins++; // Zähle den gesammelten Gegenstand
            Destroy(other.gameObject); // Zerstöre das Sammelobjekt
        }
    }
}
