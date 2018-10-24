using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeTable : MonoBehaviour {
    public GameObject H;//给出第一行第一个预设体
    public float gap=1.1f;//两个元素之间的间距
    /*
    0-AlkaliMetal;//碱金属
    1-Material AlkalineEarthMetal;//碱土金属
    2-Material AXi;//锕系
    3-Material BackTransitionMetal;//后过渡金属
    4-Material Halogen;//卤素
    5-Material LanXi;//镧系
    6-Material Nonmetal;//非金属
    7-Material OtherNonmetal;//其它非金属
    8-Material RareGas;//稀有气体
    9-Material TransitionMetal;//过渡金属
    */
    public Material[] materials;

    TextMesh[] child;


    private void Start()
    {
        InitializeOne();//初始化第一行元素
        InitializeTwo();//初始化第二行元素
    }

    void InitializeOne()
    {
        Introduce introduce = H.GetComponent<Introduce>();
        H.gameObject.GetComponent<Renderer>().material = materials[7];//初始化第一行第一个元素的材质
        Vector3 Hpos = new Vector3(H.transform.localPosition.x, H.transform.localPosition.y, H.transform.localPosition.z);//初始化第一个元素的位置
        Vector3 HposTemp = Hpos;
        //生成第一行元素周期表
        for (int i = 1; i <= 2; i++)
        {
            Instantiate(H, Hpos, Quaternion.identity);
            child = H.gameObject.GetComponentsInChildren<TextMesh>();
            child[0].text = introduce.All[i, 0];//设置name
            child[1].text = introduce.All[i, 2];//设置number
            child[2].text = introduce.All[i, 1];//设置letter
            Hpos.x = Hpos.x + gap * 17;
            H.gameObject.GetComponent<Renderer>().material = materials[8];
            H.name = introduce.All[i, 1];
            if (i == 2)
            {
                //将预设体的属性值设置成初始值
                H.transform.localPosition = HposTemp;
                child = H.gameObject.GetComponentsInChildren<TextMesh>();
                child[0].text = introduce.All[0, 0];//设置name
                child[1].text = introduce.All[0, 2];//设置number
                child[2].text = introduce.All[0, 1];//设置letter
                H.gameObject.GetComponent<Renderer>().material = materials[7];
                H.name = introduce.All[0, 1];
            }
        }
    }
    void InitializeTwo()
    {
        //生成第二行元素
        Introduce introduce = H.GetComponent<Introduce>();
        Vector3 Hpos = new Vector3(H.transform.localPosition.x, H.transform.localPosition.y, H.transform.localPosition.z);//初始化第一个元素的位置
        H.gameObject.GetComponent<Renderer>().material = materials[0];//初始化第二行第一个元素的材质
        Vector3 Lipos = new Vector3(H.transform.localPosition.x, H.transform.localPosition.y - gap, H.transform.localPosition.z);//初始化第一个元素的位置
        child = H.gameObject.GetComponentsInChildren<TextMesh>();//初始化第一行元素的数据
        child[0].text = introduce.All[2, 0];//设置name
        child[1].text = introduce.All[2, 2];//设置number
        child[2].text = introduce.All[2, 1];//设置letter
        H.name = introduce.All[2, 1];//修改一下生成物体的名称
        for (int i = 3; i <= 10; i++)
        {
            Instantiate(H, Lipos, Quaternion.identity);
            child = H.gameObject.GetComponentsInChildren<TextMesh>();
            child[0].text = introduce.All[i, 0];//设置name
            child[1].text = introduce.All[i, 2];//设置number
            child[2].text = introduce.All[i, 1];//设置letter
            if (i == 4) Lipos.x = Lipos.x + 10 * gap;//中间没元素需要修改跨越坐标
            Lipos.x = Lipos.x + gap;
            if (i == 3)
            {
                H.gameObject.GetComponent<Renderer>().material = materials[1];
            }
            if (i == 4)
            {
                H.gameObject.GetComponent<Renderer>().material = materials[6];
            }
            if (i >= 5 && i <= 7)
            {
                H.gameObject.GetComponent<Renderer>().material = materials[7];
            }
            if (i == 8)
            {
                H.gameObject.GetComponent<Renderer>().material = materials[4];
            }
            if (i == 9)
            {
                H.gameObject.GetComponent<Renderer>().material = materials[8];
            }
            H.name = introduce.All[i, 1];
            if (i == 10)
            {
                //将预设体的属性值设置成初始值
                H.transform.localPosition = Hpos;
                child = H.gameObject.GetComponentsInChildren<TextMesh>();
                child[0].text = introduce.All[0, 0];//设置name
                child[1].text = introduce.All[0, 2];//设置number
                child[2].text = introduce.All[0, 1];//设置letter
                H.gameObject.GetComponent<Renderer>().material = materials[7];
                H.name = introduce.All[0, 1];
            }
        }
    }
}
