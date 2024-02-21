namespace ModularMonolith.Modules.Wallets.Application.Wallets.Commands;

public record TransferFunds(Guid FromWalletId, Guid ToWalletId, decimal Amount); //: ICommand;