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
                var procedure = "spProduct_Insert";
                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Description", entity.Description, DbType.String);
                parameters.Add("Price", entity.Price, DbType.Decimal);
                parameters.Add("ManufacturedDate", entity.ManufacturedDate, DbType.DateTime);
                parameters.Add("ExpirationDate", entity.ExpirationDate, DbType.DateTime);
                parameters.Add("ManufacturerId", entity.Manufacturer.ManufacturerId, DbType.Int32);
                parameters.Add("MeasurementUnitId", entity.MeasurementUnit.MeasurementUnitId, DbType.Int32);
                parameters.Add("QuantityAtWarehouse", entity.QuantityAtWarehouse, DbType.Int32);

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
                    var result = (await connection.QueryAsync
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
                        )).FirstOrDefault<Product>();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var procedure = "spProduct_Update";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", entity.ProductId, DbType.Int32);
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Description", entity.Description, DbType.String);
                parameters.Add("Price", entity.Price, DbType.Decimal);
                parameters.Add("ManufacturedDate", entity.ManufacturedDate, DbType.DateTime);
                parameters.Add("ExpirationDate", entity.ExpirationDate, DbType.DateTime);
                parameters.Add("ManufacturerId", entity.Manufacturer.ManufacturerId, DbType.Int32);
                parameters.Add("MeasurementUnitId", entity.MeasurementUnit.MeasurementUnitId, DbType.Int32);
                parameters.Add("QuantityAtWarehouse", entity.QuantityAtWarehouse, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(sql: procedure, param: parameters, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
