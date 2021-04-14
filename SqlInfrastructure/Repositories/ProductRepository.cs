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

        public Task<int> CreateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
