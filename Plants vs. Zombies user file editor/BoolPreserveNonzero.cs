using System;
using System.Collections.Generic;
using System.Text;

namespace Plants_vs.Zombies_user_file_editor
{
    // A BoolPreserveNonzero represents a boolean value using an Int32, with zero representing false,
    // and true represented by some nonzero value. If the original value is false, true will be represented
    // by 1, otherwise it will be represented by its original value. This helps with compatibility with
    // future versions of a file format.
    class BoolPreserveNonzero
    {
        private int origIntValue;
        public int IntValue;

        public BoolPreserveNonzero(int origIntValue)
        {
            this.IntValue = this.origIntValue = origIntValue;
        }

        public bool Value
        {
            get
            {
                return IntValue != 0;
            }
            set
            {
                if (value)
                {
                    IntValue = (origIntValue != 0) ? origIntValue : 1;
                }
                else
                {
                    IntValue = 0;
                }
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
