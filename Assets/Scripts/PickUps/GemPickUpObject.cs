using UnityEngine;

public class GemPickUpObject : MonoBehaviour, IPickupObject {
    [SerializeField] private int amount;
    public void OnPickUp(Character character) {
        character.lvl.AddXP(amount);
    }
}
