using UnityEngine;
using System.Collections;
using System;

namespace XBT
{
    public class RepeatUntilFail : IDecorator
    {
        INode repeatUntilFailChildNode;
        ReturnValue childNodeValue = ReturnValue.Running;

        public ReturnValue Activity()
        {
            //var childNodeValue = repeatUntilFailChildNode.Activity();
            if (childNodeValue != ReturnValue.Running)
            {
                if (childNodeValue == ReturnValue.Succeed)
                {
                    Debug.Log("Succeed or Running in RepeatUntilFail");
                    childNodeValue = repeatUntilFailChildNode.Activity();
                    repeatUntilFailChildNode.Reset();
                    return ReturnValue.Running;
                }
                else
                {
                    return ReturnValue.Succeed;
                }
            }
            else
            {
                childNodeValue = repeatUntilFailChildNode.Activity();
                return ReturnValue.Running;
            }
            //if (childNodeValue == ReturnValue.Failed)
            //{
            //    return ReturnValue.Succeed;
            //}
            //else if(childNodeValue == ReturnValue.Succeed)
            //{
            //    repeatUntilFailChildNode.Reset();
            //    return ReturnValue.Running;
            //}
            //else
            //{
            //    return ReturnValue.Running;
            //}
        }

        public void AddNode(INode Node)
        {
            repeatUntilFailChildNode = Node;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}