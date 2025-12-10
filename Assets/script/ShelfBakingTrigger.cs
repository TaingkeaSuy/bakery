using UnityEngine;

public class ShelfBakingTrigger : MonoBehaviour
{
    public GameObject bakingUI;   // The UI panel you want to show

    private bool playerInRange = false;

    void Update()
    {
        // If player is nearby and presses B
        if (playerInRange && Input.GetKeyDown(KeyCode.B))
        {
            // Toggle UI
            if (bakingUI.activeSelf)
                CloseBakingUI();
            else
                OpenBakingUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            CloseBakingUI();    // Make sure UI closes when walking away
        }
    }

    void OpenBakingUI()
    {
        bakingUI.SetActive(true);
    }

    void CloseBakingUI()
    {
        bakingUI.SetActive(false);
    }
}
