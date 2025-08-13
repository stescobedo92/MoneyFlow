using MoneyFlow.Context;
using MoneyFlow.DTOs;
using MoneyFlow.Entities;

namespace MoneyFlow.Managers;

public class TransactionManager(AppDbContext _dbContext)
{
    public int NewTransaction(TransactionDTO transactionDTO)
    {
        var transactionEntity = new Transaction
        {
            Date = transactionDTO.Date,
            TotalAmount = transactionDTO.TotalAmount,
            Comment = transactionDTO.Comment,
            ServiceId = transactionDTO.ServiceId,
            UserId = transactionDTO.UserId
        };

        _dbContext.Transactions.Add(transactionEntity);
        int affectedRows = _dbContext.SaveChanges();

        return affectedRows;
    }
}
