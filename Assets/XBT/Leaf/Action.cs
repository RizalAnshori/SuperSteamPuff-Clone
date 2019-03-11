using UnityEngine;
using System.Collections;
using System;

namespace XBT
{
    public class Action : INode
    {

        private ActionDelegate actionDelegate;

        public Action(ActionDelegate actionDelegate)
        {
            if (actionDelegate == null)
            {
                throw new UnassignedReferenceException();
            }
            this.actionDelegate = actionDelegate;
        }

        public ReturnValue Activity()
        {
            return actionDelegate();
        }

        public void Reset()
        {
            //throw new NotImplementedException();
        }
    }

    public delegate ReturnValue ActionDelegate();
}