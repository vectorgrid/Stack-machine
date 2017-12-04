using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_Machine
{
    class ALU
    { 
        private UInt64 ip;
        private UInt64 sp;
        private UInt64 instruction;
        private UInt64 instruction_type;
        private UInt64 instruction_data;
        private TypeEnCoder typeEnCoder;
        private TypeDeCoder typeDeCoder;
        private ProcessorStack processorStack;
        private UInt64 type;
        private Int64 data;
        /*
         * instruction(64bit) = header(2bit) + overflow protection(2bit) + data(60bit)
         * */

        private void Initialize(UInt64 max_stack_size)
        {
            this.typeEnCoder = new TypeEnCoder();
            this.typeDeCoder = new TypeDeCoder();
            this.processorStack = new ProcessorStack(max_stack_size);
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
                this.instruction = processorStack.Pop();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void Decode()
        {
            this.type = this.GetInstType(this.instruction);
            this.data = this.GetInstData(this.instruction); 
        }

        private void Execute()
        {
            if(this.type == 0 || this.type == 1)
            {

            }
        }
    }
}
