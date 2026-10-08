using UnityEngine;

public class FuelReset : MonoBehaviour
{

    BoxCollider2D fuelCollider;
    AudioManager audioManager;
    FuelController fuelController;
    void Start()
    {
        fuelCollider = GetComponent<BoxCollider2D>();
        fuelController = FindFirstObjectByType<FuelController>();
        audioManager = AudioManager.Instance;
    }

    private void Update()
    {
        if(!fuelCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            return;
        }
        gameObject.SetActive(false);
        audioManager.PlayFuelAudio();
        fuelController.GetFuel();
    }
}
