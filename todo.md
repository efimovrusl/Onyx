# Backend TODO

Short backend-only backlog for unfinished implementation work. Sorted roughly from easiest/clearest to hardest/vaguest.

## Expense queries

- Implement `IExpenseQueries.GetConsumerExpenses(...)` / `ExpenseQueries.GetConsumerExpenses(...)`.
  - `ExpenseRepository.GetByConsumerId(...)` already exists.
  - Also filter by `groupId`; currently the consumer repository query only filters by consumer.

## Expense repository helpers

- Implement `IExpenseRepository.GetPayers(...)` / `ExpenseRepository.GetPayers(...)`.
- Implement `IExpenseRepository.GetConsumers(...)` / `ExpenseRepository.GetConsumers(...)`.

## Expense mutation

- Implement `IExpenseCommands.UpdateExpenseDescription(...)` down to `ExpenseRepository.UpdateDescription(...)`.
- Implement `IExpenseCommands.UpdatePayers(...)` down to `ExpenseRepository.UpdatePayers(...)`.
- Implement `IExpenseCommands.UpdateConsumers(...)` down to `ExpenseRepository.UpdateConsumers(...)`.
- Implement `IExpenseCommands.DeleteExpense(...)` down to `ExpenseRepository.Delete(...)`.

## Group deletion

- Implement `IGroupCommands.DeleteGroup(...)` down to `GroupRepository.Delete(...)`.
- Decide whether group deletion should be hard-delete or soft-delete.

## Users

- Implement `IUserRepository`.
- Implement user commands.
- Implement user queries.
- Register user services/repository in DI.

## Database setup

- Wire schema bootstrap/migrations into the dev flow.
- Current SQL scripts exist, but are not automatically applied by the API/Compose setup.

## API error behavior

- Replace raw not-found exceptions with explicit not-found handling.
- Map expected backend failures to useful HTTP responses.

## Validation

- Validate group names and member IDs.
- Validate expense amount, payer list, consumer list, shares, and totals.
- Validate user/group membership rules before writing expenses.

## Debt queries

- Implement `IDebtQueries.GetTotalGroupDebt(...)`.
- Implement `IDebtQueries.GetTotalGroupOwed(...)`.
- Implement `IDebtQueries.GetGroupDebts(...)`.
- Define exact debt rules for multiple payers, consumer shares, and currencies.

## Settlement

- Implement `ISettlementCommands.SettleDebt(...)` after the debt model is clear.

