using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text field�� ����� �� �ֵ��� �ϴ� header

[System.Serializable]   //���� ���� class�� ������ �� �ֵ��� ����.
public class Dialogue
{
    [TextArea]//���� ���� ���� �� �� �� �ְ� ����
    public string dialogue;
    public Sprite cg; // ��ü�� �̹���

}
public class Dialog_001 : MonoBehaviour
{
    //SerializeField : inspectorâ���� ���� ������ �� �ֵ��� �ϴ� ������.
    [SerializeField] private SpriteRenderer sprite_Person001; //ĳ���� �̹���(����1)�� �����ϱ� ���� ����
    [SerializeField] private SpriteRenderer sprite_DialogBar; //���â �̹���(Chat)�� �����ϱ� ���� ����
    [SerializeField] private Text txt_Dialogue; // �ؽ�Ʈ�� �����ϱ� ���� ����

    private bool isDialogue = false; //��ȭ�� ���������� �˷��� ����
    private int count = 0; //��簡 �󸶳� ����ƴ��� �˷��� ����

    [SerializeField] private Dialogue[] dialogue;


    public void ShowDialogue()
    {
        ONOFF(true); //��ȭ�� ���۵�
        count = 0;
        NextDialogue(); //ȣ����ڸ��� ��簡 ����� �� �ֵ��� 
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
        //ù��° ���� ù��° cg���� ��� ���� cg�� ����Ǹ鼭 ȭ�鿡 ���̰� �ȴ�. 
        txt_Dialogue.text = dialogue[count].dialogue;
        sprite_Person001.sprite = dialogue[count].cg;
        count++; //���� ���� cg�� �������� 

    }
    void Update()
    {
        //spacebar ���� ������ ��簡 ����ǵ���. 
        if (isDialogue) //Ȱ��ȭ�� �Ǿ��� ���� ��簡 ����ǵ���
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //��ȭ�� ���� �˾ƾ���.
                if (count < dialogue.Length) NextDialogue(); //���� ��簡 �����
                else ONOFF(false); //��簡 ����

            }
        }

    }
}
