using System;
using System.Collections.Generic;
 

namespace TeamTech.Common.DataTable
{
    public class DataTableModel<T, Q>
    {
        //public IList<ColumnDataTableModel> columns { get; set; }
        public object data { get; set; }
        public int draw { get; set; }
        public T filter { get; set; }
        public Q length { get; set; }
        //public IList<OrderDataTableModel> Order { get; set; }
        public string orderBy { get; set; }
        public Q recordsFiltered { get; set; }
        public Q recordsTotal { get; set; }
        public Q start { get; set; }
        public string whereFilter { get; set; }
    }
}