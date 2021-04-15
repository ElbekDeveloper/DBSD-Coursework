using ApplicationCore.Interfaces.RepositoryInterfaces;
using Dapper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SqlInfrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> CreateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var procedure = "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";
        //public int ProductId { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public decimal? Price { get; set; }
        //public DateTime ManufacturedDate { get; set; }
        //public DateTime ExpirationDate { get; set; }
        //public Manufacturer Manufacturer { get; set; }
        //public MeasurementUnit MeasurementUnit { get; set; }
        var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Price", entity.Price, DbType.Decimal);
                parameters.Add("Quantity", entity.Quantity, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(sql:procedure, param: parameters, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<int> DeleteAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spProduct_GetAll";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync
                        <Product, Manufacturer, MeasurementUnit, Product>(
                        sql: procedure,
                        map: (product, manufacturer, measurementUnit) => {
                            product.Manufacturer = manufacturer;
                            product.MeasurementUnit = measurementUnit;
                            return product;
                        },
                        splitOn: "ManufacturerId, MeasurementUnitId"
                        ))
                        .ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spProduct_GetById";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync
                        <Product, Manufacturer, MeasurementUnit, Product>(
                        sql: procedure,
                        map: (product, manufacturer, measurementUnit) =>
                        {
                            product.Manufacturer = manufacturer;
                            product.MeasurementUnit = measurementUnit;
                            return product;
                        },
                        param: parameters,
                        splitOn: "ManufacturerId, MeasurementUnitId",
                        commandType: CommandType.StoredProcedure
                        )).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public Task<int> UpdateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
