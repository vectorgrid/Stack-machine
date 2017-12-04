using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_Machine
{
    class ALU
    { 
        private UInt64 pc;
        private Int64 sp;
        private UInt64 memory_address_register;
        private UInt64 memory_buffer_register;
        private UInt64 current_instruction_register;

        private UInt64 instruction_type;
        private UInt64 instruction_data;

        private TypeEnCoder typeEnCoder;
        private TypeDeCoder typeDeCoder;

        private ProcessorStack processorStack;

        private MainMemory main_memory;

        private UInt64 type;
        private Int64 data;
        /*
         * instruction(64bit) = header(2bit) + overflow protection(2bit) + data(60bit)
         * */

        private void Initialize(UInt64 max_stack_size,  MainMemory main_memory)
        {
            this.typeEnCoder = new TypeEnCoder();
            this.typeDeCoder = new TypeDeCoder();
            this.processorStack = new ProcessorStack(max_stack_size);
            this.main_memory = main_memory;
        }
        private UInt64 GetInstType(UInt64 instruction)
        {
            UInt64 type = (instruction & Constants.HEADER_FILTER) >> 62;
            return type;
        }

        private Int64 GetInstData(UInt64 instruction)
        {
            Int64 data = typeDeCoder.Decoder(instruction);
            if (data == Constants.NAN)
            {
                return (Int64)(instruction & Constants.DATA_FILTER);
            }
            else
            {
                return data;
            } 
        }
        
        private bool Fetch()
        {
            try
            {
                this.memory_buffer_register = this.main_memory.GetInstructionAt(this.memory_address_register);
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void Decode()
        {
            this.current_instruction_register = this.memory_buffer_register;
            this.type = this.GetInstType(this.current_instruction_register);
            this.data = this.GetInstData(this.current_instruction_register); 
        }

        private void Execute()
        {
            if(this.type == 0 || this.type == 1)
            {
                this.processorStack.Push(this.data);
                this.sp = this.processorStack.Top_of_stack; 
            }
            else
            {
                this.DoAtomic(this.data);
            }
        }

        private void Run()
        {

        }

        private void DoAtomic(Int64 opcode)
        {
            switch (opcode)
            {
                case 0:
                    Console.WriteLine("Command"+)
                case 1:
                    Console.WriteLine("Command : Start");
                    this.Run();
                    break;
            }
        }
    }
}
