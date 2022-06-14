import pandas as pd
from efficient_apriori import apriori

def searchWhereFrom(dataW, dataF):
    for i in dataF:
        if i in dataW:
            return True
    return False

dataset = pd.read_excel('weatherHistoryFinal.xlsx')
dataset.head()

shape1 = len(dataset)
shape2 = len(dataset.columns)
transactions = []
for i in range(shape1):
    transactions.append([str(dataset.values[i, j]) for j in range(shape2)])

itemsets, rules = apriori(transactions, min_support = 0.003, min_confidence = 0.2, max_length=4)

listRules = []
for rule in rules:
    toAdd = [rule.lhs,
             rule.rhs,
             round(rule.confidence, 3),
             round(rule.lift, 3),
             round(rule.support, 3),
             round(rule.conviction, 3)]
    if len(rule.rhs) == 1 and searchWhereFrom(list(dataset['Summary']), list(rule.lhs)) == False:
        listRules.append(toAdd)

pdRules = pd.DataFrame(listRules)
pdRules.columns = ["Left", "Right", "Confidence", "Lift", "Support", "Conviction"]
pdRules = pdRules.sort_values(['Confidence', 'Lift'], ascending=[False, False])
pdRules.to_excel("Rules.xlsx")
