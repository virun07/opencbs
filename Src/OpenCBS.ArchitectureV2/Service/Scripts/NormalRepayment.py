# -*- coding: utf-8 -*-

def RepayCommission(installment):
    global amount
    if amount > 0:
        if installment.CommissionsUnpaid.Value < amount:
            installment.PaidCommissions += installment.CommissionsUnpaid
            amount -= installment.CommissionsUnpaid.Value
        else:
            installment.PaidCommissions = installment.PaidCommissions.Value + amount
            amount = 0
    return installment

def RepayPenalty(installment):
    global amount
    if amount > 0:
        if installment.FeesUnpaid.Value < amount:
            installment.PaidFees += installment.FeesUnpaid
            amount -= installment.FeesUnpaid.Value
        else:
            installment.PaidFees = installment.PaidFees.Value + amount
            amount = 0
    return installment

def RepayInterest(installment):
    global amount    
    if amount > 0:
        interestUnpaid = installment.InterestsRepayment - installment.PaidInterests
        if interestUnpaid.Value < amount:
            installment.PaidInterests += interestUnpaid
            amount -= interestUnpaid.Value            
        else:
            installment.PaidInterests = installment.PaidInterests.Value + amount
            amount = 0
    return installment

def RepayPrincipal(installment):
    global amount
    if amount > 0:
        principalUnpaid = installment.CapitalRepayment - installment.PaidCapital
        if principalUnpaid.Value < amount:
            installment.PaidCapital += principalUnpaid
            amount -= principalUnpaid.Value
        else:
            installment.PaidCapital = installment.PaidCapital.Value + amount
            amount = 0
    return installment

def Repay(configuration):
    global amount
    i = 0
    amount = configuration.Amount
    installments = configuration.Loan.InstallmentList
    while amount > 0 and len(installments) > i:       
        installment = installments[i]
        installment = RepayCommission(installment)
        installment = RepayPenalty(installment)
        installment = RepayInterest(installment)
        installment = RepayPrincipal(installment)
        i += 1
