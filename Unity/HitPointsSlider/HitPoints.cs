using DumplingBase.Live;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HitPoints : MonoBehaviour
{
    public int MaxSingleHp = 100;
    [SerializeField]
    public Color[] HPColorList = { Color.black, Color.red, new Color(0.46f, 0.06f, 0.06f) };

    [HideInInspector]
    public LiveObject Target;

    private Slider HpSlider;
    private Image FillImage;
    private Image BackgroundImage;
    private int HpNum;     //血条数量
    private int MaxHp;      //最大生命值
    private int SingleHp;   //单血条血量

    protected virtual void setSlider()
    {
        int nowHealth = Target.getNowHealth();
        HpSlider.value = nowHealth % SingleHp;  //设置当前Hp
        if(HpSlider.value == 0 && nowHealth > 0)    //当取余为零，但hp大于零时，此时血条应该是满的
        {
            HpSlider.value = SingleHp;
        }

        int backgroundIndex = HpSlider.value == SingleHp ? nowHealth / SingleHp - 1 : nowHealth / SingleHp;     //计算背景血条颜色的指针，当前血条指针是背景血条指针+1

        FillImage.color = HPColorList[backgroundIndex + 1]; //设置血条颜色
        BackgroundImage.color = HPColorList[backgroundIndex];   //设置背景血条颜色
    }

    protected virtual void Destory()
    {
        Destroy(gameObject);
    }

    protected virtual void Start()
    {
        Target.DemageMethods += setSlider;  //绑定伤害事件触发
        Target.DeadMethods += Destory;  //绑定死亡

        MaxHp = Target.Health;
        HpNum = Mathf.Max(MaxHp / MaxSingleHp, 1);   //按最大血条获取血条数量，且血条最少一条
        SingleHp = MaxHp / HpNum;   //按血条数量获得单条血条的值

        HpSlider = GetComponent<Slider>();
        HpSlider.maxValue = SingleHp;   //设置Hp条长度
        FillImage = HpSlider.transform.GetComponentInChildren<HitPointsFill>().GetComponent<Image>();  //获取slider填充框
        BackgroundImage = HpSlider.transform.GetComponentInChildren<HitPointsBackground>().GetComponent<Image>();  //获取slider背景填充框

        //按当前状态设置血条状态
        setSlider();
        setPosition();
    }

    protected virtual void LateUpdate()
    {
        setPosition();
    }

    //获取绑定物体的位置，移动到对应位置
    protected virtual void setPosition()
    {
        transform.position = Camera.main.WorldToScreenPoint(Target.transform.position) + Target.HpMove;
    }
}
