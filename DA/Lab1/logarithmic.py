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

    Mx2 = 1/len(lnX) * squareSum(lnX)
    Mx = 1/len(lnX) * sum(lnX)
    Mxy = 1/len(lnX) * multiSum(lnX, y)
    My = 1/len(y) * sum(y)

    a = round((Mxy - Mx * My) / (Mx2 - Mx ** 2), precision)
    b = round((Mx2 * My - Mx * Mxy) / (Mx2 - Mx ** 2), precision)

    func = a*log(X) + b
    Y = lambdify(X, func)

    return func, Y