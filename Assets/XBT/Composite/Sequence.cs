using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace XBT
{
    public class Sequence : IComposite
    {

        List<INode> sequenceNodeList = new List<INode>();
        int index = 0;
        ReturnValue returnValue;

        public ReturnValue Activity()
        {
            if (index >= sequenceNodeList.Count)
            {
                return ReturnValue.Succeed;
            }
            else
            {
                returnValue = sequenceNodeList[index].Activity();
                if (returnValue == ReturnValue.Succeed)
                {
                    index++;
                    return ReturnValue.Running;
                }
                else
                {
                    //Debug.Log("Sequence condition : " + returnValue);
                    return returnValue;
                }
            }
        }

        public void AddNode(INode Node)
        {
            sequenceNodeList.Add(Node);
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
