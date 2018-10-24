using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduce : MonoBehaviour {
    /*
    public string _A = "氢（H）";//名称
    public string _B = "1";//原子序号
    public string _C = "Hydrogenium";//英文名称
    public string _D="1.00794";//相对原子质量
    public string _E="K1";//各层电子数
    public string _F="53";//原子半径   
    */
    const int Number = 11;//初始化元素的个数
    public string[] Loc = { "H","He",
                            "Li","Be","B","C","N","O","F","Ne",
                            "Na" };

    public string[] Properties = { "名称:", "字母表示:", "原子序号:", "英文名称:", "相对原子质量:", "各层电子数:", "原子半径:" };

    public string[,] All = new string[Number, 7] {
                                              { "氢",  "H" ,  "1" ,   "Hydrogenium", "1.00794",   "K1",      "53" },
                                              { "氦",  "He",  "2" ,   "Helium",      "4.002602",  "K2",      "31" },
                                              { "锂" , "Li",  "3" ,   "Lithium" ,    "6.941",     "K2L1" ,   "167"},
                                              { "铍" , "Be",  "4" ,   "Beryllium" ,  "9.012182",  "K2L2" ,   "167"},
                                              { "硼" , "B" ,  "5" ,   "Boron" ,      "10.811",    "K2L3" ,   "87"},
                                              { "碳" , "C" ,  "6" ,   "Carbon" ,     "12.0107",   "K2L4" ,   "67"},
                                              { "氮" , "N" ,  "7" ,   "Nitrogen" ,   "14.0067",   "K2L5" ,   "56"},
                                              { "氧" , "0" ,  "8" ,   "Oxygenium" ,  "15.9994",   "K2L6" ,   "48" },
                                              { "氟" , "F" ,  "9" ,   "Fluorine" ,   "18.998403", "K2L7" ,   "42" },
                                              { "氖" , "Ne",  "10",   "Neon" ,       "20.1797",   "K2L8" ,   "38" },
                                              { "钠" , "Na",  "11",   "Sodium" ,     "22.98977",  "K2L8M1" , "190"}
                                              };
}
