using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text field를 사용할 수 있도록 하는 header

[System.Serializable]   //직접 만든 class에 접근할 수 있도록 해줌.
public class Dialogue
{
    [TextArea]//한줄 말고 여러 줄 쓸 수 있게 해줌
    public string dialogue;
    public Sprite cg; // 교체될 이미지

}
public class Dialog_001 : MonoBehaviour
{
    //SerializeField : inspector창에서 직접 접근할 수 있도록 하는 변수임.
    [SerializeField] private SpriteRenderer sprite_Person001; //캐릭터 이미지(오리1)를 제어하기 위한 변수
    [SerializeField] private SpriteRenderer sprite_DialogBar; //대사창 이미지(Chat)를 제어하기 위한 변수
    [SerializeField] private Text txt_Dialogue; // 텍스트를 제어하기 위한 변수

    private bool isDialogue = false; //대화가 진행중인지 알려줄 변수
    private int count = 0; //대사가 얼마나 진행됐는지 알려줄 변수

    [SerializeField] private Dialogue[] dialogue;


    public void ShowDialogue()
    {
        ONOFF(true); //대화가 시작됨
        count = 0;
        NextDialogue(); //호출되자마자 대사가 진행될 수 있도록 
    }

    private void ONOFF(bool _flag)
    {
        sprite_DialogBar.gameObject.SetActive(_flag);
        sprite_Person001.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        //첫번째 대사와 첫번째 cg부터 계속 다음 cg로 진행되면서 화면에 보이게 된다. 
        txt_Dialogue.text = dialogue[count].dialogue;
        sprite_Person001.sprite = dialogue[count].cg;
        count++; //다음 대사와 cg가 나오도록 

    }
    void Update()
    {
        //spacebar 누를 때마다 대사가 진행되도록. 
        if (isDialogue) //활성화가 되었을 때만 대사가 진행되도록
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //대화의 끝을 알아야함.
                if (count < dialogue.Length) NextDialogue(); //다음 대사가 진행됨
                else ONOFF(false); //대사가 끝남

            }
        }

    }
}
