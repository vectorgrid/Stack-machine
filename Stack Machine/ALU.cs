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

        /*
         * instruction(64bit) = header(2bit) + overflow protection(2bit) + data(60bit)
         * */

        private void initialize()
        {
            this.typeEnCoder = new TypeEnCoder();
            this.typeDeCoder = new TypeDeCoder();
        }
        private UInt64 getInstType(UInt64 instruction)
        {
            UInt64 type = (instruction & Constants.HEADER_FILTER) >> 62;
            return type;
        }

        private Int64 getInstData(UInt64 instruction)
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
    }
}
