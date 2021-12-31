using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XBT;

public partial class EnemyInput {
    INode behaviorTreeParent;
    Repeater movement;
    Repeater avoid;

    void Awake()
    {
        InitBT();
    }

    void InitBT()
    {
        InitMovement();
        InitAvoid();

        behaviorTreeParent = avoid;
    }

    void InitMovement()
    {
        movement = new Repeater(0);
        var sequence = new Sequence();

        Action movementAction = new Action(Chase);

        sequence.AddNode(movementAction);

        movement.AddNode(sequence);
    }

    void InitAvoid()
    {
        avoid = new Repeater(0);
        var sequence = new Sequence();

        Action evadeAction = new Action(Avoid);

        sequence.AddNode(evadeAction);

        avoid.AddNode(sequence);
    }
}
