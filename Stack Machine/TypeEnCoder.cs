using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_Machine
{
    class TypeEnCoder
    {
        
        public TypeEnCoder(){}
        /*
         * negative number header = 0x0100
         * positive number header = 0x0000
         * instruction number header = 0x1000
         * */
        public UInt64 Encoder(Int64 instruction)
        {
            UInt64 encoded_instruction = 0;
            UInt64 abs_instruction = (UInt64)Math.Abs(instruction);
            if (instruction < 0)
            {
                if (abs_instruction < Constants.DATA_MAX)
                {
                    encoded_instruction = encoded_instruction | Constants.NEGATIVE_HEADER;
                    encoded_instruction = encoded_instruction | abs_instruction;
                    return encoded_instruction;
                }
                else
                {
                    throw new Exception("Instruction size greater than 60bits");
                }
            }
            else
            {
                if(abs_instruction < Constants.DATA_MAX)
                {
                    encoded_instruction = encoded_instruction | Constants.POSITIVE_HEADER;
                    encoded_instruction = encoded_instruction | abs_instruction;
                    return encoded_instruction;
                }
                else
                {
                    throw new Exception("Instruction size greater than 60bits");
                }
            }
        }
        public UInt64 Encoder(UInt64 instruction)
        {
            instruction = instruction & Constants.REMOVE_HEADER;
            if(instruction < Constants.DATA_MAX)
            {
                return instruction;
            }
            else
            {
                throw new Exception("Instruction size greater than 60bits");
            }
        }
    }
}
