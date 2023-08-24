using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject settingPanel;

    private void Start()
    {
        settingPanel.SetActive(false);
    }

    public void ToggleSettingPanel()
    {
        settingPanel.SetActive(true);

        if (settingPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        settingPanel.SetActive(false);
    }

}
