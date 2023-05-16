using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class XPBar : MonoBehaviour {
    [SerializeField] private Slider Slider;
    [SerializeField] private TextMeshProUGUI levelTxt;

    public void UpdateXPSlider(int current, int target) {
        Slider.maxValue = target;
        Slider.value = current;
    }

    public void SetLevelText(int level) {
        levelTxt.text = level.ToString();
    }
}
