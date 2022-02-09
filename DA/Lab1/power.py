from sympy import *
import math

def squareSum(x):
    sumOut = 0
    for i in range(len(x)):
        sumOut += x[i]**2
    return sumOut

def multiSum(x, y):
    sumOut = 0
    if len(x) != len(y):
        return -math.inf
    for i in range(len(x)):
        sumOut += x[i] * y[i]
    return sumOut

def Regression(x, y, precision):
    X = Symbol('x')

    lnX = [log(x[i]) for i in range(len(x))]
    lnY = [log(y[i]) for i in range(len(y))]

    Mx2 = 1/len(lnX) * squareSum(lnX)
    Mx = 1/len(lnX) * sum(lnX)
    Mxy = 1/len(lnX) * multiSum(lnX, lnY)
    My = 1/len(lnY) * sum(lnY)

    b = round((Mxy-Mx*My)/(Mx2-Mx**2), precision)
    lnA = (Mx2*My-Mx*Mxy)/(Mx2-Mx**2)
    a = round(math.exp(lnA), precision)

    func = a*(X**b)
    Y = lambdify(X, func)

    return func, Y