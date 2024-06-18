using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class CharactersEvents
{
    public static UnityAction<GameObject, float> characterDamage;
    public static UnityAction<GameObject, float> characterHealth;
}
