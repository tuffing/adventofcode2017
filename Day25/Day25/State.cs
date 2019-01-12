using System.Collections.Generic;

namespace Day25
{
    public class State
    {
        /**In state F:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the left.
    - Continue with state E.
  If the current value is 1:
    - Write the value 1.
    - Move one slot to the right.
    - Continue with state A.*/

        public string Name;
        public int IfZeroValue; 
        public string IfZeroPos; 
        public string IfZeroStateName;
        public State IfZeroState;
        
        public int IfOneValue; 
        public string IfOnePos; 
        public string IfOneStateName;
        public State IfOneState;

        public State(string name, int ifZeroValue, string ifZeroPos, string ifZeroStateName, int ifOneValue, string ifOnePos, string ifOneStateName)
        {
            Name = name;
            IfZeroValue = ifZeroValue;
            IfZeroPos = ifZeroPos;
            IfZeroStateName = ifZeroStateName;
            IfOneValue = ifOneValue;
            IfOnePos = ifOnePos;
            IfOneStateName = ifOneStateName;
        }

        public void IniNextStates(Dictionary<string, State> states)
        {
            IfZeroState = states[IfZeroStateName];
            IfOneState = states[IfOneStateName];
        }

        public (LinkedListNode<int>, State) RunMachine(LinkedListNode<int> node, LinkedList<int> nodes)
        {
            if (node.Value == 0)
            {
                node.Value = IfZeroValue;

                node = NextNode(IfZeroPos, node, nodes);
                
                return (node, IfZeroState);
            }
            
            node.Value = IfOneValue;
            
            node = NextNode(IfOnePos, node, nodes);

            return (node, IfOneState);
        }

        private LinkedListNode<int> NextNode(string dir, LinkedListNode<int> node, LinkedList<int> nodes)
        {
            if (dir == "left")
            {
                if (node.Previous == null)
                    nodes.AddFirst(new LinkedListNode<int>(0));

                return node.Previous;
            }
            
            if (node.Next == null)
                nodes.AddLast(new LinkedListNode<int>(0));

            return node.Next;
        }
    }
}