using ApplicationCore.Interfaces.RepositoryInterfaces;
using Dapper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

        public Task<int> CreateAsync(Invoice entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Invoice>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spInvoice_GetAll";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync
                        <Invoice, StaffMember, CounterAgent, Warehouse, InvoiceProduct, Invoice>(
                        sql: procedure,
                        map: (invoice, staffMember, counterAgent, warehouse, invoiceProduct) => {
                            invoice.CreatedStaff = staffMember;
                            invoice.CounterAgent = counterAgent;
                            invoice.Warehouse = warehouse;
                            invoice.Products.Add(invoiceProduct);
                            return invoice;
                        },
                        splitOn: "InvoiceId, WarehouseId, CounterAgentId, StaffMemberId, ProductId"
                        ))
                        .ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public Task<Invoice> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Invoice entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
