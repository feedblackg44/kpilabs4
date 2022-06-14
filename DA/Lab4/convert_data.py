import pandas as pd
import random

def RNG(chance):
    number = random.randint(1, 100)
    if number <= chance:
        return True
    else:
        return False

data = pd.read_excel("weatherHistoryFinal.xlsx")
tempList = list(data["Precip Type"])
tempList2 = list(data["Humidity"])
for i in range(len(tempList)):
    if tempList2[i] == "Very High Humidity":
        if RNG(1):
            tempList[i] = "No precip"
    elif tempList2[i] == "High Humidity":
        if RNG(10):
            tempList[i] = "No precip"
    elif tempList2[i] == "Normal Humidity":
        if RNG(40):
            tempList[i] = "No precip"
    elif tempList2[i] == "Low Humidity":
        if RNG(80):
            tempList[i] = "No precip"
    else:
        if RNG(99):
            tempList[i] = "No precip"


data["Precip Type"] = pd.DataFrame(tempList)
data.to_excel(r"weatherHistoryFinal2.xlsx")
