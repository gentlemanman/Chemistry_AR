using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public GameObject frame;//红色边框预设体
    public GameObject introduce;//元素的详细信息
    public GameObject atom;//原子模型预设体
    public bool isSelected=false;//记录该物体是否被选中

    GameObject[] allGameObjects;//查找所有元素
    
    

    private void Start()
    {
        allGameObjects = GameObject.FindGameObjectsWithTag("element");
    }


    /// <summary>
    /// 鼠标点击显示信息
    /// </summary>
    private void OnMouseDown()
    {
        //当前元素没有被选中
        if(!isSelected)
        {
            changeFrame();//红色框
            changeIntroduce();//修改属性
            changeAtom();//改变原子模型
        }
        //设置当前元素被选中
        isSelected = true;
        
    }

    /// <summary>
    /// 鼠标滑过红色边框
    /// </summary>
    private void OnMouseEnter()
    {
        bool flag = true;
        for (int i = 0; i < allGameObjects.Length; i++)
        {
            Select select = allGameObjects[i].gameObject.GetComponent<Select>();
            if (select.isSelected)
            {
                flag = false;
            }
        }
        if(flag)
        {
            changeFrame();
        } 
    }


    /// <summary>
    /// 修改之前物体被选中的状态
    /// </summary>
    void changeFrame()
    {
        
        //根据标签销毁之前的预设体
        Destroy(GameObject.FindGameObjectWithTag("frame"));
        //修改之前被选中物体的状态
        for (int i = 0; i < allGameObjects.Length; i++)
        {
            Select select = allGameObjects[i].gameObject.GetComponent<Select>();
            if (select.isSelected)
            {
                select.isSelected = false;
            }
        }
        Vector3 curGameObjectpos = gameObject.GetComponent<Transform>().position;
        //设置新选中物体的状态
        Vector3 framePos = new Vector3(curGameObjectpos.x, curGameObjectpos.y, curGameObjectpos.z);
        Instantiate(frame, framePos, Quaternion.identity);
    }



    /// <summary>
    /// 修改元素的各种属性信息
    /// </summary>
    void changeIntroduce()
    {
        //根据标签销毁之前的预设体
        Destroy(GameObject.FindGameObjectWithTag("introduce"));
        //生成详细信息并修改属性参数 
        Text[] texts = introduce.GetComponentsInChildren<Text>();
        int loc = 0;//存储当前元素在数组中的位置
        string name = gameObject.name;
        if (name.Length > 3)
        {
            int i = name.IndexOf('(');
            name = name.Substring(0, i);
        }
        for (int i = 0; i < introduce.gameObject.GetComponent<Introduce>().Loc.Length; i++)
        {
            if (name.Equals(introduce.gameObject.GetComponent<Introduce>().Loc[i]))
            {
                loc = i;
                break;
            }
        }
        //通过查找预设体上Introduce脚本修改属性信息
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = introduce.gameObject.GetComponent<Introduce>().Properties[i] + introduce.gameObject.GetComponent<Introduce>().All[loc, i];
        }
        Instantiate(introduce);
    }

    void changeAtom()
    {
        Destroy(GameObject.FindGameObjectWithTag("atom"));
        string name = gameObject.name;
        if (name.Length > 3)
        {
            int i = name.IndexOf('(');
            name = name.Substring(0,i);
        }
        atom.gameObject.GetComponentInChildren<TextMesh>().text = name + "原子";
        atom.gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        Instantiate(atom);
    }
}
