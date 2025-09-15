using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    public GameObject HomeScreen, AboutUsScreen;
    public GameObject AboutUs_English_Object, AboutUsArabic_Object, HomeButtonGroup, AboutUsButtonGroup, HomeBGVideoImage;

    public GameObject AboutUsEnglishObject_Video, AboutUsArabicObject_Video;

    //public Button AboutUsButton_Eng, AboutUsButton_Arb, HomeButton, English, Arabic;
    public Button HomeButton, English, Arabic;

    public string Eng_AboutUsFolderName, Arb_aboutUsFolderName;

    public Image pauseOrPlayButtonImage;

    public Sprite PauseSprite, PlaySprite;

    public VideoClip EnglishBG, ArabicBg;
    public VideoPlayer Player;

    private int language = 0;

    public Animator currentAnimator;
    

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

        AboutUs_English_Object.GetComponent<Button>().onClick.AddListener(() => PlayAboutUsVideo(0));
        AboutUsArabic_Object.GetComponent<Button>().onClick.AddListener(() => PlayAboutUsVideo(1));

        pauseOrPlayButtonImage.GetComponent<Button>().onClick.AddListener(PauseOrPlayTheVideo);
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
        //HomeBGVideoImage.gameObject.SetActive(true);

        AboutUsEnglishObject_Video.SetActive(false);
        AboutUsArabicObject_Video.SetActive(false);

        Player.clip = EnglishBG;
        //VideoHandler.instance.GetTheVideo("home");
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
            Player.clip = ArabicBg;

            if (AboutUs_English_Object.activeSelf)
                AboutUs_English_Object.SetActive(false);

            if (!AboutUsArabic_Object.activeSelf)
                AboutUsArabic_Object.SetActive(true);
            
        }
        
    }

    private void PlayAboutUsVideo(int lang)
    {
        AboutUsButtonGroup.SetActive(false);
        //HomeBGVideoImage.gameObject.SetActive(false);
        AboutUsScreen.SetActive(true);
        pauseOrPlayButtonImage.gameObject.SetActive(true);
        language = lang;

        //0 - for English - 1 - for Arabic
        if (lang == 0)
        {
            currentAnimator = AboutUsEnglishObject_Video.GetComponent<Animator>();
            currentAnimator.speed = 1;
            AboutUsEnglishObject_Video.SetActive(true);
            AboutUsArabicObject_Video.SetActive(false);
            //VideoHandler.instance.GetTheVideo(Eng_AboutUsFolderName);
        }
        else
        {
            
            currentAnimator = AboutUsArabicObject_Video.GetComponent<Animator>();
            currentAnimator.speed = 1;
            AboutUsArabicObject_Video.SetActive(true);
            AboutUsEnglishObject_Video.SetActive(false);
            //VideoHandler.instance.GetTheVideo(Arb_aboutUsFolderName);
        }
    }

    public void PauseOrPlayTheVideo()
    {
        //if video player is playing pause it
        if (currentAnimator.speed == 1)
        {
            pauseOrPlayButtonImage.sprite = GameManager.instance.PlaySprite;
            currentAnimator.speed = 0;
            //Player.Pause();
        }
        else
        {
            pauseOrPlayButtonImage.sprite = GameManager.instance.PauseSprite;
            currentAnimator.speed = 1;
            //Player.Play();
        }
    }


}
