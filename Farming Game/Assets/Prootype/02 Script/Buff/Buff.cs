using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff {

    public float durationTime;//지속시간
    public float elapsedTime;//진행시간
                             //중지, 시작, 일시중지

    public float Resulte = 0;

    public bool IsPause = false;

    public virtual void Start(float data)
    {
        Execute(data);
    }

    public void Stop()
    {
        //상태를 초기화
    }

    protected abstract void Execute(float data);
    protected abstract void Execute(float data, float aa);

    //버프 넣는 스킬 리스트(각 스크립트 짜야함)

    public class FixedAtackBuff
    {
        float atk;

        float reult = 0;

        public FixedAtackBuff(float atk)
        {
            this.atk = atk;
        }

        void Execute(float data)
        {
            reult = data + atk;
        }
    }

    void fixedATK1()//고정공격력+1
    {
        new FixedAtackBuff(NetworkLogLevel * 5);
    }

    void fixedATK2()//고정공격력+3
    {

    }

    void fixedATK3()//고정공격력+5
    {

    }

    void ATK1()//공격력+0.5
    {

    }4+4x0.25=

    void ATK2()//공격력+1.5
    {

    }

    void ATK3()//공격력+2.5
    {

    }

    void percentATK1()//퍼센트공격력+0.25%
    {

    }

    void percentATK2()//퍼센트공격력+0.75%
    {

    }

    void percentATK3()//퍼센트공격력+2.25%
    {

    }

    void moveSpeed()//이동속도증가+0.05
    {

    }

    void accelerationTime()//시간배속 또는 가속 +1%
    {

    }

    void emptyStomach()//공복 덜느끼는것
    {

    }





}
