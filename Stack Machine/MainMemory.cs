using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_Machine
{
    class MainMemory
    {
        private UInt64 [] memory;
        private UInt64 memory_size;
        public MainMemory(UInt64 ram_size)
        {
            this.memory_size = ram_size * 1024 / 8;
            this.memory = new UInt64[memory_size];
        }
        
        public UInt64 GetInstructionAt(UInt64 instruction_pointer)
        {
            if(instruction_pointer < this.memory_size)
            {
                return memory[instruction_pointer];
            }
            else
            {
                throw new Exception("Instruction pointer beyond main memory size");
            }
        }

        public bool SetDataAt(UInt64 location, UInt64 data)
        {
            this.memory[location] = data;
            return true;
        }
    }
}
