using UnityEngine;
using System.Collections;
using System;

namespace XBT
{
    public class Repeater : IDecorator
    {

        int counter;
        int i;
        INode repeaterChildNode;

        /// <summary>
        /// Use to Repeat the ChildTree, give zero"0" to unlimited repetation
        /// </summary>
        public Repeater(int repeatTime)
        {
            counter = repeatTime;
        }

        public ReturnValue Activity()
        {
            var childNodeValue = repeaterChildNode.Activity();
            if (counter == 0)
            {
                if (childNodeValue == ReturnValue.Running)
                {
                    return ReturnValue.Running;
                }
                else
                {
                    repeaterChildNode.Reset();
                    return ReturnValue.Running;
                }
            }
            else
            {
                while (i < counter - 1)
                {
                    if (childNodeValue == ReturnValue.Running)
                    {
                        return ReturnValue.Running;
                    }
                    else
                    {
                        i++;
                        repeaterChildNode.Reset();
                        return ReturnValue.Running;
                    }
                }
                return ReturnValue.Succeed;
            }
        }

        public void AddNode(INode Node)
        {
            if (Node != null)
            {
                repeaterChildNode = Node;
            }
            else
            {
                throw new UnassignedReferenceException();
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}