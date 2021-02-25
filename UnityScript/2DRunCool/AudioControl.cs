using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider MasterAudio;
    [SerializeField] Slider BGM;
    [SerializeField] Slider SE;

    float saveMasterAudio;
    float saveBGM;
    float saveSE;
    // Start is called before the first frame update
    void Start()
    {
        LoadAudio();
        MasterAudio.value = saveMasterAudio;
        BGM.value = saveBGM;
        SE.value = saveSE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MasterAudioSetting()//音量設定
    {
        audioMixer.SetFloat("Master", MasterAudio.value);
    }
    public void BGMSetting()
    {
        audioMixer.SetFloat("BGM", BGM.value);
    }
    public void SESetting()
    {
        audioMixer.SetFloat("SE", SE.value);
    }
    public void LoadAudio()//讀取音量設定
    {
        if (PlayerPrefs.HasKey("MasterAudio"))
        {
            saveMasterAudio = PlayerPrefs.GetFloat("MasterAudio");
            audioMixer.SetFloat("Master", saveMasterAudio);
        }
        if (PlayerPrefs.HasKey("BGMAudio"))
        {
            saveBGM = PlayerPrefs.GetFloat("BGMAudio");
            audioMixer.SetFloat("BGM", saveBGM);
        }
        if (PlayerPrefs.HasKey("SEAudio"))
        {
            saveSE = PlayerPrefs.GetFloat("SEAudio");
            audioMixer.SetFloat("SE", saveSE);
        }

    }
    public void SaveAudio()//給關閉鈕呼叫來存檔
    {
        saveMasterAudio = MasterAudio.value;
        PlayerPrefs.SetFloat("MasterAudio", saveMasterAudio);
        saveBGM = BGM.value;
        PlayerPrefs.SetFloat("BGMAudio", saveBGM);
        saveSE = SE.value;
        PlayerPrefs.SetFloat("SEAudio", saveSE);
    }
    public void TimePause()
    {
        Time.timeScale = 0;
    }
    public void TimeStart()
    {
        Time.timeScale = 1;
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
