using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.DB
{
    public class ATable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
