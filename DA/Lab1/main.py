from matplotlib import pyplot as pp
import numpy as np

import linear
import hyperbolic
import power
import exponential
import logarithmic

np.seterr(divide='ignore')
np.seterr(invalid='ignore')

x = [0.28, 0.19, 0.15, 0.11, 0.09, 0.08, 0.07, 0.06]
y = [82.16, 61.02, 44.56, 82.52, 99.19, 70.24, 63.23, 66.48]

precision = 6

def showResult(func, Y, name):
    e = [round((y[i] - Y(x[i])) ** 2, precision) for i in range(len(x))]
    S = sum(e)

    print(20*'#', name, 20*'#')
    print("Регресійна функція: y =", func)
    print("Сума квадратів відхилень:", round(S, precision), "\n")

    tempX = [i/100 for i in range(int(min(x)*100)-20, int(max(x)*100)+21)]
    tempY = []
    i = 0
    while i < len(tempX):
        try:
            if np.iscomplex(Y(tempX[i])) or np.isnan(Y(tempX[i])) or np.isinf(Y(tempX[i])):
                tempX.pop(i)
            else:
                tempY.append(Y(tempX[i]))
                i += 1
        except:
            tempX.pop(i)

    pp.plot(x, y, "ro")
    pp.plot(tempX, tempY, "b")
    pp.title(name + " регресія")
    pp.show()


########################## Linear ##########################

linearFunc, linearY = linear.Regression(x, y, precision)
showResult(linearFunc, linearY, "Лінійна")

########################## Hyperbolic ##########################

hyperbolicFunc, hyperbolicY = hyperbolic.Regression(x, y, precision)
showResult(hyperbolicFunc, hyperbolicY, "Гіперболічна")

########################## Power ##########################

powerFunc, powerY = power.Regression(x, y, precision)
showResult(powerFunc, powerY, "Степенева")

########################## Exponential ##########################

exponentialFunc, exponentialY = exponential.Regression(x, y, precision)
showResult(exponentialFunc, exponentialY, "Показникова")

########################## Logarithmic ##########################

logarithmicFunc, logarithmicY = logarithmic.Regression(x, y, precision)
showResult(logarithmicFunc, logarithmicY, "Логарифмічна")