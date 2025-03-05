namespace ShareInvest.Coinone;

/// <summary>
/// normal: 입금가능
/// suspended: 입금정지
/// </summary>
public enum DepositStatus
{
    normal,
    suspended
}

/// <summary>
/// normal: 출금가능
/// suspended: 출금정지
/// </summary>
public enum WithdrawStatus
{
    normal,
    suspended
}