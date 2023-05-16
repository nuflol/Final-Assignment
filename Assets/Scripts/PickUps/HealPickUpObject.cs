using UnityEngine;

public class HealPickUpObject : MonoBehaviour, IPickupObject {
    [SerializeField] private int healAmount;
    
    public void OnPickUp(Character character) {
        character.Heal(healAmount);
    }
}
