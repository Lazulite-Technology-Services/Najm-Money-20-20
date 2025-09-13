using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    public GameObject HomeScreen, AboutUsScreen;
    public GameObject AboutUs_English_Object, AboutUsArabic_Object, HomeButtonGroup, AboutUsButtonGroup, HomeBGVideoImage;

    public Button AboutUsButton_Eng, AboutUsButton_Arb, HomeButton, English, Arabic;

    public string Eng_AboutUsFolderName, Arb_aboutUsFolderName;

    public Image pauseOrPlayButtonImage;

    public Sprite PauseSprite, PlaySprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;    
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        English.onClick.AddListener(()=> AboutUs(0));
        Arabic.onClick.AddListener(()=> AboutUs(1));
        HomeButton.onClick.AddListener(Home);

        AboutUsButton_Eng.onClick.AddListener(() => PlayAboutUsVideo(0));
        AboutUsButton_Arb.onClick.AddListener(() => PlayAboutUsVideo(1));

        pauseOrPlayButtonImage.GetComponent<Button>().onClick.AddListener(VideoHandler.instance.PauseOrPlayTheVideo);
    }

    public void Home()
    {
        AboutUsScreen.SetActive(false);
        AboutUsButtonGroup.SetActive(false);
        AboutUs_English_Object.SetActive(false);
        AboutUsArabic_Object.SetActive(false);
        HomeButton.gameObject.SetActive(false);
        HomeButtonGroup.SetActive(true);
        pauseOrPlayButtonImage.gameObject.SetActive(false);

        pauseOrPlayButtonImage.sprite = GameManager.instance.PauseSprite;
        HomeBGVideoImage.gameObject.SetActive(true);
        VideoHandler.instance.GetTheVideo("home");
    }

    public void AboutUs(int language)
    {
        HomeButtonGroup.SetActive(false);
        AboutUsButtonGroup.SetActive(true);
        HomeButton.gameObject.SetActive(true);
        //BottomButtonGroupObject.SetActive(true);

        //0 - for English - 1 for Arabic
        if (language == 0)
        {
            if(AboutUsArabic_Object.activeSelf)
                AboutUsArabic_Object.SetActive(false);

            if (!AboutUs_English_Object.activeSelf)
                AboutUs_English_Object.SetActive(true);
            
        }
        else
        {
            if (AboutUs_English_Object.activeSelf)
                AboutUs_English_Object.SetActive(false);

            if (!AboutUsArabic_Object.activeSelf)
                AboutUsArabic_Object.SetActive(true);
            
        }
        
    }

    private void PlayAboutUsVideo(int lang)
    {
        HomeBGVideoImage.gameObject.SetActive(false);
        AboutUsScreen.SetActive(true);
        pauseOrPlayButtonImage.gameObject.SetActive(true);

        //0 - for English - 1 - for Arabic
        if (lang == 0)
        {
            VideoHandler.instance.GetTheVideo(Eng_AboutUsFolderName);
        }
        else
        {
            VideoHandler.instance.GetTheVideo(Arb_aboutUsFolderName);
        }
    }

    
}
