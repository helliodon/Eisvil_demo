using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestView: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI QuestName;
    [SerializeField] private TextMeshProUGUI QuestDescription;
    [SerializeField] private TextMeshProUGUI Progress;
    [SerializeField] private Image ProgressBarImage;
    [SerializeField] private Image CompleteImage;

    public void SetQuestItemView(string name, string questDescription, int targetValue, int passed)
    {
        QuestName.text = name;
        QuestDescription.text = questDescription;
        Progress.text = passed <= targetValue ? passed + "/" + targetValue : Progress.text;
        ProgressBarImage.fillAmount = (float)passed / (float)targetValue;
        CompleteImage.gameObject.SetActive(passed >= targetValue);
    }
}
