using UnityEngine;
using System.Collections;
using System;

namespace XBT
{
    public class Inverter : IDecorator
    {
        INode inverterChildNode;

        public ReturnValue Activity()
        {
            var childNodeValue = inverterChildNode.Activity();
            if (childNodeValue == ReturnValue.Failed)
            {
                return ReturnValue.Succeed;
            }
            else if (childNodeValue == ReturnValue.Succeed)
            {
                return ReturnValue.Failed;
            }
            else
            {
                return ReturnValue.Running;
            }
        }

        public void AddNode(INode Node)
        {
            if (Node != null)
            {
                inverterChildNode = Node;
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
