using UnityEngine;
using System.Collections;

namespace XBT
{
    public interface IComposite : INode
    {
        void AddNode(INode Node);
    }
}