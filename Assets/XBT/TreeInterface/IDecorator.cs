using UnityEngine;
using System.Collections;

namespace XBT
{
    public interface IDecorator : INode
    {
        void AddNode(INode Node);
    }
}