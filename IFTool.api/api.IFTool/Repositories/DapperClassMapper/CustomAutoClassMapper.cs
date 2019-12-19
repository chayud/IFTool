using System;
using System.Linq;


namespace api.IFTool.Repositories.DapperClassMapper
{
    public class CustomAutoClassMapper<T> : DapperExtensions.Mapper.AutoClassMapper<T> where T : class
    {




        public override void Table(string tableName)
        {


            Type classType = typeof(T);
            tableName = GetTableName(classType);
            base.Table(tableName);

        }

        public override void Schema(string schemaName)
        {
            Type classType = typeof(T);
            schemaName = GetSchemaName(schemaName, classType);
            base.Schema(schemaName);
        }

        //Gets the table name for this entity
        //For Inserts and updates we have a whole entity so this method is used
        //Uses class name by default and overrides if the class has a Table attribute
        private string GetTableName(object entity)
        {
            var type = entity.GetType();
            return GetTableName(type);
        }

        //Gets the table name for this type
        //For Get(id) and Delete(id) we don't have an entity, just the type so this method is used
        //Use dynamic type to be able to handle both our Table-attribute and the DataAnnotation
        //Uses class name by default and overrides if the class has a Table attribute
        private string GetTableName(Type type)
        {
            var tableName = String.Format("[{0}]", type.Name);
            var tableattr = type.GetCustomAttributes(true).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute") as dynamic;
            if (tableattr != null)
            {
                tableName = String.Format("[{0}]", tableattr.Name);
            }

            tableName = tableName.Replace("[", "").Replace("]", "");
            return tableName;
        }

        private static string GetSchemaName(string schema, Type type)
        {

            var tableattr = type.GetCustomAttributes(true).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute") as dynamic;
            if (tableattr != null)
            {
                try
                {
                    if (!String.IsNullOrEmpty(tableattr.Schema))
                    {
                        schema = tableattr.Schema;
                    }
                }
                catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
                {
                    //Schema doesn't exist on this attribute.
                }
            }
            return schema;
        }

    }


}
