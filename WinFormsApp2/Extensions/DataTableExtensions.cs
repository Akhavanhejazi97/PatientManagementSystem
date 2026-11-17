using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace WinFormsApp2.Extensions
{
    public static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Type propertyType =
                    Nullable.GetUnderlyingType(property.PropertyType)
                    ?? property.PropertyType;

                dataTable.Columns.Add(property.Name, propertyType);
            }

            foreach (T item in items)
            {
                DataRow row = dataTable.NewRow();

                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(item);

                    row[property.Name] = value ?? DBNull.Value;
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}