using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarradeVida : MonoBehaviour
{
    public Image vida;
    float hp, maxHp = 100f;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(float amount) {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        vida.transform.localScale = new Vector2(hp / maxHp, 1);
    }
}
