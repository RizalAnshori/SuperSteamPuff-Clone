using XBT;
using UnityEngine;
using System.Collections;

public class TestAI : MonoBehaviour {

    public Selector testAI;
    RandomSelector randomAI;
    Repeater repeaterSequence;
    RepeatUntilFail repeatUntilFail;

    // Use this for initialization
    void Start () {
        //Init_Repeater_Sequence();
        Init_RepeaterUntilFail();
	}

	void Update () {
        //testAI.Activity();
        //randomAI.Activity();
        //repeaterSequence.Activity();
        repeatUntilFail.Activity();
    }

    void Init_RepeaterUntilFail()
    {
        repeatUntilFail = new RepeatUntilFail();
        var sequence = new Sequence();

        var sayHelloAction = new Action(SayHello);
        var sayAnshoriAction = new Action(SayAnshori);
        var SayPENSAction = new Action(SayPENS);
        var SaySurabayaAction = new Action(SaySurabaya);

        sequence.AddNode(sayHelloAction);
        sequence.AddNode(sayAnshoriAction);
        sequence.AddNode(SayPENSAction);
        sequence.AddNode(SaySurabayaAction);

        repeatUntilFail.AddNode(sequence);
    }

    void Init_Repeater_Sequence()
    {
        repeaterSequence = new Repeater(5);
        var sequence = new Sequence();

        var sayHelloAction = new Action(SayHello);
        var sayAnshoriAction = new Action(SayAnshori);

        sequence.AddNode(sayHelloAction);
        sequence.AddNode(sayAnshoriAction);

        repeaterSequence.AddNode(sequence);
    }

    void Init_1()
    {
        testAI = new Selector();
        randomAI = new RandomSelector();
        var SayHelloAction = new Action(SayHello);
        var SayAnshoriAction = new Action(SayAnshori);
        var SayPENSAction = new Action(SayPENS);
        var SaySurabayaAction = new Action(SaySurabaya);

        var Sequence_1 = new Sequence();
        var Sequence_2 = new Sequence();

        var SayHelloInvertedAction = new Inverter();
        SayHelloInvertedAction.AddNode(SayHelloAction);

        Sequence_1.AddNode(SayHelloInvertedAction);
        Sequence_1.AddNode(SayAnshoriAction);

        Sequence_2.AddNode(SayPENSAction);
        Sequence_2.AddNode(SaySurabayaAction);

        testAI.AddNode(Sequence_1);
        testAI.AddNode(Sequence_2);

        randomAI.AddNode(SayHelloAction);
        randomAI.AddNode(SayAnshoriAction);
        randomAI.AddNode(SayPENSAction);
        randomAI.AddNode(SaySurabayaAction);
    }
	
	// Update is called once per frame

    public ReturnValue SayHello()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Hello");
            return ReturnValue.Succeed;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Failed");
            return ReturnValue.Failed;
        }
        else
        {
            Debug.Log("Say Hello Running");
            return ReturnValue.Running;
        }
    }

    public ReturnValue SayAnshori()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Anshori");
            return ReturnValue.Succeed;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return ReturnValue.Failed;
        }
        else
        {
            Debug.Log("Say Anshori Running");
            return ReturnValue.Running;
        }
    }

    public ReturnValue SayPENS()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("PENS");
            return ReturnValue.Succeed;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return ReturnValue.Failed;
        }
        else
        {
            Debug.Log("Say PENS Running");
            return ReturnValue.Running;
        }
    }

    public ReturnValue SaySurabaya()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Surabaya");
            return ReturnValue.Succeed;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return ReturnValue.Failed;
        }
        else
        {
            Debug.Log("Say Surabaya Running");
            return ReturnValue.Running;
        }
    }
}
