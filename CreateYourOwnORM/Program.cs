using System;
using System.Data;
using System.Data.SqlClient;

namespace CreateYourOwnORM
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public static class DBHelperExtensions
    {
        public static void CreateAndAddInputParameter(this SqlCommand command, DbType type, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.Direction = ParameterDirection.Input;
            parameter.DbType = type;
            parameter.ParameterName = name;

            if (value == null)
            {
                parameter.IsNullable = true;
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = value;
            }

            command.Parameters.Add(parameter);
        }
    }


    [Table("EmployeeTable")]
    public class EmployeeType
    {
        [PrimaryKey("PK_EE_Type_ID")]
        public Guid Id { get; set; }

        [Column("Name")]
        public string TypeName { get; set; }
    }


    [Table("EmployeeTable")]
    public class Employee
    {
        [PrimaryKey("PK_EE_ID")]
        public Guid Id { get; set; }

        [Column("LName")]
        public string LastName { get; set; }

        [Column("FName")]
        public string FirstName { get; set; }

        [Reference("FK_EE_Type_ID")]
        public EmployeeType EmployeeType {get; set;}
    }
}
