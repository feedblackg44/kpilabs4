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

    u = [1/x[i] for i in range(len(x))]

    Mu2 = 1/len(u) * squareSum(u)
    Mu = 1/len(u) * sum(u)
    Muy = 1/len(u) * multiSum(u, y)
    My = 1/len(y) * sum(y)

    a = round((Muy-Mu*My)/(Mu2-Mu**2), precision)
    b = round((Mu2*My-Mu*Muy)/(Mu2-Mu**2), precision)

    func = (a/X)+b
    Y = lambdify(X, func)

    return func, Y