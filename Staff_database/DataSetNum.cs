using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff_database
{
    public class DataSetNum
    {
        private int rows = 0;
        private int columns = 0;

        public DataSetNum(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }
    }
}
