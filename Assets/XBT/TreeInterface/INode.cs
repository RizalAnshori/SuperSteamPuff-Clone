using UnityEngine;
using System.Collections;

namespace XBT
{
    public interface INode
    {
        ReturnValue Activity();
        void Reset();
    }

    public enum ReturnValue
    {
        Succeed,
        Failed,
        Running
    }
}