using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{

    [Header("ui组件")]
    public Text textlabel;
    public Image faceImage;

    [Header("文本文件")]
    public TextAsset textfile;
    public int index;
    public float textSpeed;

    bool textFinished;


    [Header("头像")]
    public Sprite face_1,face_2;


    List<string> textList = new List<string>();


    // Start is called before the first frame update
    private void Awake()
    {
        GetTextFromFile(textfile);
    }

    private void OnEnable()
    {
        textFinished = true;
        StartCoroutine(SetTextUI());
        //textlabel.text = textList[index];
        //index++;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown (KeyCode.R )&& textFinished )
        {
            //textlabel.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFromFile(TextAsset File)
    {
        textList.Clear();
        index = 0;

        var lineData = File.text.Split('\n');
        
        foreach(var line in lineData )
        {
            textList.Add(line);
        }

    }
    
    IEnumerator SetTextUI()
    {
        textFinished = false;
        textlabel.text = "";

        switch (textList [index])
        {
            case "主角":
                faceImage.sprite = face_1;
                index++;
                break;

            case "魔镜":
               faceImage.sprite = face_2;
                index++;
                break;

        }
      for (int i=0;i<textList [index ].Length;i++)
        {
            textlabel.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }

        textFinished = true ;
        index++;
    }
}
