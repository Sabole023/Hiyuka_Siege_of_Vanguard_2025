using System;
using UnityEngine;

public class TestingDelegate : MonoBehaviour
{
    public delegate void TestDelegate();
    public delegate int TestDelegateInt(int i);

    TestDelegate myTestDelegate;
    TestDelegateInt myTestDelegateInt;

    Action testAction;
    Action<int, float> testFloatAction;

    Func<bool> testFunc;
    Func<int, bool> testFuncReturnBool;
    

    int i = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTestDelegate += myFirstTestDelegate;
        myTestDelegate += delegate () { Debug.Log("Anonymous delegate");};
        myTestDelegate += () => {Debug.Log("Lambda delegate");};

        //myTestDelegateInt += TestIntDelegate;
        myTestDelegateInt = (int i) => i + 5;
        //myTestDelegateInt += (int i) => {return 2 * 5;};

        testFloatAction = (int a, float b) => { Debug.Log("TestFloatAction " + a + " " + b); };

        testFunc = () => true;
        testFuncReturnBool = (int a) => a > 5;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //myTestDelegate?.Invoke();
            //Debug.Log(myTestDelegateInt.Invoke(i));
            //testFloatAction?.Invoke(2, 2.5f);
            //Debug.Log(testFunc());
            Debug.Log(testFuncReturnBool(3));
        }
    }

    private void myFirstTestDelegate()
    {
        Debug.Log("MYTestDelegate");
    }

    private int TestIntDelegate(int a)
    {
        Debug.Log("Space " + a);
        return a + 1;
    }
}
