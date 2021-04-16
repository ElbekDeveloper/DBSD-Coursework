using ApplicationCore.Helpers.Filters;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Resources;
using Dapper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using SqlInfrastructure.DbScripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SqlInfrastructure.Repositories
{
    public class InvoiceRepository : BaseRepository, IInvoiceRepository
    {
        public InvoiceRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> CreateInvoiceAsync(AddInvoiceResource entity, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    string procedureInvoice = "spInvoice_Insert";

                    #region Parameters for Invoice Stored Procedure
                    var invoiceParams = new DynamicParameters();
                    invoiceParams.Add("@Id", 0, DbType.Int32, ParameterDirection.Output);
                    invoiceParams.Add("CreatedDate", entity.CreatedDate, DbType.Date);
                    invoiceParams.Add("ConfirmationStatus", entity.ConfirmationStatus, DbType.Boolean);
                    invoiceParams.Add("TotalCost", entity.TotalCost, DbType.Decimal);
                    invoiceParams.Add("CreatedStaffId", entity.CreatedStaffId, DbType.Int32);
                    invoiceParams.Add("AgentId", entity.AgentId, DbType.Int32);
                    invoiceParams.Add("WarehouseId", entity.WarehouseId, DbType.Int32);

                    #endregion

                    string procedureInvoiceProduct = "spInvoiceProduct_Insert";

                    #region Parameter for InvoiceProduct Stored Procedure
                    var invoiceProductParams = entity.Products;

                    #endregion
                    connection.Open();

                    using (var transac = connection.BeginTransaction())
                    {
                        int recordsAffected = await connection.ExecuteAsync(
                            sql: procedureInvoice,
                            param: invoiceParams,
                            commandType: CommandType.StoredProcedure,
                            transaction: transac);
                        //Get newly created InvoiceId
                        int newInvoiceId = invoiceParams.Get<int>("@Id");
                        invoiceProductParams.ForEach(p => p.InvoiceId = newInvoiceId);
                        try
                        {
                            await connection.ExecuteAsync(
                                sql: procedureInvoiceProduct,
                                param: invoiceProductParams,
                                commandType: CommandType.StoredProcedure,
                                transaction: transac
                                );
                            transac.Commit();
                        }
                        catch (Exception ex)
                        {
                            transac.Rollback();
                            throw new Exception(ex.Message, ex);
                        }
                        return newInvoiceId;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Not implemented yet!
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> CreateAsync(Invoice entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //try
            //{
            //    using (var connection = CreateConnection())
            //    {
            //        string procedureInvoice = "spInvoice_Insert";

            //        #region Parameters for Invoice Stored Procedure
            //        var invoiceParams = new DynamicParameters();
            //        invoiceParams.Add("@Id", 0, DbType.Int32, ParameterDirection.Output);
            //        invoiceParams.Add("CreatedDate", entity.CreatedDate, DbType.Date);
            //        invoiceParams.Add("ConfirmationStatus", entity.ConfirmationStatus, DbType.Boolean);
            //        invoiceParams.Add("CreatedStaffId", entity.CreatedStaff.StaffMemberId, DbType.Int32);
            //        invoiceParams.Add("AgentId", entity.CounterAgent.CounterAgentId, DbType.Int32);
            //        invoiceParams.Add("WarehouseId", entity.Warehouse.WarehouseId, DbType.Int32);

            //        #endregion

            //        string procedureInvoiceProduct = "spInvoiceProduct_Insert";

            //        #region Parameter for InvoiceProduct Stored Procedure
            //        var invoiceProductParams = new DynamicParameters();

            //        #endregion
            //        connection.Open();

            //        using (var transac = connection.BeginTransaction())
            //        {
            //            int recordsAffected = await connection.ExecuteAsync(
            //                sql: procedureInvoice,
            //                param: invoiceParams,
            //                commandType: CommandType.StoredProcedure,
            //                transaction: transac);
            //            //Get newly created InvoiceId
            //            int newInvoiceId = invoiceParams.Get<int>("@Id");
            //            try
            //            {
            //                //delete invoice related rows from relationship table
            //                await connection.ExecuteAsync(
            //                    sql: procedureInvoiceProduct,
            //                    param: invoiceProductParams,
            //                    commandType: CommandType.StoredProcedure,
            //                    transaction: transac
            //                    );
            //                transac.Commit();
            //            }
            //            catch (Exception ex)
            //            {
            //                transac.Rollback();
            //                throw new Exception(ex.Message, ex);
            //            }
            //            return newInvoiceId;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception(ex.Message, ex);
            //}
        }

        public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spInvoice_Delete";
                var parameters = new DynamicParameters();
                parameters.Add("InvoiceId", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    var result = await connection.ExecuteAsync
                        (
                        sql: procedure,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                        );
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spInvoice_GetAll";
                using (var connection = CreateConnection())
                {
                    var data = (await connection.QueryAsync
                        <Invoice, StaffMember, CounterAgent, Warehouse, InvoiceProduct, Invoice>(
                        sql: procedure,
                        map: (invoice, staffMember, counterAgent, warehouse, invoiceProduct) => {
                            invoice.CreatedStaff = staffMember;
                            invoice.CounterAgent = counterAgent;
                            invoice.Warehouse = warehouse;
                            invoice.Products.Add(invoiceProduct);
                            return invoice;
                        },
                        splitOn: "InvoiceId, WarehouseId, CounterAgentId, StaffMemberId, ProductId",
                        commandType: CommandType.StoredProcedure
                        ))
                        .ToList();

                    var result = data.GroupBy(p => p.InvoiceId).Select(g =>
                    {
                        var groupedInvoice = g.First();
                        groupedInvoice.Products= g.Select(p => p.Products.Single()).ToList();
                        return groupedInvoice;
                    });

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Invoice> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spInvoice_GetById";
                var parameters = new DynamicParameters();
                parameters.Add("InvoiceId", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    var data = (await connection.QueryAsync
                        <Invoice, Warehouse, CounterAgent, StaffMember, InvoiceProduct, Invoice>(
                        sql: procedure,
                        map: (invoice, warehouse, counterAgent, staffMember, invoiceProduct) => {
                            invoice.Warehouse = warehouse;
                            invoice.CounterAgent = counterAgent;
                            invoice.CreatedStaff = staffMember;
                            invoice.Products.Add(invoiceProduct);
                            return invoice;
                        },
                        param: parameters,
                        splitOn: "InvoiceId, WarehouseId, CounterAgentId, StaffMemberId, ProductId",
                        commandType: CommandType.StoredProcedure
                        ))
                        .ToList();

                    var result = data.GroupBy(p => p.InvoiceId).Select(g =>
                    {
                        var groupedInvoice = g.First();
                        groupedInvoice.Products = g.Select(p => p.Products.Single()).ToList();
                        return groupedInvoice;
                    });
                    return result.FirstOrDefault<Invoice>();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public Task<int> UpdateAsync(Invoice entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateInvoiceAsync(int id, AddInvoiceResource entity, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    string procedureInvoice = "spInvoice_Update";

                    #region Parameters for Invoice Stored Procedure
                    var invoiceParams = new DynamicParameters();
                    invoiceParams.Add("@Id", id, DbType.Int32);
                    invoiceParams.Add("CreatedDate", entity.CreatedDate, DbType.Date);
                    invoiceParams.Add("ConfirmationStatus", entity.ConfirmationStatus, DbType.Boolean);
                    invoiceParams.Add("TotalCost", entity.TotalCost, DbType.Decimal);
                    invoiceParams.Add("CreatedStaffId", entity.CreatedStaffId, DbType.Int32);
                    invoiceParams.Add("AgentId", entity.AgentId, DbType.Int32);
                    invoiceParams.Add("WarehouseId", entity.WarehouseId, DbType.Int32);

                    #endregion

                    string procedureInvoiceProduct = "spInvoiceProduct_Update";

                    #region Parameter for InvoiceProduct Stored Procedure
                    var invoiceProductParams = entity.Products;
                    
                    #endregion
                    connection.Open();

                    using (var transac = connection.BeginTransaction())
                    {
                        int recordsAffected = await connection.ExecuteAsync(
                            sql: procedureInvoice,
                            param: invoiceParams,
                            commandType: CommandType.StoredProcedure,
                            transaction: transac);
                        
                        try
                        {
                            await connection.ExecuteAsync(
                                sql: procedureInvoiceProduct,
                                param: invoiceProductParams,
                                commandType: CommandType.StoredProcedure,
                                transaction: transac
                                );
                            transac.Commit();
                        }
                        catch (Exception ex)
                        {
                            transac.Rollback();
                            throw new Exception(ex.Message, ex);
                        }
                        return id;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Invoice>> GetInvoicesWithFilters(InvoiceFilter filter, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    string query =
            @"select[i].[Id] as InvoiceId, [i].[CreatedDate], [i].[ConfirmationStatus], [i].[TotalCost], [w].[Id] as WarehouseId , [w].[Address], [ca].[Id] as CounterAgentId, [ca].[FirstName], [ca].[LastName], [ca].[Address], [ca].[Email], [ca].[IsCustomer], [ca].[PhoneNumber],[sm].[Id] as StaffMemberId, [sm].[FirstName], [sm].[LastName], [sm].[Address], [sm].[Email], [sm].[RegisterDate], [sm].[PhoneNumber], [p].[Id] as ProductId, [p].[Name], [p].[Description], [p].[Price], [p].[ManufacturedDate], [p].[ExpirationDate], [m].[Name] as Manufacturer, [mu].[Name] as MeasurementUnit, [p].[QuantityAtWarehouse], [inprod].[SoldPrice], [inprod].[SoldQuantity] from dbo.Invoice i join dbo.CounterAgent ca on i.AgentId = ca.Id join dbo.Warehouse w on i.WarehouseId = w.Id join dbo.StaffMember sm on i.CreatedStaffId = sm.Id join dbo.InvoiceProduct inprod on i.Id = inprod.InvoiceId join dbo.Product p on inprod.ProductId = p.Id join dbo.Manufacturer m on p.ManufacturerId = m.Id join dbo.MeasurementUnit mu on p.MeasurementUnitId = mu.Id";
        var parameters = new DynamicParameters();

                    #region Filtration
                    string sqlWhere = "";
                    if (!string.IsNullOrWhiteSpace(filter.ProductName))
                    {
                        sqlWhere += " [p].[Name] like  '%' + rtrim(ltrim(@ProductName)) + '%' AND";
                        parameters.Add("@ProductName", filter.ProductName);
                    }

                    if (!string.IsNullOrWhiteSpace(filter.StaffName))
                    {
                        sqlWhere += " [sm].[FirstName] like rtrim(ltrim(@StaffName)) + '%' AND";
                        parameters.Add("@StaffName", filter.StaffName);
                    }
                    if (filter.DateStart.HasValue)
                    {
                        sqlWhere += " [i].[CreatedDate] >= @DateStart AND";
                        parameters.Add("@DateStart", filter.DateStart);
                    }

                    if (filter.MinPrice.HasValue)
                    {
                        sqlWhere += "  [i].[TotalCost] >= @MinPrice AND";
                        parameters.Add("@MinPrice", filter.MinPrice);
                    }
                    if (filter.MaxPrice.HasValue)
                    {
                        sqlWhere += "  [i].[TotalCost] <= @MaxPrice AND";
                        parameters.Add("@MaxPrice", filter.MaxPrice);
                    }

                    if (filter.DateEnd.HasValue)
                    {
                        sqlWhere += " [i].[CreatedDate] <= @DateEnd AND";
                        parameters.Add("@DateEnd", filter.DateEnd);
                    }

                    if (filter.AgentIsCustomer.HasValue && filter.AgentIsCustomer == true)
                    {
                        sqlWhere += " [ca].[IsCustomer] = 1 AND";
                    }
                    if (filter.AgentIsCustomer.HasValue && filter.AgentIsCustomer == false)
                    {
                        sqlWhere += " [ca].[IsCustomer] = 0 AND";
                    }

                    if (sqlWhere.Length > 0)
                        sqlWhere = " WHERE " + sqlWhere.Substring(0, sqlWhere.Length - 3);
                    #endregion

                    string sqlQuery = query + sqlWhere;
                    var data = (await connection.QueryAsync
                        <Invoice, StaffMember, CounterAgent, Warehouse, InvoiceProduct, Invoice>(
                        sql: sqlQuery,
                        map: (invoice, staffMember, counterAgent, warehouse, invoiceProduct) => {
                            invoice.CreatedStaff = staffMember;
                            invoice.CounterAgent = counterAgent;
                            invoice.Warehouse = warehouse;
                            invoice.Products.Add(invoiceProduct);
                            return invoice;
                        },
                        param: parameters,
                        splitOn: "InvoiceId, WarehouseId, CounterAgentId, StaffMemberId, ProductId",
                        commandType: CommandType.Text
                        ))
                        .ToList();

                    var result = data.GroupBy(p => p.InvoiceId).Select(g =>
                    {
                        var groupedInvoice = g.First();
                        groupedInvoice.Products = g.Select(p => p.Products.Single()).ToList();
                        return groupedInvoice;
                    });

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
