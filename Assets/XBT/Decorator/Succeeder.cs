using UnityEngine;
using System.Collections;
using System;

namespace XBT
{
    public class Succeeder : IDecorator
    {
        INode succeederChildNode;

        public ReturnValue Activity()
        {
            var childNodeValue = succeederChildNode.Activity();
            if (childNodeValue == ReturnValue.Running)
            {
                return ReturnValue.Running;
            }
            else
            {
                return ReturnValue.Succeed;
            }
        }

        public void AddNode(INode Node)
        {
            if (Node != null)
            {
                succeederChildNode = Node;
            }
            else
            {
                throw new UnassignedReferenceException();
            }
        }

        public void Reset()
        {
        }
    }
}