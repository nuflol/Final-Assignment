using UnityEngine;

public class CoinPickup : MonoBehaviour, IPickupObject {
    [SerializeField] private int count;
    public void OnPickUp(Character character) {
        character.coins.Add(count);
    }
}
