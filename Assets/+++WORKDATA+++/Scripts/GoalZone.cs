using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiManager != null)
            {
                uiManager.ShowWinPanel();
            }
            else
            {
                Debug.LogWarning("UIManager wurde nicht zugewiesen!");
            }
        }
    }
}