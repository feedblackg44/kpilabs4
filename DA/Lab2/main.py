################################### Includes ###################################

from sympy import *
import numpy as np
from matplotlib import pyplot as pp

import simpleSearch as simple
import vidpalSearch as vidpal

################################### Constants ###################################

X = Symbol('X')
Y = Symbol('Y')

Func = -(1+cos(18*sqrt(X**2+Y**2)))/(X**2+Y**2+1)
F = lambdify([X, Y], Func)
minVars = [-5, -5]
maxVars = [5, 5]
minArg = [0, 0]
minFunc = -2
presicion = 6
amount = 101

################################### Functions ###################################

def showSurface(F, A, B, N):
    arrX = np.linspace(A[0], B[0], N)
    arrY = np.linspace(A[1], B[1], N)
    arrX, arrY = np.meshgrid(arrX, arrY)
    arrFunc = F(arrX, arrY)
    fig1 = pp.figure()
    ax = fig1.add_subplot(111, projection='3d')
    ax.plot_surface(arrX, arrY, arrFunc, rstride=1, cstride=1, cmap='viridis', edgecolor='none')
    pp.show()

################################### Main ###################################

print(Func)
print(F(minArg[0], minArg[1]))
showSurface(F, minVars, maxVars, amount)

N = 100
simpleXY, simpleFunc = simple.Search(F, minVars, maxVars, N)
print(round(simpleXY[0], presicion),
      round(simpleXY[1], presicion),
      round(simpleFunc, presicion))

T0 = 0.01
T = 50
V = 0.99
vidpalXY, vidpalFunc = vidpal.Search(F, minVars, maxVars, T0, T, V)
print(round(vidpalXY[0], presicion),
      round(vidpalXY[1], presicion),
      round(vidpalFunc, presicion))