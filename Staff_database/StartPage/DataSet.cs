﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff_database
{
    public class DataSetNum
    {
        public int row { get; set; }
        public int column { get; set; }

        public DataSetNum(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}
