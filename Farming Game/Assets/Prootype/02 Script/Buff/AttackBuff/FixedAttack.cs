using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FixedAttack : Buff {

    float fixedatk, fixedatk1, fixedatk2, fixedatk3;//level은 계산에 쓸 임시레벨
    float level, result;

    void fixedattack1()//고정공격력1 +수치
    {
        fixedatk1 = level * 1;
    }

    void fixedattack2()//고정공격력2 +수치
    {
        fixedatk2 = level * 3;
    }

    void fixedattack3()//고정공격력3 +수치
    {
        fixedatk3 = level * 5;
    }

    void fixedattack_result()//고정공격력 전체 +수치
    {
        fixedatk = fixedatk1 + fixedatk2 + fixedatk3;
    }

    protected override void Execute(float data)
    {
        result = data + fixedatk;
    }
}
