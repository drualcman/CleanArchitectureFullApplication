using CleanArchitectureFullApplication.Dto.Common;
using CleanArchitectureFullApplication.Main.Specifications;
using CleanArchitectureFullApplication.Sales.UseCases.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using LinqExpresionSQL;

namespace CleanArchitectureFullApplication.Dapper.Repository
{
    public class OrderReadableRepository : IOrderReadableRepository
    {
        readonly IDbConnection Connection;

        public OrderReadableRepository(IDbConnection connection)
        {
            Connection = connection;
        }

        public IEnumerable<OrderDto> GetOrdersWithDetailBySpecification(Specification<OrderDto> specification)
        {
            string fields = "o.id, o.CustomerId, o.OrderDate, o.ShipAddress, o.ShipCity, o.ShipCountry, o.ShipPostalCode" +
                ", d.ProductId, d.UnitPrice, d.Quantity" +
                ", c.Name as CustomerName, p.Name as ProductName";
            string tables = "Orders o " +
                "inner join OrderDetails d on o.id = d.orderId " +
                "inner join Customers c on o.CustomerId = c.Id " +
                "inner join Products p on d.ProductId = p.Id";
            Translator translator = new Translator();
            string where = translator.Translate(specification, specification.ConditionExpression);
            string sql = $"SELECT {fields} FROM {tables} WHERE {where}";            

            Connection.Open();
            IEnumerable<OrderDto> result = Connection.Query<OrderDto>(sql);
            Connection.Close();
            return result;
        }
    }
}
