using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class DataSetNumBuilder
    {
        public Staff_database.DataSetNum _entity = new Staff_database.DataSetNum(0, 0);

        public DataSetNumBuilder ZeroSize()
        {
            _entity = new Staff_database.DataSetNum(0, 0);
            return this;
        }

        public DataSetNumBuilder MinTableSize()
        {
            _entity = new Staff_database.DataSetNum(10, 4);
            return this;
        }

        public DataSetNumBuilder MaxTableSize()
        {
            _entity = new Staff_database.DataSetNum(20, 8);
            return this;
        }

        public Staff_database.DataSetNum Build()
        {
            return _entity;
        }

    }
}
