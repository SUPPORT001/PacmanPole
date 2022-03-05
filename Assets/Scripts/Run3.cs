using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run3
{

    public static Dictionary<Toch, List<Toch>> dic = new Dictionary<Toch, List<Toch>>();

    public static int x = 18;
    public static int y = 11;
    public struct Toch
    {
        public int x;
        public int y;
    }
    struct Rebro
    {
        public Toch t1;
        public Toch t2;
    }
    public static List<string> Main()
    {
        List<string> list = new List<string>();
        //List<Toch> Spis = new List<Toch>();
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Toch t = new Toch();
                t.x = i;
                t.y = j;
                List<Toch> s = new List<Toch>();
                dic.Add(t, s);
            }
        }
        Tochka();
        foreach (var zap in dic){
            Toch t = zap.Key;
            string s = t.x.ToString() + "-" + t.y.ToString() + "!";
            foreach(Toch t1 in zap.Value){
                s += t1.x.ToString() + '-' + t1.y.ToString() + "!";
            }
            s += "*";
            list.Add(s);
        }

        return list;
    }
    static void Tochka()
    {
        for (int i = 0; i < x - 1; i++)
        {
            for (int j = 0; j < y - 1; j++)
            {
                Toch t1 = new Toch(); t1.x = i; t1.y = j;
                Toch t2 = new Toch(); t2.x = i + 1; t2.y = j;
                Toch t3 = new Toch(); t3.x = i; t3.y = j + 1;
                Toch t4 = new Toch(); t4.x = i + 1; t4.y = j + 1;
                List<Toch> sp1 = dic[t1];
                List<Toch> sp2 = dic[t2];
                List<Toch> sp3 = dic[t3];
                List<Toch> sp4 = dic[t4];
                int count = (sp1.Count + sp2.Count + sp3.Count + sp4.Count) / 2;
                if (count < 2)
                {
                    GenSten(t1, t2, t3, t4);
                }
            }
        }
    }
    static void GenSten(Toch t1, Toch t2, Toch t3, Toch t4)
    {
        //Console.WriteLine("=========");
        List<Toch[]> lis = GenListToch(t1, t2, t3, t4);
        for (int i = 2; i < lis.Count; i++)
        {
            System.Random p = new System.Random();
            int r = Convert.ToInt32(p.Next(lis.Count));
            // Debug.Log("i-{0}, j-{1} = i-{2}, j-{3}" + lis[r][0].x + lis[r][0].y + lis[r][1].x + lis[r][1].y);
            List<Toch> l = dic[lis[r][0]]; l.Add(lis[r][1]);
            List<Toch> l1 = dic[lis[r][1]]; l1.Add(lis[r][0]);
            lis.RemoveAt(r);
            i--;
        }
        //Console.WriteLine("-------------------");
        //Console.Read();
    }
    static List<Toch[]> GenListToch(Toch t1, Toch t2, Toch t3, Toch t4)
    {
        List<Toch[]> ll = new List<Toch[]>(){new Toch[]{t1,t2},
                                                 new Toch[]{t1,t3},
                                                 new Toch[]{t2,t4},
                                                 new Toch[]{t3,t4}};
        //Console.WriteLine("!!!");
        //Console.Read();
        for (int i = 0; i < ll.Count; i++)
        {
            List<Toch> l = dic[ll[i][0]];
            bool f = false;
            foreach (Toch t in l)
            {
                if (t.x == ll[i][1].x && t.y == ll[i][1].y)
                {
                    f = true;
                    break;
                }
            }
            if (f)
            {
                ll.RemoveAt(i);
                i--;
            }
        }
        return ll;
    }
}
