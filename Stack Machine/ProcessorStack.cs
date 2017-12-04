using System;
using System.Collections.Generic;
namespace Stack_Machine
{
    class ProcessorStack
    {
        private Stack<UInt64> stack_memory;
        private UInt64 stack_mem_size;
        private Int64 top_of_stack;

        public ProcessorStack(UInt64 stack_mem_size)
        {
            this.stack_memory = new Stack<UInt64>();
            this.stack_mem_size = stack_mem_size;
            this.top_of_stack = -1;
        }

        public UInt64 Stack_mem_size { get => this.stack_mem_size; }

        public Int64 Top_of_stack { get => this.top_of_stack; }

        public bool Push(UInt64 entity)
        {
            UInt64 curr_stack_size = (UInt64 )this.stack_memory.Count * (UInt64)sizeof(UInt64);
            if (curr_stack_size + sizeof(UInt64) > this.Stack_mem_size)
            {
                throw new Exception("Processor Stack Out of Memory");
            }
            else
            {
                this.stack_memory.Push(entity);
                if(this.stack_memory.Peek() == entity)
                {
                    ++this.top_of_stack;
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }

        public UInt64 Pop()
        {
            if(this.top_of_stack > 0)
            {
                --this.top_of_stack;
                return this.stack_memory.Pop();
            }
            else
            {
                throw new Exception("Processor Stack is Empty");
            }
        }
        
        
    }
}
