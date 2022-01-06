using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillKeepTime : MonoBehaviour
{
    public float KeepTime;
    public Player_Effect _Effect;
    public Image FileImage;
     public bool IsAttack;
    [SerializeField] private PlayerTakeEffect takeEffect;
    [SerializeField] private Player_Info Info;
    void Start()
    {
        FileImage.sprite = _Effect.File_Image;
        FileImage.color = _Effect.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttack == false)
            FileImage.fillAmount -= Time.deltaTime / KeepTime;
        else
            FileImage.fillAmount = takeEffect.ThunderAttackCount / Info.MaxThunderAttackCount;

        if (FileImage.fillAmount <= 0)
        {
            FileImage.fillAmount = 1;
            StartCoroutine(CloseThis());
        }
    }
    IEnumerator CloseThis()
    {
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }
}
