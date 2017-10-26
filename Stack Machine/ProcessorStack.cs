using System;
using System.Collections.Generic;
namespace Stack_Machine
{
    class ProcessorStack
    {
        private Stack<Int64> stack_memory;
        private int stack_mem_size;
        private int top_of_stack;

        public ProcessorStack(int stack_mem_size)
        {
            this.stack_memory = new Stack<Int64>();
            this.stack_mem_size = stack_mem_size;
            this.top_of_stack = -1;
        }

        public int Stack_mem_size { get => this.stack_mem_size; }

        public int Top_of_stack { get => this.top_of_stack; }

        public bool Push(Int64 entity)
        {
            Int64 curr_stack_size = this.stack_memory.Count * sizeof(Int64);
            if (curr_stack_size + sizeof(Int64) > this.Stack_mem_size)
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

        public Int64 Pop()
        {
            if(this.top_of_stack > -1)
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
