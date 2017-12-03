using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_Machine
{
    class TypeDeCoder
    {
        public TypeDeCoder()
        {
        }

        public Int64 Decoder(UInt64 instruction)
        {
            UInt64 header = (instruction & Constants.HEADER_FILTER) >> 62;
            if((instruction & Constants.REMOVE_HEADER) < Constants.DATA_MAX)
            {
                if (header == 0)
                {
                    return (Int64)(instruction & Constants.DATA_FILTER);
                }
                else if (header == 1)
                {
                    Int64 decoded_data = (Int64)(instruction & Constants.DATA_FILTER);
                    return (Int64)(-1 * decoded_data);
                }
                else
                {
                    return Constants.NAN; 
                }
            }
            else
            {
                throw new Exception("Instruction size greater than 60bits");
            }
            
        }
    }
}
