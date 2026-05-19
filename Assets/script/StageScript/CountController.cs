using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountController : MonoBehaviour
{
    public TextMeshProUGUI countTMP;
    public TextMeshProUGUI gradeTMP;
    public void ChangeCountTMP(int count, int countMax)
    {
        countTMP.text = $"{count} / {countMax}";
    }

    public void ChangeGradeTMP(int s, int a, int b)
    {
        gradeTMP.text = $"S: {s} \n A: {a} \n B: {b}";
    }
}
