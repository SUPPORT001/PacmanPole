using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Run2 : MonoBehaviour
{
    public GameObject tochPrefab;
    public GameObject Stena;
    public GameObject Par;
    public GameObject tochk;
    public GameObject Stena2;
    public GameObject Stena3;

    

    
    void Generation(int constX, int constY)
    {
        GameObject go1;
        GameObject go;
        int ii, i;
        int rand, randX;
        int[] randY = new int[constX];
        int[,] mas = new int[constX - 1, constY - 1];
        List<int[]> destr = new List<int[]>();
        for (i = 1; i < constY - 1; i++)
        {
            for (ii = 1; ii < constX - 1; ii++)
            {
                mas[ii, i] = -10;
                randY[ii] = 1;
            }
        }
        randX = 1;

        

        //генерация поля
        //for (i = 1; i < constY - 2; i++)
        for (i = 1; i < constY - 2; i++)
            {
            for (ii = 1; ii < constX - 2; ii++)
            {
                // создаем точку
                go = Instantiate(tochPrefab, Par.transform);
                go.name = "toch*" + ii.ToString() + "*" + i.ToString();
                go.transform.localPosition = new Vector3(ii, i, 20);
                rand = UnityEngine.Random.Range(0, randX+randY[ii]);
                // создаем стену
                go1 = Instantiate(Stena3);
                go1.transform.SetParent(go.transform);
                go1.transform.localPosition = Vector3.zero;
                if (rand < randX)
                {
                    // вверх можно всегда индекс 1
                    go1.transform.localEulerAngles = new Vector3(0, 0, 90);
                    randX = 1;
                    randY[ii]++;
                    mas[ii, i] = 1;
                }
                else
                {
                    // направление вправо
                    if (mas[ii + 1, i - 1] == 1)
                    {
                        // направо вниз стена
                        if (mas[ii + 1, i-1] != -1 && mas[ii, i - 1] != 0 && mas[ii, i - 1] !=1)
                        {
                            mas[ii, i] = 0;
                            randX++;
                        }
                        else if(mas[ii, i - 1]!=1 && mas[ii, i - 1]!=-1 && mas[ii-1, i - 1]!=0)
                        {
                            go1.transform.localEulerAngles = new Vector3(0, 0, 180);
                            randX = 1;
                            mas[ii, i] = -1;
                        }
                        else
                        {
                            destr.Add(new int[] { ii, i });
                            Destroy(go1);
                        }
                    }
                    else if (mas[ii, i - 1] == 1) 
                    {
                        //стена подо мной
                        if (mas[ii + 1, i - 1] != -1)
                        {
                            mas[ii, i] = 0;
                            randX++;
                        }
                        else if (mas[ii - 1, i - 1] != 0 && mas[ii - 1, i - 1] != 1)
                        {
                            go1.transform.localEulerAngles = new Vector3(0, 0, 180);
                            randX = 1;
                            mas[ii, i] = -1;
                        }
                        else 
                        {
                            destr.Add(new int[] { ii, i });
                            Destroy(go1);
                        }
                    }
                    else
                    {
                        randX++;
                        randY[ii] = 1;
                        mas[ii, i] = 0;
                    }
                }
                
            }
            randX = 1;
        }

        

        // проверка списка точек без стен
        for( i=0; i< destr.Count; i++)
        {
            if (mas[destr[i][0] + 1, destr[i][1]] == -1 || 
                mas[destr[i][0] - 1, destr[i][1]] == 0 || 
                mas[destr[i][0], destr[i][1] + 1] == -2 || 
                mas[destr[i][0], destr[i][1] - 1] == 1)
            {
                destr.RemoveAt(i);
                i--;
            }
        }
        foreach (int[] m in destr)
        {
            // проверка соеденение стеной соседа
            //Debug.Log(m[0].ToString() + "  =  " + m[1].ToString());

            mas[m[0], m[1]] = 0;

            if (mas[m[0] - 1, m[1] + 1] == 0 || mas[m[0] ,m[1] + 1] == -1){
                mas[m[0] - 1, m[1]] = 1;
                go1 = GameObject.Find("toch*" + (m[0] - 1) + "*" + m[1]).transform.GetChild(0).gameObject;
                go1.transform.localPosition = Vector3.zero;
                go1.transform.localEulerAngles = new Vector3(0, 0, 0);
                //print("изменение стены");
            } else {
                mas[m[0], m[1]] = -1;
                go1 = Instantiate(Stena3);
                go1.transform.SetParent(GameObject.Find("toch*" + m[0] + "*" + m[1]).transform);
                go1.transform.localPosition = Vector3.zero;
                go1.transform.localEulerAngles = new Vector3(0, 0, 180);
            }
            if (m[0] == 1) print("крайняя слева");
            if (m[0] == 17) print("крайняя справа");
            if (m[1] == 1) print("крайняя снизу");
            if (m[1] == 10) print("крайняя справа");
        }

        //Генерация внешних стен
        for (int yyy = 0; yyy < constY - 1; yyy++)
            {
                go = Instantiate(tochPrefab, Par.transform);
                go.name = "tochechkaHorizontal*" + yyy;
                go.transform.localPosition = new Vector3(0, yyy, 20);
                
                go1 = Instantiate(Stena3);
                go1.transform.SetParent(go.transform);
                go1.transform.localPosition = Vector3.zero;
                go1.transform.localEulerAngles = new Vector3(0, 0, 90);
                mas[0, yyy] = 1;

                go = Instantiate(tochPrefab, Par.transform);
                go.name = "tochechkaHorizontal*" + yyy;
                go.transform.localPosition = new Vector3(constX - 1, yyy, 20);

                go1 = Instantiate(Stena3);
                go1.transform.SetParent(go.transform);
                go1.transform.localPosition = Vector3.zero;
                go1.transform.localEulerAngles = new Vector3(0, 0, 90);
                mas[constX - 2, yyy] = 1;
            }

            for (int xxx = 0; xxx < constX - 1; xxx++)
            {
                go = Instantiate(tochPrefab, Par.transform);
                go.name = "tochechkaVertical*" + xxx;
                go.transform.localPosition = new Vector3(xxx, 0, 20);
                
                go1 = Instantiate(Stena3);
                go1.transform.SetParent(go.transform);
                go1.transform.localPosition = Vector3.zero;
                go1.transform.localEulerAngles = new Vector3(0, 0, 0);
                mas[xxx, 0] = 1;

                go = Instantiate(tochPrefab, Par.transform);
                go.name = "tochechkaVertical*" + xxx;
                go.transform.localPosition = new Vector3(xxx, constY - 1, 20);

                go1 = Instantiate(Stena3);
                go1.transform.SetParent(go.transform);
                go1.transform.localPosition = Vector3.zero;
                go1.transform.localEulerAngles = new Vector3(0, 0, 0);
                mas[xxx, constY - 2] = 1;
            }
    }

    //вертикально вниз (-2)

    void Start()
    {
        Generation(18, 11);
    }
}