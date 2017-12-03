using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_Machine
{
    class Constants
    {
        public const UInt64 NEGATIVE_HEADER = 0x4000000000000000;
        public const UInt64 POSITIVE_HEADER = 0;
        public const Int64 NAN = 0x2000000000000000;
        public const UInt64 DATA_MAX = 0x0FFFFFFFFFFFFFFF;
        public const UInt64 HEADER_FILTER = 0xc000000000000000;
        public const UInt64 DATA_FILTER = 0x0FFFFFFFFFFFFFFF;
        public const UInt64 REMOVE_HEADER = 0x3FFFFFFFFFFFFFFF;
    }
}
