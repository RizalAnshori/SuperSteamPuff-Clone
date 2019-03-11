using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XBT
{
    public class RandomSelector : IComposite
    {

        List<INode> RandomSelectorNodeList = new List<INode>();
        int index = 0;
        int seed = 10;
        ReturnValue returnValue;

        public ReturnValue Activity()
        {
            returnValue = RandomSelectorNodeList[index].Activity();
            if (returnValue == ReturnValue.Failed)
            {
                index = GetRandomIndex();
                return ReturnValue.Running;
            }
            else
            {
                return returnValue;
            }
        }

        public void AddNode(INode Node)
        {
            RandomSelectorNodeList.Add(Node);
        }

        public void Reset()
        {

        }

        int GetRandomIndex()
        {
            int randomIndex = Random.Range(1, RandomSelectorNodeList.Count * seed) % RandomSelectorNodeList.Count;
            return randomIndex;
        }
    }
}
