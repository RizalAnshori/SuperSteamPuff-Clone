using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace XBT
{
    public class Selector : IComposite
    {
        List<INode> selectorNodeList = new List<INode>();
        int index = 0;
        ReturnValue returnValue;

        public ReturnValue Activity()
        {
            if (index >= selectorNodeList.Count)
            {
                return ReturnValue.Failed;
            }
            else
            {
                returnValue = selectorNodeList[index].Activity();
                if (returnValue == ReturnValue.Failed)
                {
                    index++;
                    return ReturnValue.Running;
                }
                else
                {
                    return returnValue;
                }
            }
        }

        public void AddNode(INode Node)
        {
            selectorNodeList.Add(Node);
        }

        public void Reset()
        {
            index = 0;
        }
    }
}