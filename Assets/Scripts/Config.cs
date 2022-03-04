using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config : object 
{
    public static float player_speed = 0.8f; //Скорость игрока
    public static float ghost_speed = 0.9f; //Скорость призраков
    public static int hp = 3; //Количество жизней
    public static bool trigger_R;
    public static bool trigger_L;
    public static bool trigger_U;
    public static bool trigger_D;
}
